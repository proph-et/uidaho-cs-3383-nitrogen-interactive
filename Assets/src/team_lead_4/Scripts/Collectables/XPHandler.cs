using UnityEngine;

public class XPHandler : Collectable
{
    // Handles awarding XP when collected
    private int amountXP = 5;

    public override void Collect(GameObject collector)
    {
        // Grant a fixed amount of XP to the LevelSystem
        LevelSystem.Instance.GetAddXp(amountXP);
    }
}
