using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class WeaponManager : MonoBehaviour
{
    public GameObject swordPrefab;
    public GameObject bowPrefab;
    public GameObject wandPrefab;

    private Dictionary<string, (WeaponBase data, GameObject instance)> weapons = new Dictionary<string, (WeaponBase, GameObject)>();

    public Transform weaponHolder;

    private WeaponBase currentWeapon;
    private GameObject currentInstance;

    private Sword sword;
    private Bow bow;
    private Wand wand;

    private void Start()
    {
        sword = new Sword(swordPrefab);
        bow = new Bow(bowPrefab);
        wand = new Wand(wandPrefab);


        AddWeapon(sword);
        AddWeapon(bow);
        AddWeapon(wand);

        EquipWeapon("Sword");
    }

    private void Update()
    {
        SetLocation();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipWeapon("Sword");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EquipWeapon("Bow");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            EquipWeapon("Wand");
        }

        // if (Input.GetMouseButtonDown(0))
        // {
        //     currentWeapon.Attack();
        //     // currentWeapon.StartCooldown(this);
        // }
    }

    private void OnTriggerStay(Collider other)
    {
        if(Input.GetMouseButtonDown(0))
        {
            currentWeapon.Attack(other);
        }
    }

    private void SetLocation()
    {
        //do stuffff

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
        weapons[weapon.weaponName] = (weapon, instance);
    }

    private void EquipWeapon(string name)
    {
        foreach (var kvp in weapons)
            kvp.Value.instance.SetActive(false);

        var (data, instance) = weapons[name];
        instance.SetActive(true);
        currentWeapon = data;
        currentInstance = instance;

        Debug.Log($"Equipped {name}");


    }
    
}
