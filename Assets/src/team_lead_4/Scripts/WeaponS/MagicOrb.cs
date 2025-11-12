using UnityEngine;

public class MagicOrb : MonoBehaviour
{
    public float speed = 15f;
    public float lifetime = 2f;
    public int damage = 10;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("do damage projectile");
    }
}

