using System.Collections.Generic;
using UnityEngine;


[DefaultExecutionOrder(-100)]
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

    public GameObject owningPlayer;

    private int money;

    private void Awake()
    {
        owningPlayer = GameObject.FindGameObjectWithTag("Player");
        sword = new Sword(swordPrefab);
        bow = new Bow(bowPrefab);
        wand = new Wand(wandPrefab);
        wand.SetOrbPrefab(magicOrbPrefab);
        bow.SetProjectilePrefab(arrowPrefab);
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

    public int getMoney()
    {
        return money;
    }

    public void addMoney(int inputMoney)
    {
        money += inputMoney;
    }

    public void spendMoney(int inputMoney)
    {
        money -= inputMoney;
    }
}