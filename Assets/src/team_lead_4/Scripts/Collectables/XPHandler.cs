using UnityEngine;

public class XPHandler : Collectable
{
    // Handles awarding XP when collected

    public override void Collect(GameObject collector)
    {
        // Grant a fixed amount of XP to the LevelSystem
        LevelSystem.Instance.GetAddXp(5);
    }
}
