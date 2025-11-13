using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using Unity.VisualScripting;

public class BehaviorGraph
{
    private readonly BossLevel boss;
    private readonly List<BehaviorPath> _paths = new();

    private BehaviorPath _currentPath;
    private bool _isExecutingPath;

    public BehaviorGraph(BossLevel bossRef)
    {
        boss = bossRef;
    }

    public void Tick()
    {
        if (_isExecutingPath) { return; }

        ReevaluateProbabilities();
        _currentPath = PickWeightedPath(_paths);

        if (_currentPath != null && _currentPath.GetWeight() > 0f)
        {
            boss.StartCoroutine(ExecutePath(_currentPath));
        }
    }

    private IEnumerator ExecutePath(BehaviorPath path)
    {
        _isExecutingPath = true;
        Debug.Log($"[BehaviorGraph] Executing path: {path.GetName()}");
        //Debug.Log("COROUTINE: START PATH");

        foreach (var step in path.GetSteps()) // iterate through all steps in order
        {
            //Debug.Log("COROUTINE: Executing step");
            // Pick one node from this step (weighted random)
            var usableNodes = step.FindAll(n => n.CanExecute());
            if (usableNodes.Count == 0)
            {
                Debug.Log($"Skipping step: no usable abilities");
                continue;
            }

            BehaviorNode chosen = PickWeighted(usableNodes);
            Debug.Log($"   → Node: {chosen.Name}");

            // Ability tells us when it finishes via callback
            bool done = false;
            chosen.Execute(() => done = true);

            // Wait until the node reports completion
            while (!done)
                yield return null;
        }

        //Debug.Log("COROUTINE: END PATH");

        _isExecutingPath = false;
        _currentPath = null;
    }

    private BehaviorPath PickWeightedPath(List<BehaviorPath> list)
    {
        float total = 0f;
        foreach(var path in list)
        {
            total += path.GetWeight();
        }

        if(total <= 0f) { return null; }

        float roll = Random.value * total;

        foreach (var path in list)
        {
            if (roll < path.GetWeight()) { return path; }

            roll -= path.GetWeight();
        }
        
        return list.Count > 0 ? list[^1] : null;
    }

    private BehaviorNode PickWeighted(List<BehaviorNode> nodes)
    {
        float total = 0f;
        foreach (var n in nodes)
        {
            total += n.Probability;
        }

        if(total <= 0f) { return null; }

        float roll = Random.value * total;

        foreach (var n in nodes)
        {
            if (roll < n.Probability)
            {
                return n;
            }
            roll -= n.Probability;
        }

        return nodes[^1];
    }

    public void AddPath(BehaviorPath path)
    {
        if(path != null && !_paths.Contains(path))
        {
            _paths.Add(path);
        }
    }

    private void ReevaluateProbabilities()
    {
        float hp = boss.Health.GetHealthRatio();
        float distance = Vector3.Distance(boss.Player.position, boss.transform.position);

        //Debug.Log("We pass the Revaluate function");

        foreach (var path in _paths)
        {
            path.ResetToBaseWeight();
        }

        foreach (var path in _paths) 
        {
            //Debug.Log("We pass one path");
            bool pathInvalid = false;
            float usableSum = 0f;
            float requieredProduct = 1f;
            bool hasRequired = false;

            foreach (var entry in path.GetEntryNodes())
            {
                //Debug.Log("We pass the GetEntryNodes");
                foreach (var node in FlattenPath(entry))
                {
                    //Debug.Log("We pass the FlattenPath");
                    node.ResetProbability();

                    // cooldown check
                    if (!node.CanExecute())
                    {
                        node.SetProbability(0f);
                        if (node.IsRequired)
                        {
                            pathInvalid = true;
                        }
                        continue;
                    }

                    // do the reweighting for range and Hp, maybe add some *modifiers to the if statments
                    if(distance > node.Range)
                    {
                        node.SetProbability(node.Probability * 0.2f);
                    }
                    else if (distance < node.Range)
                    {
                        node.SetProbability(node.Probability * 1.5f);
                    }

                    //figure out the hp per phase value 30% left in the phase
                    if (hp < 0.34f && node.Type == AbilityType.Heavyattack)
                    {
                        node.SetProbability(node.Probability * 1.4f);
                    }
                    else if (hp < 0.68f && hp > 0.34f && node.Type == AbilityType.Special)
                    {
                        node.SetProbability(node.Probability * 1.4f);
                    }
                    else if (hp > 0.68 && node.Type == AbilityType.Attack)
                    {
                        node.SetProbability(node.Probability * 1.4f);
                    }

                    usableSum += node.Probability;

                    if (node.IsRequired)
                    {
                        hasRequired = true;
                        requieredProduct *= node.Probability;
                    }
                }
            }

            if (pathInvalid)
            {
                path.SetWeight(0f);
                continue;
            }

            path.SetWeight(usableSum * (hasRequired ? requieredProduct  : 1f));
        }

        NormalizePathWeight();
    }

    private void NormalizePathWeight()
    {
        float total = 0f;

        foreach (var path in _paths)
        {
            total += path.GetWeight();
        }

        if(total <= 0f) { return; }

        foreach (var path in _paths)
        {
            path.SetWeight(path.GetWeight() / total);
        }
    }

    private IEnumerable<BehaviorNode> FlattenPath(BehaviorNode root)
    {
        var visited = new HashSet<BehaviorNode>();
        var stack = new Stack<BehaviorNode>();
        stack.Push(root);

        while (stack.Count > 0)
        {
            var current = stack.Pop();
            if (!visited.Add(current))
            {
                continue;
            }

            yield return current;

            foreach (var next in current.NextNodes)
            {
                stack.Push(next);
            }
        }
    }
}