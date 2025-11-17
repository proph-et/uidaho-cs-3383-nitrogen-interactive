using UnityEngine;

public abstract class BossPhase
{
    protected BossLevel boss;
    protected BehaviorGraph graph;

    public virtual void Init(BossLevel bossContext)
    {
        boss = bossContext;
        //build the the graph in each phase
        graph = new BehaviorGraph(boss);
        BuildGraph();
    }

    protected abstract void BuildGraph();

    public void UpdateBehavior(Transform player)
    {
        graph?.Tick();
    }
}
