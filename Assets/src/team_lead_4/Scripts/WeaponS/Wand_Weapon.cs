using UnityEngine;
using System.Collections;

public class Wand : WeaponBase
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    Vector3 spawnP;
    Quaternion spawnR;
    // private float nextAttackTime;

    public Wand(GameObject prefabType)
    {
        weaponName = "Wand";
        damage = 10;
        attackRate = 1.5f;
        prefab = prefabType;
    }

    public void SetFirePoint(Transform point)
    {
        firePoint = point;
    }


    public override void Attack()
    {


        if (firePoint == null && prefab != null)
        {
            Debug.Log("null firepoint");
            firePoint = prefab.transform.Find("firePoint");
        }

        if (projectilePrefab == null)
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

        GameObject orb = GameObject.Instantiate(projectilePrefab, spawnP, spawnR);

        MagicOrb orbScript = orb.GetComponent<MagicOrb>();

        if (orbScript != null)
        {
            orbScript.damage = damage;
        }

    }
}


