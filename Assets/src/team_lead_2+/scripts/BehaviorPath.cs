using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BehaviorPath
{
    private readonly string _name;
    private float _weight;
    private readonly List<BehaviorNode> _entryNodes = new();
    private readonly List<List<BehaviorNode>> _steps = new();

    public BehaviorPath(string name, float initialWeight)
    {
        _name = name;
        _weight = initialWeight;
    }

    //make the values readonly accessable 
    public string GetName() => _name;
    public float GetWeight() => _weight;
    public IReadOnlyList<BehaviorNode> GetEntryNodes() => _entryNodes.AsReadOnly();
    public IReadOnlyList<List<BehaviorNode>> GetSteps() => _steps.AsReadOnly();

    public void SetWeight(float weight)
    {
        _weight = weight;
    }

    public void AddEntryNode(BehaviorNode node)
    {
        if (node != null && !_entryNodes.Contains(node))
        {
            _entryNodes.Add(node);
        }
    }

    public void AddStep(params BehaviorNode[] nodes)
    {
        var step = new List<BehaviorNode>();
        foreach (var n in nodes)
        {
            if (n != null)
                step.Add(n);
        }

        if (step.Count > 0)
            _steps.Add(step);
    }
}
