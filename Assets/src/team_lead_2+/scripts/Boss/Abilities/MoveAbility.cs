using System;
using System.Collections;
using UnityEngine;

public class MoveAbility : BossAbility
{
    private float maxDuration = 3.0f;   // how long the boss keeps chasing
    private float stopRange = 1.0f;     // distance at which movement ends

    public MoveAbility()
    {
        Name = "Move";
        type = AbilityType.Movement;
        Range = float.MaxValue;
        cooldown = 0f;
    }

    protected override bool CanExecuteInternal(BossLevel boss)
    {
        // movement is always allowed
        return true;
    }

    protected override void ExecuteInternal(BossLevel boss, Action onComplete)
    {
        boss.StartCoroutine(MoveRoutine(boss, onComplete));
    }

    private IEnumerator MoveRoutine(BossLevel boss, Action onComplete)
    {
        float timer = 0f;

        // chase for maxDuration OR until close enough
        while (timer < maxDuration)
        {
            boss.Movement.MoveTowardsPlayer();

            float distance = Vector3.Distance(
                boss.transform.position,
                boss.Player.position
            );

            // reached the player
            if (distance <= stopRange)
            {
                boss.Movement.StopMoving();
                onComplete?.Invoke();
                yield break;
            }

            timer += Time.deltaTime;
            yield return null;
        }

        // timeout
        boss.Movement.StopMoving();
        onComplete?.Invoke();
    }
}