using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Wand : WeaponBase
{
    private GameObject orbPrefab;
    private Transform firePoint;
    private Vector3 spawnP;
    private Quaternion spawnR;
    // private float nextAttackTime;

    public Wand(GameObject prefabType)
    {
        setWeaponName("Wand");
        setWeaponDamage(10);
        setAttackRate(1.5f);
        SetPrefab(prefabType);
        setWeaponTier(1);
        setAugmentName("NONE");
    }

    public void SetFirePointWand(Transform point)
    {
        firePoint = point;
    }


    public override void Attack(GameObject self, Collider collision)
    {
        if(isAttacking)
        {
            if (GetFirePoint() == null && GetPrefab() != null)
            {
                Debug.Log("null firepoint");
                SetFirePoint(GetPrefab().transform.Find("firePoint"));
            }

            if (GetOrbPrefab() == null)
            {
                Debug.Log("Wand projectile not assigned");
                return;
            }

            if (GetFirePoint() != null)
            {
                spawnP = GetFirePoint().position;
                spawnR = GetFirePoint().rotation;
                // Debug.Log("spawn position: " + spawnP);
            }

            GameObject orb = GameObject.Instantiate(orbPrefab, spawnP, spawnR);

            MagicOrb orbScript = orb.GetComponent<MagicOrb>();

            if (orbScript != null)
            {
                orbScript.SetDamage(getWeaponDamage());
            }
        }
        EndAttack();
    }

    public override void StartAttack()
    {
        isAttacking = true;
        // Debug.Log("isattacking");
    }

    public override void EndAttack()
    {
        isAttacking = false;
        // Debug.Log("is NOT attacking");
    }

    public GameObject GetOrbPrefab()
    {
        return orbPrefab;
    }

    public void SetOrbPrefab(GameObject prefab)
    {
        orbPrefab = prefab;
    }

    public Transform GetFirePoint()
    {
        return firePoint;
    }

    public void SetFirePoint(Transform point)
    {
        firePoint = point;
    }
}