using UnityEngine;

//ScriptableObjects allow: Shared reusable collectable definitions, Fewer prefabs, Easy balancing (change a value in one asset → all collectables update), Cleaner separation between data (SO) and trigger interaction (MonoBehaviour)

//Forces us to create this collect method on any scripts that inherit from this class
public abstract class CollectableSOBase : ScriptableObject
{
    public abstract void Collect(GameObject objectThatCollected);   
}
