using UnityEngine;

[CreateAssetMenu(menuName ="Collectable/Health", fileName ="New Health Collectable")]
public class HealthSO : CollectableSOBase
{
    private int HealthAmount = 10; // How much health this pickup restores

    public override void Collect(GameObject objectThatCollected)
    {
        // Try to get the Health component from whoever picked this up
        var health = objectThatCollected.GetComponent<Health>();
        if (health != null)
        {
            // Heal the collector by the configured amount
            health.Heal(HealthAmount);
        }
    }

    public int GetHealthAmount()
    {
        return HealthAmount; // Return how much health this item restores
    }

    public void SetHealthAmount(int amount)
    {
        HealthAmount = amount; // Update the heal amount 
    }
}
