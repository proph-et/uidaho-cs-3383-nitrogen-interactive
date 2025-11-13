using System;
using System.Diagnostics;
using UnityEngine;

public class SwordAttackAbility : BossAbility
{
    public SwordAttackAbility()
    {
        Name = "SwordAttack";
        type = AbilityType.Attack;
        Range = 3f;
        cooldown = 2f;
    }

    protected override bool CanExecuteInternal(BossLevel boss)
    {
        if (boss == null) return false;

        float distance = Vector3.Distance(boss.transform.position, boss.Player.position);

        return distance <= Range && boss.Cooldowns != null && boss.Cooldowns.Ready(Name);
    }

    protected override void ExecuteInternal(BossLevel boss, Action onComplete)
    {
        if(boss == null)
        {
            onComplete?.Invoke();
            return;
        }

        boss.Movement?.StopMoving();

        boss.Animator?.CrossFade("SwordAttack", 0.1f);

        boss.Cooldowns?.StartCooldown(Name, cooldown);

        boss.StartCoroutine(WaitForAttackEnd(boss, onComplete));
    }

    private System.Collections.IEnumerator WaitForAttackEnd(BossLevel boss, Action onComplete)
    {
        float waitTime = 0.8f;

        if (boss.Animator != null)
        {
            var info = boss.Animator.GetCurrentAnimatorStateInfo(0);
            if (info.length > 0.05f)
            {
                waitTime = info.length;
            }
        }

        yield return new WaitForSeconds(waitTime);
        onComplete?.Invoke();
    }
}
