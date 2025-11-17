using UnityEngine;
using UnityEngine.Serialization;


[DefaultExecutionOrder(-100)]
public class Inventory : MonoBehaviour
{
    private WeaponBase _currentWeapon;

    private Sword _sword;
    private Bow _bow;
    private Wand _wand;

    [SerializeField] private GameObject swordPrefab;
    [SerializeField] private GameObject bowPrefab;
    [SerializeField] private GameObject wandPrefab;
    [SerializeField] private GameObject magicOrbPrefab;
    [SerializeField] private GameObject arrowPrefab;

    [SerializeField] private GameObject owningPlayer;

    private int _money;

    private void Awake()
    {
        owningPlayer = GameObject.FindGameObjectWithTag("Player");
        _sword = new Sword(swordPrefab);
        _bow = new Bow(bowPrefab);
        _bow.SetProjectilePrefab(arrowPrefab);
        _wand = new Wand(wandPrefab);
        _wand.SetOrbPrefab(magicOrbPrefab);
    }

    public GameObject GetPrefab(string targetPrefab)
    {
        switch (targetPrefab)
        {
            case "Sword":
                return swordPrefab;
            case "Bow":
                return bowPrefab;
            case "Wand":
                return wandPrefab;
            case "MagicOrb":
                return magicOrbPrefab;
            case "Arrow":
                return arrowPrefab;
            default:
                return null;
        }
    }

    public GameObject SetTestPrefab(string targetPrefab, GameObject prefab)
    {
        switch (targetPrefab)
        {
            case "Sword":
                return swordPrefab;
            case "Bow":
                return bowPrefab;
            case "Wand":
                return wandPrefab;
            case "MagicOrb":
                return magicOrbPrefab;
            case "Arrow":
                return arrowPrefab;
            default:
                return null;
        }
    }

    public GameObject GetOwningPlayer()
    {
        return owningPlayer;
    }

    public WeaponBase GetCurrentWeapon()
    {
        return _currentWeapon;
    }

    public void SetCurrentWeapon(WeaponBase newWeapon)
    {
        _currentWeapon = newWeapon;
    }

    public Sword GetSword()
    {
        return _sword;
    }

    public Bow GetBow()
    {
        return _bow;
    }

    public Wand GetWand()
    {
        return _wand;
    }

    public int GetMoney()
    {
        return _money;
    }

    public void AddMoney(int inputMoney)
    {
        _money += inputMoney;
    }

    public void SpendMoney(int inputMoney)
    {
        _money -= inputMoney;
    }
}