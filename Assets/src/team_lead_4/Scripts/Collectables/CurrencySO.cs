using UnityEngine;

[CreateAssetMenu(menuName = "Collectable/Currency", fileName = "New Coin Collectable")]
public class CurrencySO : CollectableSOBase
{
    public int CurrencyAmount = 1;          // How much currency this collectable gives
    private int MaxCurrency = int.MaxValue; // Hard cap to prevent overflow (not currently enforced)

    public override void Collect(GameObject objectThatCollected)
    {
        // Try to get the Inventory component from the collector
        Inventory inventory = objectThatCollected.GetComponent<Inventory>();
        if (inventory != null)
        {
            // Add the configured currency amount to the player's inventory
            inventory.AddMoney(CurrencyAmount);

            // Log current total for debugging
            Debug.Log($"Collected {CurrencyAmount} coins. Total: {inventory.GetMoney()}");
        }
        else
        {
            // Warn if the object collecting has no inventory attached
            Debug.LogWarning("Collector has no Inventory component!");
        }
    }

    public int GetCurrency()
    {
        return CurrencyAmount; // Return how much this coin is worth
    }

    public void SetCurrency(int amount)
    {
        CurrencyAmount = amount; // Update coin value (used by tests or dynamic difficulty)
    }
}