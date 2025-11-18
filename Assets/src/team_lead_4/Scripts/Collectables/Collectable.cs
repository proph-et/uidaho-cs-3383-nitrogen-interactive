using UnityEngine;


public class Collectable : MonoBehaviour
{
    [SerializeField] private CollectableSOBase _collectable;

    private void Reset()
    {
        //Double check that the box collider is a trigger
        GetComponent<BoxCollider>().isTrigger = true;
    }

    public virtual void Collect(GameObject objectThatCollected)
    {
        _collectable.Collect(objectThatCollected);
    }
}
