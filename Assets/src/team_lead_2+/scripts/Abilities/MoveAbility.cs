using System;
using UnityEngine;

public class MoveAbility : BossAbility
{
    public MoveAbility()
    {
        Name = "Move";
        type = AbilityType.Movement;
        Range = float.MaxValue;
        cooldown = 0f;
    }

    protected override bool CanExecuteInternal(BossLevel boss)
    {
        return true;
    }

    protected override void ExecuteInternal(BossLevel boss, Action onComplete)
    {
        boss.Movement.MoveTowardsPlayer();

        onComplete?.Invoke();
    }
}
