using UnityEngine;

public class SauceDamage : MonoBehaviour 
{
    [SerializeField] private float damagePerSecond = 5f;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var health = other.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damagePerSecond * Time.deltaTime);
            }
        }
    }
}
