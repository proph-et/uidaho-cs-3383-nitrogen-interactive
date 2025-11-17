using UnityEngine;

[CreateAssetMenu(menuName ="Collectable/Health", fileName ="New Health Collectable")]
public class HealthSO : CollectableSOBase
{
    private int HealthAmount = 10;

    public override void Collect (GameObject objectThatCollected)
    {
        var health = objectThatCollected.GetComponent<Health>();
        if (health != null)
        {
            health.Heal(HealthAmount);
        }
    }

    public int GetHealthAmount()
    {
        return HealthAmount;
    }

    public void SetHealthAmount(int amount)
    {
        HealthAmount = amount;
    }
}
