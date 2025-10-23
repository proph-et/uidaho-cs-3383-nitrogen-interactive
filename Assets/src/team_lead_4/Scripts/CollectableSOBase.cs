using UnityEngine;


//Forces us to create this collect method on any scripts that inherit from this class
public abstract class CollectableSOBase : ScriptableObject
{
    public abstract void Collect(GameObject objectThatCollected);   
}
