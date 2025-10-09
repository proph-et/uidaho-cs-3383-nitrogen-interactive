using UnityEngine;

// [RequireComponent(typeof(BoxCollider2D))];
// [RequireComponent(typeof(CollectableTriggerHandler))];

public class Collectable : MonoBehaviour
{
    [SerializeField] private CollectableSOBase _collectable;

    void Start()
    {
        
    }

    void Update()
    {
        //Rotate the object for the effect
        transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
        
    }

    private void Reset()
    {
        //Double check that the box collider is a trigger
        GetComponent<BoxCollider>().isTrigger = true;
    }

    public void Collect(GameObject objectThatCollected)
    {
        _collectable.Collect(objectThatCollected);
    }
}
