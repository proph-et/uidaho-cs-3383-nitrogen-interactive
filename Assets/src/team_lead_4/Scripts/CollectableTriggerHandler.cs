using UnityEngine;

public class CollectableTriggerHandler : MonoBehaviour
{
    [SerializeField] private LayerMask WhoCanCollect;

    private Collectable _collectable;

    private void Awake()
    {
        _collectable = GetComponent<Collectable>();
    }

    private void OnTriggerEnter(Collider collision) 
    {
        if(collision.CompareTag("Player"))
        {
            _collectable.Collect(collision.gameObject);
            //Destroy for now...
            Destroy(gameObject);
        }
    }  
}
