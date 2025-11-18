using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Wand : WeaponBase
{
    private GameObject orbPrefab; // Holds the projectile prefab that the wand will fire.
    private Transform firePoint; // Holds the transform where projectiles spawn from.
    private Vector3 spawnP; // Stores the projectile spawn position.
    private Quaternion spawnR; // Stores the projectile spawn rotation.
    // private float nextAttackTime;

    public Wand(GameObject prefabType)
    {
        setWeaponName("Wand"); // Set the name of the weapon.
        setWeaponDamage(10); // Set how much damage the wand's projectile deals.
        setAttackRate(1.5f); // Set the wand's attack speed.
        SetPrefab(prefabType); // Store the wand's prefab.
        setWeaponTier(1); // Assign the wand's progression tier.
        setAugmentName("NONE"); // No augment active by default.
    }

    public void SetFirePointWand(Transform point)
    {
        firePoint = point; // Assign a fire point specifically for the wand.
    }


    public override void Attack(GameObject self, Collider collision)
    {
        if (isAttacking) // Only attack if the wand is actively performing an attack.
        {
            if (GetFirePoint() == null && GetPrefab() != null) // If we don't have a fire point yet, try to find it on the prefab.
            {
                Debug.Log("null firepoint");
                SetFirePoint(GetPrefab().transform.Find("firePoint"));
            }

            if (GetOrbPrefab() == null) // Ensure we have a projectile prefab assigned.
            {
                Debug.Log("Wand projectile not assigned");
                return;
            }

            if (GetFirePoint() != null) // Cache spawn position and rotation if the fire point exists.
            {
                spawnP = GetFirePoint().position;
                spawnR = GetFirePoint().rotation;
                // Debug.Log("spawn position: " + spawnP);
            }

            GameObject orb = GameObject.Instantiate(orbPrefab, spawnP, spawnR); // Spawn the projectile.

            MagicOrb orbScript = orb.GetComponent<MagicOrb>(); // Try to get the MagicOrb script from the spawned projectile.

            if (orbScript != null)
            {
                orbScript.SetDamage(getWeaponDamage()); // Pass wand damage to the projectile.
            }
        }
        EndAttack(); // End the attack after spawning the projectile.
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
