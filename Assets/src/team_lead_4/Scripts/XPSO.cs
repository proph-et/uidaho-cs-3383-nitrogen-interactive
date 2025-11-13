using UnityEngine;

[CreateAssetMenu(menuName ="Collectable/XP", fileName ="New XP Collectable")]

public class XPSO : CollectableSOBase
{
    public int xpAmount = 1;


    public override void Collect(GameObject objectThatCollected)
    {
        Debug.Log("added xp");

    }
}
