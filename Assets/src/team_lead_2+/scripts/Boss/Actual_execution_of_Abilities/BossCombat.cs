using Unity.VisualScripting;
using UnityEngine;

public class BossCombat : MonoBehaviour
{
    [SerializeField] private float swordRange = 2f;
    [SerializeField] private int swordDamage = 10;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private GameObject MeatballPrefab;

    public void DoSwordAttack()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, swordRange, playerLayer);
        foreach (var hit in hits) 
        {
            var hp = hit.GetComponentInParent<Health>();
            if(hp != null)
            {
                hp.TakeDamage(swordDamage);
            }
        }

    }

    public void SpawnMeatballAboveBoss()
    {
        Vector3 spawnPos = transform.position + Vector3.up * 3f;
        GameObject obj = Instantiate(MeatballPrefab, spawnPos, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, swordRange);
    }
}