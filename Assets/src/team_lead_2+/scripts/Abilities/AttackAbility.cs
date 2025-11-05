using UnityEngine;
using System;
using System.Collections;

public class AttackAbility : BossAbility
{
    public override void Execute(Action onComplete)
    {
        if (!CanUse())
        {
            onComplete?.Invoke();
            return;
        }

        animator.SetTrigger("Attack");
        ArmCooldown();
        StartCoroutine(FinishAfterAnim("Attack", onComplete));
    }
}