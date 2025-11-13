using UnityEngine;

public class XPHandler : Collectable
{
    // [SerializeField] private XPSO xpData;

    // public override void Collect(GameObject collector)
    // {
    //     base.Collect(collector);

    //      PlayerLevel playerLevel = collector.GetComponent<PlayerLevel>();

    //     if (playerLevel != null)
    //     {
    //         playerLevel.levelSystem.AddXp(xpData.xpAmount);
    //         Debug.Log($"Gained {xpData.xpAmount} XP!");
    //     }
    //     else
    //     {
    //         Debug.LogWarning("No PlayerLevel component found on collector!");
    //     }
    // }
}
