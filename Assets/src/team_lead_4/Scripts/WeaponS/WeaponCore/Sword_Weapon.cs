using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Sword : WeaponBase
{
    private bool isAttacking = false;
    public Sword(GameObject prefabType)
    {
        setWeaponName("Sword");
        setWeaponDamage(10);
        setAttackRate(1.5f);
        prefab = prefabType;
        setWeaponTier(1);
        setAugmentName("NONE");
    }

    public override void Attack(GameObject self, Collider collider)
    {
        Debug.Log("insert sword attack here");
        if (isAttacking){

            var health = collider.GetComponent<Health>();

            if (health != null)
            {
                health.TakeDamage(getWeaponDamage());
            }
        }
    }

    public void StartAttack()
    {
        isAttacking = true;
    }

    public void EndAttack()
    {
        isAttacking = false;
    }
}