using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private WeaponBase currentWeapon;

    private Sword sword;
    private Bow bow;
    private Wand wand;

    public GameObject swordPrefab;
    public GameObject bowPrefab;
    public GameObject wandPrefab;
    public GameObject magicOrbPrefab;
    public GameObject arrowPrefab;

    private void Start()
    {
        sword = new Sword(swordPrefab);
        bow = new Bow(bowPrefab);
        wand = new Wand(wandPrefab);
        wand.orbPrefab = magicOrbPrefab;
        bow.projectilePrefab = arrowPrefab;
    }

    public WeaponBase getCurrentWeapon()
    {
        return currentWeapon;
    }

    public void setCurrentWeapon(WeaponBase newWeapon)
    {
        currentWeapon = newWeapon;
    }

    public Sword getSword()
    {
        return sword;
    }

    public Bow getBow()
    {
        return bow;
    }

    public Wand getWand()
    {
        return wand;
    }

    // public void AddItem(Item item)
    // {
    //     if (item != null)
    //     {
    //         items.Add(item);
    //         Debug.Log("Added item: " + item.itemName);
    //     }
    // }
}