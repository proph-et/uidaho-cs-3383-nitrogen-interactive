using UnityEngine;
using System;

public abstract class BossAbility
{
    public string Name { get; protected set; }

    public AbilityType type { get; protected set; }

    public float Range { get; protected set; }

    public float cooldown { get; protected set; }

    protected abstract bool CanExecuteInternal(BossLevel boss);
    protected abstract void ExecuteInternal(BossLevel boss, Action onComplete);

    public bool CanExecute(BossLevel boss)
    {
        return boss != null && CanExecuteInternal(boss);
    }

    public void Execute(BossLevel boss, Action onComplete)
    {
        if(boss == null)
        {
            onComplete?.Invoke();
            return;
        }

        ExecuteInternal(boss, onComplete);
    }
}
