using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 15f;
    public float damage = 10f;
    public float lifetime = 10f;
    public float collisionDelay = 1f;

    private float spawnTime;
    private bool collisionActive = false;

    Rigidbody arrowRB;
    bool hasHit = false;

    void Awake()
    {
        arrowRB = GetComponent<Rigidbody>();
    }

    void Start()
    {
        spawnTime = Time.time;
        Destroy(gameObject, lifetime);
    }

    void FixedUpdate()
    {

        if (!hasHit && arrowRB.linearVelocity.sqrMagnitude > 0.01f)
        {
            transform.forward = Vector3.Lerp(transform.forward, arrowRB.linearVelocity.normalized, Time.fixedDeltaTime * 10f);
        }

        if (!collisionActive && Time.time-spawnTime >= collisionDelay)
        {
            collisionActive = true;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        

        Debug.Log("has hit");
        if (!collisionActive) return;
        if (hasHit) return;
        hasHit = true;

        arrowRB.linearVelocity = Vector3.zero;
        arrowRB.isKinematic = true;
        transform.parent = collider.transform;

        Debug.Log("do damage projectile");
    }

    public float GetArrowSpeed()
    {
        return speed;
    }

    public Rigidbody GetArrowRB()
    {
        return arrowRB;
    }
}
