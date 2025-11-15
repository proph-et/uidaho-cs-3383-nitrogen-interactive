using UnityEngine;

[CreateAssetMenu(menuName ="Collectable/Health", fileName ="New Health Collectable")]
public class HealthSO : CollectableSOBase
{
    public int HealthAmount = 1;

    public override void Collect (GameObject objectThatCollected)
    {
        var health = objectThatCollected.GetComponent<Health>();
        if (health != null)
        {
            health.Heal(HealthAmount);
        }
    }
}
