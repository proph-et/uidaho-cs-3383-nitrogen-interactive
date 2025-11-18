using UnityEngine;

public class MagicOrb : MonoBehaviour
{
    private float speed = 15f; // Holds the speed that the magic orb travels.
    private float lifetime = 2f; // Holds how long the orb exists before being destroyed.
    private float damage = 10; // Holds how much damage the orb deals on impact.
    private float collisionDelay = 0.25f; // Controls how long before the orb can collide with objects.

    private float spawnTime; // Tracks the time the orb was spawned.
    private bool collisionActive = false; // Tracks when the orb is allowed to collide with objects.

    private void Start()
    {
        spawnTime = Time.time; // Document the in-game time when the orb is spawned.
        Destroy(gameObject, lifetime); // Automatically destroy the orb after its lifetime ends.
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); // Move the orb forward every frame.

        if (!collisionActive && Time.time - spawnTime >= collisionDelay) // Check if collision delay has passed.
        {
            collisionActive = true; // Enable collisions after the delay.
            // Debug.Log("collision active true");
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!collisionActive) return; // Ignore collisions until enough time has passed.

        var health = collider.GetComponent<Health>(); 
        if (health != null)
        {
            health.TakeDamage(GetDamage()); 
        }
    }

    public float GetDamage()
    {
        return damage; 
    }

    public void SetDamage(float Damage)
    {
        damage = Damage; 
    }
}


