using System;
using UnityEngine;
using System.Collections;

public class SpawnEnemiesAbility : BossAbility
{
    private EnemySpawner enemySpawner;
    private int amoutToSpawn = 3;

    public SpawnEnemiesAbility()
    {
        Name = "SpawnEnemies";
        type = AbilityType.Summon;
        Range = 999f;
        cooldown = 10f;
    }

    protected override bool CanExecuteInternal(BossLevel boss)
    {
        return boss.Cooldowns.Ready(Name);
    }

    protected override void ExecuteInternal(BossLevel boss, Action onComplete)
    {
        boss.Movement.StopMoving();
        boss.Animator.SetTrigger("Channel");

        boss.Cooldowns.StartCooldown(Name, cooldown);

        enemySpawner = GameObject.FindAnyObjectByType<EnemySpawner>();

        boss.StartCoroutine(ChannelRoutine(boss, onComplete));
    }

    private IEnumerator ChannelRoutine(BossLevel boss, Action onComplete)
    {
        float animTime = 1f;

        if (boss.Animator != null)
        {
            var info = boss.Animator.GetCurrentAnimatorStateInfo(0);
            if(info.length > 0.1f)
            {
                animTime = info.length;
            }
        }

        yield return new WaitForSeconds(animTime * 0.8f);

        SpawnAroundBoss(boss);

        yield return new WaitForSeconds(animTime * 0.2f);

        onComplete?.Invoke();
    }

    private void SpawnAroundBoss(BossLevel boss)
    {
        if(enemySpawner == null) {  return; }

        Vector3 origin = boss.transform.position;
        origin.y = 0;

        enemySpawner.transform.position = origin;

        enemySpawner.SpawnEnemyBoss(amoutToSpawn);
    }
}
