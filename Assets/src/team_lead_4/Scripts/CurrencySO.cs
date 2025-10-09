using UnityEngine;


[CreateAssetMenu(menuName ="Collectable/Currency", fileName ="New Coin Collectable")]

public class CurrencySO : CollectableSOBase
{
    private int CurrencyAmount = 1;
    private int Currency = 0;

    private void OnEnable()
    {
        //TEMPORARY: reset every time the game starts or asset is loaded
        Currency = 0; 
    }

    public override void Collect(GameObject objectThatCollected)
    {
        Currency += CurrencyAmount;
        Debug.Log("Dough: " + Currency);

    }
    
}
