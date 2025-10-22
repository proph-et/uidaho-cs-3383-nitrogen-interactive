using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public Transform weaponSlot;
    private GameObject weapon;

    public void equipWeapon(GameObject weaponPrefab)
    {
        
        if (weapon != null)
        {
            Debug.Log("destroying og");
            Destroy(weapon);

        }

        weapon = Instantiate(weaponPrefab, weaponSlot, false);
        Debug.Log ("weapon grabbed");

    }
    
}
