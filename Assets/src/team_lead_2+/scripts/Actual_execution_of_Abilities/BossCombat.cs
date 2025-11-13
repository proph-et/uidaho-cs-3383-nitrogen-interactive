using Unity.VisualScripting;
using UnityEngine;

public class BossCombat : MonoBehaviour
{
    [SerializeField] private float swordRange = 2f;
    [SerializeField] private int swordDamage = 10;
    [SerializeField] private LayerMask playerLayer;

    public void DoSwordAttack()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, swordRange, playerLayer);
        foreach (var hit in hits) 
        {
            var hp = hit.GetComponent<Health>();
            if(hp != null)
            {
                hp.TakeDamage(swordDamage);
            }
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, swordRange);
    }
}