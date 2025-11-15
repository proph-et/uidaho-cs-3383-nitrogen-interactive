using UnityEngine;


[CreateAssetMenu(menuName ="Collectable/Currency", fileName ="New Coin Collectable")]

public class CurrencySO : CollectableSOBase
{
    public int CurrencyAmount = 1;
    private int Currency = 0;
    private int MaxCurrency = int.MaxValue;

    private void OnEnable()
    {
        //TEMPORARY: reset every time the game starts or asset is loaded
        Currency = 0; 
    }

    public override void Collect(GameObject objectThatCollected)
    {
        long result = (long)Currency + CurrencyAmount;
        if(result>MaxCurrency)
        {
            Currency = MaxCurrency;
            Debug.Log("Error: currency overflow reached");
        }

        if(result < 0)
        {
            Currency = 0;
            Debug.Log("Error: Negative Currency");
        }
        // Debug.Log("Dough: " + Currency);

    }
    
    public int GetCurrency()
    {
        return Currency;
    }

    public void SetCurrency(int x)
    {
        Currency = x;
    }

}
