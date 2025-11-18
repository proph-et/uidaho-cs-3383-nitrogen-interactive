using System.Collections.Generic;
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

        HashSet<GameObject> damaged = new HashSet<GameObject>();

        foreach (var hit in hits)
        {
            GameObject root = hit.transform.root.gameObject;

            if (damaged.Contains(root))
                continue;

            var hp = root.GetComponentInChildren<Health>();
            if (hp != null)
            {
                hp.TakeDamage(swordDamage);
                damaged.Add(root);
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