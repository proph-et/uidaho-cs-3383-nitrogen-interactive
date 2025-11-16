using UnityEngine;


[CreateAssetMenu(menuName = "Collectable/Currency", fileName = "New Coin Collectable")]
public class CurrencySO : CollectableSOBase
{
    public int CurrencyAmount = 1;
    private int MaxCurrency = int.MaxValue;

    public override void Collect(GameObject objectThatCollected)
    {
        // Try to get the Inventory component from the collector
        Inventory inventory = objectThatCollected.GetComponent<Inventory>();
        if (inventory != null)
        {
            inventory.addMoney(CurrencyAmount);
            Debug.Log($"Collected {CurrencyAmount} coins. Total: {inventory.getMoney()}");
        }
        else
        {
            Debug.LogWarning("Collector has no Inventory component!");
        }
    }
}