using UnityEngine;

public class MagicOrb : MonoBehaviour
{
    private float speed = 15f;
    private float lifetime = 2f;
    private float damage = 10;
    private float collisionDelay = 0.25f;

    private float spawnTime;
    private bool collisionActive = false;

    private void Start()
    {
        spawnTime = Time.time;
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (!collisionActive && Time.time-spawnTime >= collisionDelay)
        {
            collisionActive = true;
            // Debug.Log("collision active true");
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!collisionActive) return;
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

