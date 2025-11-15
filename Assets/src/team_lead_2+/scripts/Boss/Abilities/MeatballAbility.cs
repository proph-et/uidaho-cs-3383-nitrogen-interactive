using System;
using UnityEngine;

public class MeatballAbility : BossAbility
{
    public MeatballAbility()
    {
        Name = "MeatballAbility";
        type = AbilityType.Special;
        Range = 999f;
        cooldown = 5f;
    }

    protected override bool CanExecuteInternal(BossLevel boss)
    {
        return boss.Cooldowns.Ready(Name);
    }

    protected override void ExecuteInternal(BossLevel boss, Action onComplete)
    {
        // Stop movement during casting
        boss.Movement.StopMoving();

        // Trigger the channelling animation in the animator
        boss.Animator.SetTrigger("Channel");

        // Start cooldown now
        boss.Cooldowns.StartCooldown(Name, cooldown);

        // Animation → spawn → done
        boss.StartCoroutine(ChannelRoutine(boss, onComplete));
    }

    private System.Collections.IEnumerator ChannelRoutine(BossLevel boss, Action onComplete)
    {
        // Wait for channel animation wind-up
        float animTime = 1.0f;

        AnimatorStateInfo info = boss.Animator.GetCurrentAnimatorStateInfo(0);
        if (info.length > 0.05f)
            animTime = info.length;

        yield return new WaitForSeconds(animTime * 0.7f);

        // Spawn the fireball
        boss.Combat.SpawnFireballAboveBoss();

        // Small delay after the projectile forms
        yield return new WaitForSeconds(animTime * 0.3f);

        onComplete?.Invoke();
    }
}
