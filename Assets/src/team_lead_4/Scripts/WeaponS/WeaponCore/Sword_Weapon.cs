using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Sword : WeaponBase
{
    public Sword(GameObject prefabType)
    {
        setWeaponName("Sword"); // Set the weapon's display name.
        setWeaponDamage(10); // Set how much damage the sword deals.
        setAttackRate(1.5f); // Set how fast the sword can attack (attacks per second).
        SetPrefab(prefabType); // Store the prefab associated with this weapon.
        setWeaponTier(1); // Assign the sword's progression tier.
        setAugmentName("NONE"); // No augment applied to the sword by default.
    }

    public override void Attack(GameObject self, Collider collider)
    {
        if (isAttacking && collider != null) // Ensure we are attacking and hit a valid target.
        {
            // Debug.Log("insert sword attack here");
            var health = collider.GetComponent<Health>(); // Try to get the health component of what we hit.

            if (health != null)
            {
                health.TakeDamage(getWeaponDamage()); // Deal damage if the target has health.
            }
        }
        EndAttack(); // Finish the attack after dealing damage.
    }

    public override void StartAttack()
    {
        isAttacking = true; // Mark that the sword has started its attack swing.
        // Debug.Log("isattacking");
    }

    public override void EndAttack()
    {
        isAttacking = false; // Mark that we are no longer attacking.
        // Debug.Log("is NOT attacking");
    }

    protected override GameObject CreateProjectile()
    {
        return null; // Melee weapons do not create projectiles.
    }
}
