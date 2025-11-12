using UnityEngine;
using System.Collections;

public class Bow : WeaponBase
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    Vector3 spawnP;
    Quaternion spawnR;
    Rigidbody arrowRB;

    public Bow(GameObject prefabType)
    {
        weaponName = "Bow";
        damage = 10;
        attackRate = 1.5f;
        prefab = prefabType;
    }

    public void SetFirePointBow(Transform point)
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

        if (projectilePrefab == null)
        {
            Debug.Log("Bow projectile not assigned");
            return;
        }

        if (firePoint != null)
        {
            spawnP = firePoint.position;
            spawnR = firePoint.rotation;
            // Debug.Log("spawn position: " + spawnP);
        }

        GameObject arrow = GameObject.Instantiate(projectilePrefab, spawnP, spawnR);

        Arrow arrowScript = arrow.GetComponent<Arrow>();

        if (arrowScript != null)
        {
            arrowRB = arrowScript.GetArrowRB();
            float arrowSpeed = arrowScript.GetArrowSpeed();
            Collider arrowCollider = arrowScript.GetComponent<Collider>();
            Collider bowCollider = self.GetComponent<Collider>();

            Physics.IgnoreCollision(arrowCollider, bowCollider, true);
        
            arrowRB.linearVelocity = firePoint.forward * arrowSpeed;
            Debug.Log("arrow linear vel: "+ arrowRB.linearVelocity);

            arrowScript.damage = damage;
        }
    }
}


