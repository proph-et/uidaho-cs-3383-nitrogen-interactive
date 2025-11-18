using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponManager : MonoBehaviour
{
    public Inventory playerInventory; // Reference to the player's inventory.

    private Dictionary<string, (WeaponBase data, GameObject instance)> weapons =
        new Dictionary<string, (WeaponBase, GameObject)>(); // Holds each weapon and its spawned instance.

    public Transform weaponHolder; // Holds the transform where weapons are displayed.
    private bool isAttacking = false; // Tracks whether the player is currently attacking.

    private GameObject currentInstance; // Stores the instance of the weapon currently equipped.

    private Collider swordHurtBox; // Holds the sword's hurtbox collider for melee attacks.

    private void Start()
    {
        AddWeapon(playerInventory.GetSword()); // Add the sword to the weapon list.
        AddWeapon(playerInventory.GetBow()); // Add the bow to the weapon list.
        AddWeapon(playerInventory.GetWand()); // Add the wand to the weapon list.

        EquipWeapon(playerInventory.GetSword().getName()); // Start the game with the sword equipped.

        swordHurtBox = playerInventory.GetSword().GetPrefab().GetComponent<Collider>(); // Cache the sword's hurtbox.
    }

    private void Update()
    {
        SetLocation(); // Keep the equipped weapon positioned correctly.

        if (Input.GetKeyDown(KeyCode.Alpha1)) // Equip sword on key 1.
        {
            EquipWeapon(playerInventory.GetSword().getName());
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) // Equip bow on key 2.
        {
            EquipWeapon(playerInventory.GetBow().getName());
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) // Equip wand on key 3.
        {
            EquipWeapon(playerInventory.GetWand().getName());
        }

        if (Input.GetMouseButtonDown(0)) // Left-click to attack.
        {
            playerInventory.GetCurrentWeapon().StartAttack(); // Tell the weapon attack is starting.

            if (playerInventory.GetCurrentWeapon().getName() != "Sword") // Non-melee weapons attack instantly.
            {
                playerInventory.GetCurrentWeapon().Attack(this.gameObject, null);
            }
            // currentWeapon.StartCooldown(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) return; // Ignore player collisions.
        if (other.gameObject.CompareTag("EnemyProjectile")) return; // Ignore enemy projectiles.
        if (other.gameObject.CompareTag("NoCollision")) return; // Ignore non-collision objects.

        if (other.gameObject.CompareTag("Enemy")) // When hitting an enemy, perform sword attack.
        {
            playerInventory.GetSword().Attack(this.gameObject, other);
        }
    }

    private void SetLocation()
    {
        //do stuffff
        if (currentInstance == null) return; // If no weapon is equipped, do nothing.

        currentInstance.transform.parent = weaponHolder; // Keep weapon attached to holder.
        currentInstance.transform.localPosition = Vector3.zero; // Reset position relative to holder.
        currentInstance.transform.localRotation = Quaternion.identity; // Reset rotation relative to holder.
    }

    private void AddWeapon(WeaponBase weapon)
    {
        var instance = Instantiate(weapon.GetPrefab(), weaponHolder); // Spawn a weapon instance under the holder.
        instance.transform.localPosition = Vector3.zero; // Reset spawn position.
        instance.transform.localRotation = Quaternion.identity; // Reset spawn rotation.
        instance.SetActive(false); // Start with weapon hidden.

        weapons[weapon.getName()] = (weapon, instance); // Store weapon data and instance.

        // Wands
        if (weapon is Wand Wand_Weapon) // If this weapon is a wand, assign its fire point.
        {
            Transform firePoint = playerInventory.GetOwningPlayer().transform;
            if (firePoint != null)
            {
                Wand_Weapon.SetFirePointWand(firePoint);
            }
        }

        // Bows
        if (weapon is Bow Bow_Weapon) // If this weapon is a bow, assign its fire point.
        {
            Transform firePoint = playerInventory.GetOwningPlayer().transform;
            if (firePoint != null)
            {
                Bow_Weapon.SetFirePointBow(firePoint);
            }
        }
    }

    private void EquipWeapon(string name)
    {
        foreach (var kvp in weapons) // Hide all weapon instances.
            kvp.Value.instance.SetActive(false);

        var (data, instance) = weapons[name]; // Get the weapon we want to equip.
        instance.SetActive(true); // Show it.
        playerInventory.SetCurrentWeapon(data); // Update the inventory's current weapon.
        currentInstance = instance; // Track which instance is currently equipped.

        // Debug.Log($"Equipped {name}");
    }
}
