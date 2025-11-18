using UnityEngine;

public class Arrow : MonoBehaviour
{
    private float speed = 30f; // Holds speed of the arrow.
    private float damage = 20f; // Holds damage of the arrow.

    private float lifetime = 10f; // Holds the lifetime of the arrow. Controls how long the arrow is in the world before being destroyed.

    private float collisionDelay = 0.25f; // Controls how long before the arrow can collide with objects.

    private float spawnTime; // Holds the time that the arrow was spawned.
    private bool collisionActive = false; // Tracks when the arrow is allowed to collide with objects.

    Rigidbody arrowRB; // Reference to the arrow's Rigidbody component.
    private bool hasHit = false; // Tracks if the arrow has already hit something.

    void Awake()
    {
        arrowRB = GetComponent<Rigidbody>(); // Grab the rigid body component of the arrow.
    }

    void Start()
    {
        spawnTime = Time.time; // Document what in game time the arrow is spawned at.
        Destroy(gameObject, lifetime); // Eventually destroy the arrow after its lifetime ends.
    }

    void Update()
    {
        if (!collisionActive && Time.time - spawnTime >= collisionDelay) // Check if enough time has passed before enabling collisions.
        {
            collisionActive = true; // Enable collision after delay.
            // Debug.Log("collision active true");
        }
    }

    void FixedUpdate()
    {
        if (!hasHit && arrowRB.linearVelocity.sqrMagnitude > 0.01f) // Keep rotating the arrow to face its velocity if we haven't hit anything and are still moving.
        {
            transform.forward = Vector3.Lerp(transform.forward, arrowRB.linearVelocity.normalized, Time.fixedDeltaTime * 10f); // Smoothly rotate arrow to match its flight direction.
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (hasHit) return;
        if (collider.gameObject.CompareTag("Player")) return;
        if (collider.gameObject.CompareTag("EnemyProjectile")) return;
        if (collider.gameObject.CompareTag("NoCollision")) return;


        hasHit = true; // Mark the arrow as having hit something.
        if (collider.gameObject.CompareTag("Enemy"))
        {
            var health = collider.GetComponent<Health>(); // Try to get the Health component of the thing we hit.
            if (health != null)
            {
                health.TakeDamage(GetDamage()); // Apply damage if it has health.
            }
        }

        arrowRB.linearVelocity = Vector3.zero; // Stop the arrow's movement.
        arrowRB.isKinematic = true; // Disable physics on the arrow.
        transform.parent = collider.transform; // Stick the arrow to the object it hit.
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