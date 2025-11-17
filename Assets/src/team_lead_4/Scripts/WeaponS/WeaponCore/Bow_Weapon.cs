using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Bow : WeaponBase
{
    private GameObject projectilePrefab;
    private Transform firePoint;
    private Vector3 spawnP;
    private Quaternion spawnR;
    private Rigidbody arrowRB;
    private GameObject arrow;

    public Bow(GameObject prefabType)
    {
        setWeaponName("Bow");
        setWeaponDamage(20);
        setAttackRate(1.5f);
        SetPrefab(prefabType);
        setWeaponTier(1);
        setAugmentName("NONE");
    }

    public void SetFirePointBow(Transform point)
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

            if (GetProjectilePrefab() == null)
            {
                Debug.Log("Bow projectile not assigned");
                return;
            }

            if (GetFirePoint() != null)
            {
                arrow = CreateProjectile();
                // Debug.Log("spawn position: " + spawnP);
            }

            Arrow arrowScript = arrow.GetComponent<Arrow>();

            if (arrowScript != null)
            {
                arrowRB = arrowScript.GetArrowRB();
                float arrowSpeed = arrowScript.GetArrowSpeed();
                Collider arrowCollider = arrowScript.GetComponent<Collider>();
                Collider bowCollider = self.GetComponent<Collider>();

                Physics.IgnoreCollision(arrowCollider, bowCollider, true);

                arrowRB.linearVelocity = GetFirePoint().forward * arrowSpeed;
                // Debug.Log("arrow linear vel: " + arrowRB.linearVelocity);

                arrowScript.SetDamage(getWeaponDamage());
            }
        }
        EndAttack();
    }

    protected override GameObject CreateProjectile()
    {
        spawnP = GetFirePoint().position;
        spawnR = GetFirePoint().rotation;

        GameObject arrow = GameObject.Instantiate(GetProjectilePrefab(), spawnP, spawnR);
        return arrow;
    }

    public override void StartAttack()
    {
        isAttacking = true;
    }

    public override void EndAttack()
    {
        isAttacking = false;
    }

    public GameObject GetProjectilePrefab()
    {
        return projectilePrefab;
    }

    public void SetProjectilePrefab(GameObject prefab)
    {
        projectilePrefab = prefab;
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