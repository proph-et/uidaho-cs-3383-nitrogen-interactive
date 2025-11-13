using UnityEngine;

public class XPHandler : Collectable
{
    // [SerializeField] private XPSO xpData;

    public override void Collect(GameObject collector)
    {
        // base.Collect(collector);
        Debug.Log("added xp");
        LevelSystem.Instance.AddXp(5);
    }
}
