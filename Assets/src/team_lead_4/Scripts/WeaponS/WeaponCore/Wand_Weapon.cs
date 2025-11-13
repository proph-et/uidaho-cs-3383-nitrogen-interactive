using UnityEngine;
using System.Collections;

public class Wand : WeaponBase
{
    public GameObject orbPrefab;
    public Transform firePoint;
    Vector3 spawnP;
    Quaternion spawnR;
    // private float nextAttackTime;

    public Wand(GameObject prefabType)
    {
        setWeaponName("Wand");
        setWeaponDamage(10);
        setAttackRate(1.5f);
        prefab = prefabType;
        setWeaponTier(1);
    }

    public void SetFirePointWand(Transform point)
    {
        firePoint = point;
    }


    public override void Attack(GameObject self)
    {
        if (firePoint == null && prefab != null)
        {
            Debug.Log("null firepoint");
            firePoint = prefab.transform.Find("firePoint");
        }

        if (orbPrefab == null)
        {
            Debug.Log("Wand projectile not assigned");
            return;
        }

        if (firePoint != null)
        {
            spawnP = firePoint.position;
            spawnR = firePoint.rotation;
            Debug.Log("spawn position: " + spawnP);
        }

        GameObject orb = GameObject.Instantiate(orbPrefab, spawnP, spawnR);

        MagicOrb orbScript = orb.GetComponent<MagicOrb>();

        if (orbScript != null)
        {
            orbScript.damage = getWeaponDamage();
        }
    }
}