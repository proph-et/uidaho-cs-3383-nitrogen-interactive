using UnityEngine;
using System.Collections;

public class WeaponBase
{
    public string weaponName = "Default";
    public int damage = 10;
    public float attackRate = 1f;
    public GameObject prefab;

    protected bool canAttack = true;

    //lets any weapon type define its own attack behavior (swing projectile etc)
    public virtual void Attack(GameObject self)
    {
        Debug.Log("attacking...");
    }

    // protected IEnumerator AttackCooldown()
    // {
    //     canAttack = false;
    //     yield return new WaitForSeconds(1f/ attackRate);
    //     canAttack = true;
    // }
}



