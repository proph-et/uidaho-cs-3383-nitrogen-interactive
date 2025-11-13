using UnityEngine;
using System.Collections.Generic;

public class Phase2 : BossPhase
{

    public override void Init(BossLevel bossContext)
    {
        base.Init(bossContext);

        // Then do phase-specific changes
        boss.Movement.SetSpeedMultiplier(1.2f);
        boss.Cooldowns.SetCooldownMultiplier(0.9f);
        boss.Animator.SetFloat("AttackSpeed", 1.2f);
    }

    protected override void BuildGraph()
    {
        // MOVEMENT NODE
        var move = new BehaviorNode(
            name: "Move",
            type: AbilityType.Movement,
            baseProb: 1.0f,
            range: float.MaxValue,
            isRequired: true,
            condition: () => boss.Abilities.Move.CanExecute(boss),
            action: () => { },
            executeAsync: (onComplete) =>
            {
                boss.Abilities.Move.Execute(boss, onComplete);
            }
        );

        // ATTACK NODE
        var attack = new BehaviorNode(
            name: "Attack",
            type: AbilityType.Attack,
            baseProb: 0.8f,
            range: 5f,
            isRequired: true,
            condition: () => boss.Abilities.Attack.CanExecute(boss),
            action: () => { },
            executeAsync: (onComplete) =>
            {
                boss.Abilities.Attack.Execute(boss, onComplete);
            }
        );

        // Behavior path
        var aggressive = new BehaviorPath("aggressive", 1.0f);
        aggressive.AddStep(move);
        aggressive.AddStep(attack);

        // initialize graph
        graph.AddPath(aggressive);
    }
}