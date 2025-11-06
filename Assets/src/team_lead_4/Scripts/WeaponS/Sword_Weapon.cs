using UnityEngine;
using System.Collections;

public class Sword : WeaponBase
{
    public Sword(GameObject prefabType)
    {
        weaponName = "Sword";
        damage = 10f;
        attackRate = 1.5f;
        prefab = prefabType;
    }

    public override void Attack()
    {
        Debug.Log("insert sword attack here");
    }
}

