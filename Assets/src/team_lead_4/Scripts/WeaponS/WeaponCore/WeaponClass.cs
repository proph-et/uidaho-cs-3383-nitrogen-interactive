using UnityEngine;
using System.Collections;

public class WeaponBase
{
    private string weaponName = "Default";
    private int damage = 10;
    private float attackRate = 1f;
    private GameObject prefab;
    private int weaponTier;
    private string augmentName;

    protected bool isAttacking = false;

    //lets any weapon type define its own attack behavior (swing projectile etc)
    public virtual void Attack(GameObject self, Collider collider)
    {
        if (isAttacking && collider != null)
        {
            var health = collider.GetComponent<Health>();

            if (health != null)
            {
                health.TakeDamage(getWeaponDamage());
            }
        }
        EndAttack();
    }

    protected virtual GameObject CreateProjectile()
    {
        return null; // default: melee weapons return null
    }

    protected void ConfigureAndLaunch(GameObject projectile, GameObject self)
    {
    }

    public int getWeaponTier()
    {
        return weaponTier;
    }

    public void setWeaponTier(int newWeaponTier)
    {
        weaponTier = newWeaponTier;
    }

    public void upgradeWeapon()
    {
        damage += 5 * weaponTier;
        attackRate += 1 * weaponTier;
        weaponTier++;
    }

    public int getWeaponDamage()
    {
        return damage;
    }

    public void setWeaponDamage(int newDamage)
    {
        damage = newDamage;
    }

    public float getAttackRate()
    {
        return attackRate;
    }

    public void setAttackRate(float newAttackRate)
    {
        attackRate = newAttackRate;
    }

    public string getName()
    {
        return weaponName;
    }

    public void setWeaponName(string newName)
    {
        weaponName = newName;
    }

    public void setAugmentName(string newAugmentName)
    {
        augmentName = newAugmentName;
    }

    public string getAugmentName()
    {
        return augmentName;
    }

    public virtual void StartAttack()
    {
        isAttacking = true;
    }

    public virtual void EndAttack()
    {
        isAttacking = false;
    }

    public GameObject GetPrefab()
    {
        return prefab;
    }

    public void SetPrefab(GameObject Prefab)
    {
        prefab = Prefab;
    }



    // protected IEnumerator AttackCooldown()
    // {
    //     canAttack = false;
    //     yield return new WaitForSeconds(1f/ attackRate);
    //     canAttack = true;
    // }
}