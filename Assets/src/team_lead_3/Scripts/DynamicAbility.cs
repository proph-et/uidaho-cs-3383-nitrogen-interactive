using UnityEngine;

public class DynamicAbility
{
    public virtual void Unlock()
    {
        Debug.Log("Used a generic ability");
    }

}

public class Ability101 : DynamicAbility
{
    public override void Unlock()
    {
        Debug.Log("Ab101 unlocked");
        LevelSystem.Instance.AddXp(35);
    }

    public static void DoNothing()
    {
        LevelSystem.Instance.AddXp(0);
    }
}
