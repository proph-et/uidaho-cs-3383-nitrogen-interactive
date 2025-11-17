using System;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorNode
{
    private readonly string _name;
    private readonly AbilityType _type;
    private readonly float _baseprobability;
    private float _currentProbability;
    private readonly bool _IsRequired;
    private readonly float _range;
    private readonly System.Action<System.Action> _executeAsync;

    private readonly List<BehaviorNode> _nextNodes = new List<BehaviorNode>();
    private readonly Func<bool> _condition;
    private readonly Action _action;
    
    //cunstructor
    public BehaviorNode(string name, AbilityType type, float baseProb, float range, Func<bool> condition, bool isRequired, Action action, System.Action<System.Action> executeAsync)
    {
        _name = name;
        _type = type;
        _baseprobability = baseProb;
        _currentProbability = baseProb;
        _range = range;
        _IsRequired = isRequired;
        _condition = condition;
        _action = action;
        _executeAsync = executeAsync;
    }

    //-- Read from outside of here to build graphs with it in Phase1 ...,  mostly debugging --
    public string Name => _name;
    public AbilityType Type => _type;
    public float Probability => _currentProbability;

    public bool IsRequired => _IsRequired;
    public float Range => _range;
    public IReadOnlyList<BehaviorNode> NextNodes => _nextNodes;

    //to change the probability
    public void SetProbability(float p) => _currentProbability = Mathf.Max(0f, p);
    public void ResetProbability() => _currentProbability = _baseprobability;

    //Node controll for executing the abilitys 
    public bool CanExecute() => _condition == null || _condition.Invoke();
    public void Execute() => _action?.Invoke();

    //for building graph with this function
    public void AddNextNode(BehaviorNode node)
    {
        if (node == null) return;
        _nextNodes.Add(node);
    }

    public void Execute(System.Action action)
    {
        _executeAsync?.Invoke(action);
    }
}
