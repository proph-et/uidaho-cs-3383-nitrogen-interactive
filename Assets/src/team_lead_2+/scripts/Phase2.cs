using UnityEngine;
using System.Collections.Generic;

public class Phase2 : BossPhase
{
    protected override void BuildGraph()
    {
        //new graph
        graph = new BehaviorGraph(boss);

        //declare the abilitys
        var attack = new BehaviorNode(
            name: "Attack",
            type: AbilityType.Attack,
            baseProb: 0.8f,
            range: 5f,
            isRequired: true,
            condition: () => boss.Abilities.attack.CanUse(),
            action: () => { },
            executeAsync: (onComplete) =>
            {
                //add the animation
                boss.Abilities.attack.Execute(onComplete);
            }
        );

        // Define paths
        var aggressive = new BehaviorPath("aggressive", 1.0f);
        aggressive.AddStep(attack);

        //initialize the graph
        graph.AddPath(aggressive);
    }
}