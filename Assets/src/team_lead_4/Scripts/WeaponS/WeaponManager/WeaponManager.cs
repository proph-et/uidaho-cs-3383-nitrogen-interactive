using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class WeaponManager : MonoBehaviour
{
    public Inventory playerInventory;

    private Dictionary<string, (WeaponBase data, GameObject instance)> weapons =
        new Dictionary<string, (WeaponBase, GameObject)>();

    public Transform weaponHolder;
    private bool isAttacking = false;

    private GameObject currentInstance;

    private Collider swordHurtBox;

    private void Start()
    {
        AddWeapon(playerInventory.GetSword());
        AddWeapon(playerInventory.GetBow());
        AddWeapon(playerInventory.GetWand());

        EquipWeapon(playerInventory.GetSword().getName());

        swordHurtBox = playerInventory.GetSword().GetPrefab().GetComponent<Collider>();
    }

    private void Update()
    {
        SetLocation();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipWeapon(playerInventory.GetSword().getName());
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EquipWeapon(playerInventory.GetBow().getName());
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            EquipWeapon(playerInventory.GetWand().getName());
        }

        if (Input.GetMouseButtonDown(0))
        {
            playerInventory.GetCurrentWeapon().StartAttack();

            if (playerInventory.GetCurrentWeapon().getName() != "Sword")
            {
                playerInventory.GetCurrentWeapon().Attack(this.gameObject, null);
            }
            // currentWeapon.StartCooldown(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) return;
        if (other.gameObject.CompareTag("EnemyProjectile")) return;
        if (other.gameObject.CompareTag("NoCollision")) return;
        if (other.gameObject.CompareTag("Enemy"))
        {
            playerInventory.GetSword().Attack(this.gameObject, other);
        }
    }

    private void SetLocation()
    {
        //do stuffff
        if (currentInstance == null) return;

        currentInstance.transform.parent = weaponHolder;
        currentInstance.transform.localPosition = Vector3.zero;
        currentInstance.transform.localRotation = Quaternion.identity;
    }

    private void AddWeapon(WeaponBase weapon)
    {
        var instance = Instantiate(weapon.GetPrefab(), weaponHolder);
        instance.transform.localPosition = Vector3.zero;
        instance.transform.localRotation = Quaternion.identity;
        instance.SetActive(false);
        // weapons = playerInventory.getWeapons()
        weapons[weapon.getName()] = (weapon, instance);

        // Wands
        if (weapon is Wand Wand_Weapon)
        {
            Transform firePoint = playerInventory.GetOwningPlayer().transform;
            if (firePoint != null)
            {
                Wand_Weapon.SetFirePointWand(firePoint);
            }
        }

        // Bows
        if (weapon is Bow Bow_Weapon)
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
        foreach (var kvp in weapons)
            kvp.Value.instance.SetActive(false);

        var (data, instance) = weapons[name];
        instance.SetActive(true);
        playerInventory.SetCurrentWeapon(data);
        currentInstance = instance;

        // Debug.Log($"Equipped {name}");
    }
}