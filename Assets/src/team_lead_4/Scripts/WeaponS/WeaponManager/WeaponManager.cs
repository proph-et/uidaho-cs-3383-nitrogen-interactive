using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class WeaponManager : MonoBehaviour
{
    public Inventory playerInventory;

    private Dictionary<string, (WeaponBase data, GameObject instance)> weapons =
        new Dictionary<string, (WeaponBase, GameObject)>();

    public Transform weaponHolder;

    private GameObject currentInstance;

    private void Start()
    {
        AddWeapon(playerInventory.getSword());
        AddWeapon(playerInventory.getBow());
        AddWeapon(playerInventory.getWand());

        EquipWeapon(playerInventory.getSword().getName());
    }

    private void Update()
    {
        SetLocation();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipWeapon(playerInventory.getSword().getName());
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EquipWeapon(playerInventory.getBow().getName());
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            EquipWeapon(playerInventory.getWand().getName());
        }

        if (Input.GetMouseButtonDown(0))
        {
            playerInventory.getCurrentWeapon().Attack(this.gameObject);
            // currentWeapon.StartCooldown(this);
        }
    }

    // private void OnTriggerStay(Collider other)
    // {
    //     if(Input.GetMouseButtonDown(0))
    //     {
    //         currentWeapon.Attack(other);
    //     }
    // }

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
        var instance = Instantiate(weapon.prefab, weaponHolder);
        instance.transform.localPosition = Vector3.zero;
        instance.transform.localRotation = Quaternion.identity;
        instance.SetActive(false);
        // weapons = playerInventory.getWeapons()
        weapons[weapon.getName()] = (weapon, instance);

        // Wands
        if (weapon is Wand Wand_Weapon)
        {
            Transform firePoint = instance.transform.Find("firePoint");
            if (firePoint != null)
            {
                Wand_Weapon.SetFirePointWand(firePoint);
            }
        }

        // Bows
        if (weapon is Bow Bow_Weapon)
        {
            Transform firePoint = instance.transform.Find("firePoint");
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
        playerInventory.setCurrentWeapon(data);
        currentInstance = instance;

        Debug.Log($"Equipped {name}");
    }
}