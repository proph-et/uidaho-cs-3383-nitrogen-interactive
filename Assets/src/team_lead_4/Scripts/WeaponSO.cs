using UnityEngine;

[CreateAssetMenu(fileName = "New sword collectable", menuName = "Collectable/Weapon")]
public class WeaponSO : CollectableSOBase
{
    public GameObject weaponPrefab;

    public override void Collect(GameObject objectThatCollected)
    {
        Debug.Log("collecting a weapon");

        WeaponHolder holder = objectThatCollected.GetComponent<WeaponHolder>();
        
        
        if (holder != null && weaponPrefab != null)
        {
            Debug.Log("equipping weapon");
            holder.equipWeapon(weaponPrefab);
        }
    }
}
