using UnityEngine;

public class SauceDamage : MonoBehaviour 
{
    [SerializeField] private float damagePerSecond = 5f;

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay works");
        if (other.CompareTag("Player"))
        {
            Debug.Log("comparetag palyer works");
            var health = other.GetComponentInParent<Health>();
            if (health != null)
            {
                Debug.Log("health on palyer was not null");
                health.TakeDamage(damagePerSecond * Time.deltaTime);
            }
        }
    }
}