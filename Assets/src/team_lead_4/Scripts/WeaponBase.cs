using UnityEngine;
using System.Collections;
public abstract class WeaponBase : MonoBehaviour
{
    public string weaponName = "Default";
    public float damage = 10f;
    public float attackRate = 1f;

    protected bool canAttack = true;

    //lets any weapon type define its own attack behavior (swing projectile etc)
    public abstract void Attack();

    protected IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(1f/ attackRate);
        canAttack = true;
    }
}


