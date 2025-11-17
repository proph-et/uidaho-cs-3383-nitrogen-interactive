using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Sword : WeaponBase
{



    public Sword(GameObject prefabType)
    {
        setWeaponName("Sword");
        setWeaponDamage(10);
        setAttackRate(1.5f);
        SetPrefab(prefabType);
        setWeaponTier(1);
        setAugmentName("NONE");
    }

    public override void Attack(GameObject self, Collider collision)
    {
        if (!isAttacking) return;
        if (collision != null)
        {
            Debug.Log($"collision: {collision.name}");

            var health = collision.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(getWeaponDamage());
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

    protected override GameObject CreateProjectile()
    {
        return null; // default: melee weapons return null
    }
}