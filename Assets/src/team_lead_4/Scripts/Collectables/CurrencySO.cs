using UnityEngine;


[CreateAssetMenu(menuName = "Collectable/Currency", fileName = "New Coin Collectable")]
public class CurrencySO : CollectableSOBase
{
    private int CurrencyAmount = 1;
    private int MaxCurrency = int.MaxValue;

    public override void Collect(GameObject objectThatCollected)
    {
        // Try to get the Inventory component from the collector
        Inventory inventory = objectThatCollected.GetComponent<Inventory>();
        if (inventory != null)
        {
            inventory.AddMoney(CurrencyAmount);
            Debug.Log($"Collected {CurrencyAmount} coins. Total: {inventory.GetMoney()}");
        }
        else
        {
            Debug.LogWarning("Collector has no Inventory component!");
        }
    }

    public int GetCurrency()
    {
        return CurrencyAmount;
    }

    public void SetCurrency(int amount)
    {
        CurrencyAmount = amount;
    }

    public int GetCurrencyAmount()
    {
        return CurrencyAmount;
    }
}