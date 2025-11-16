using UnityEngine;

public class Arrow : MonoBehaviour
{
    private float speed = 30f; // Holds speed of the arrow.
    private float damage = 20f; // Holds damage of the arrow.
    private float lifetime = 10f; // Holds the lifetime of the arrow. Controls how long the arrow is in the world before being destroyed.
    private float collisionDelay = 0.25f; // Controls how long before the arrow can collide with objects.

    private float spawnTime; // Holds the time that the arrow was spawned.
    private bool collisionActive = false;

    Rigidbody arrowRB;
    private bool hasHit = false;

    void Awake()
    {
        arrowRB = GetComponent<Rigidbody>(); // Grab the rigid body component of the arrow
    }

    void Start()
    {
        spawnTime = Time.time; // Document what in game time the arrow is spawned at.
        Destroy(gameObject, lifetime); // Eventually destroy arrow
    }

    void Update()
    {
        if (!collisionActive && Time.time-spawnTime >= collisionDelay) // Check to see if the difference between when the arrow was spawned and the current time is more than the collision delay.
        {
            collisionActive = true;
            // Debug.Log("collision active true");
        }
    }

    void FixedUpdate()
    {

        if (!hasHit && arrowRB.linearVelocity.sqrMagnitude > 0.01f) // Keep moving if we haven't hit anything adn we haven't run out of velocity
        {
            transform.forward = Vector3.Lerp(transform.forward, arrowRB.linearVelocity.normalized, Time.fixedDeltaTime * 10f);
        }

    }

    void OnTriggerEnter(Collider collider)
    {
        // Debug.Log("collision triggered");
        if (!collisionActive) return;
        // Debug.Log("has hit");
        if (hasHit) return;
        hasHit = true;

        arrowRB.linearVelocity = Vector3.zero;
        arrowRB.isKinematic = true;
        transform.parent = collider.transform;

        var health = collider.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(GetDamage());
        }
    }

    public float GetArrowSpeed()
    {
        return speed;
    }

    public Rigidbody GetArrowRB()
    {
        return arrowRB;
    }

    public float GetDamage()
    {
        return damage;
    }

    public void SetDamage(float newDamage)
    {
        damage = newDamage;
    }
}
