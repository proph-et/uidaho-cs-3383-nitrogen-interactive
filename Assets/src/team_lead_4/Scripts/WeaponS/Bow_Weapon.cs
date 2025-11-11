using UnityEngine;
using System.Collections;

public class Bow : WeaponBase
{
    public Bow(GameObject prefabType)
    {
        weaponName = "Bow";
        damage = 10;
        attackRate = 1.5f;
        prefab = prefabType;
    }

    public override void Attack(Collider other)
    {
        Debug.Log("insert bow attack here");
    }
}


