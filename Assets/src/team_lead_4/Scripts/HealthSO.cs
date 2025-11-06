using UnityEngine;

[CreateAssetMenu(menuName ="Collectable/Health", fileName ="New Health Collectable")]
public class HealthSO : CollectableSOBase
{
    public int HealthAmount = 1;

    public override void Collect (GameObject objectThatCollected)
    {
        Inventory1 inventory = objectThatCollected.GetComponent<Inventory1>();

        if (inventory != null)
        {
            Item healthItem = new Item {itemName = "HealthBuff"};
            inventory.AddItem(healthItem);
        }

        else
        {
            Debug.LogWarning("Error: no inventory");
        }
    }
}
