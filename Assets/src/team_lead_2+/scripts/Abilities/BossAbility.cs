using UnityEngine;
using System;
using System.Collections;

public abstract class BossAbility : MonoBehaviour
{
    [SerializeField] protected Animator animator;
    [SerializeField] protected float cooldown = 1f;
    private float _readyAt;

    protected virtual void Awake()
    {
        if (animator == null)
            animator = GetComponentInParent<Animator>();
    }

    public virtual bool CanUse() => Time.time >= _readyAt;

    public void ArmCooldown() => _readyAt = Time.time + cooldown;

    public abstract void Execute(Action onComplete);

    protected IEnumerator FinishAfterAnim(string animName, Action onComplete)
    {
        // If you want dynamic length, fetch from AnimatorClipInfo
        yield return new WaitForSeconds(0.8f);
        onComplete?.Invoke();
    }
}
