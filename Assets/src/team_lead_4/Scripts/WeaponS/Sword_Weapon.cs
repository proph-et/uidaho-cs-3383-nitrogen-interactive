using UnityEngine;
using System.Collections;

public class Sword : WeaponBase
{
    public Sword(GameObject prefabType)
    {
        weaponName = "Sword";
        damage = 10;
        attackRate = 1.5f;
        prefab = prefabType;
    }

    public override void Attack(GameObject self)
    {
        Debug.Log("insert sword attack here");

        // if (other == null)
        // {
        //     Debug.Log("other is null");
        // }

        // Enemy enemy = other.GetComponent<Enemy>();
        // if (enemy != null)
        // {
        //     enemy.TakeDamage(damage);
        //     Debug.Log($"Sword hit {enemy.name} for {damage} damage!");
        // }

    }
}

