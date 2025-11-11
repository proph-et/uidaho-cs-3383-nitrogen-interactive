using UnityEngine;
using System.Collections;

public class Wand : WeaponBase
{
    public Wand(GameObject prefabType)
    {
        weaponName = "Wand";
        damage = 10;
        attackRate = 1.5f;
        prefab = prefabType;
    }

    public override void Attack(Collider other)
    {
        Debug.Log("insert wand attack here");
    }
}


