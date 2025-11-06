using UnityEngine;
using System.Collections;

public class Wand : WeaponBase
{
    public Wand(GameObject prefabType)
    {
        weaponName = "Wand";
        damage = 10f;
        attackRate = 1.5f;
        prefab = prefabType;
    }

    public override void Attack()
    {
        Debug.Log("insert wand attack here");
    }
}


