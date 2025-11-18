using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class Shop : MonoBehaviour
{
    // Parent reference, child object
    [SerializeField] private int discountAmount;
    private DiscountParent _discount;

    private static bool _paused = false;

    [SerializeField] private GameObject shopInterface;

    [SerializeField] public SMScript levelAudioManager;
    [SerializeField] public SMScript shopAudioManager;

    [SerializeField] public Inventory playerInventory;

    private int _swordPrice = 10;
    private int _wandPrice = 10;
    private int _bowPrice = 10;

    private int _augmentPrice = 10;

    [SerializeField] public TextMeshProUGUI swordTierText;
    [SerializeField] public TextMeshProUGUI bowTierText;
    [SerializeField] public TextMeshProUGUI wandTierText;
    [SerializeField] public TextMeshProUGUI swordPriceText;
    [SerializeField] public TextMeshProUGUI bowPriceText;
    [SerializeField] public TextMeshProUGUI wandPriceText;
    [SerializeField] public TextMeshProUGUI swordAugmentText;
    [SerializeField] public TextMeshProUGUI bowAugmentText;
    [SerializeField] public TextMeshProUGUI wandAugmentText;
    [SerializeField] public TextMeshProUGUI swordFireAugmentPriceText;
    [SerializeField] public TextMeshProUGUI bowFireAugmentPriceText;
    [SerializeField] public TextMeshProUGUI wandFireAugmentPriceText;
    [SerializeField] public TextMeshProUGUI swordIceAugmentPriceText;
    [SerializeField] public TextMeshProUGUI bowIceAugmentPriceText;
    [SerializeField] public TextMeshProUGUI wandIceAugmentPriceText;
    [SerializeField] public TextMeshProUGUI moneyText;


    void Start()
    {
        _discount = new DiscountChild(discountAmount);
        // Ensure the game starts in the "Playing" state.
        Time.timeScale = 1f;
        RefreshUI();
    }

    public void CreateDiscount(DiscountChild newDiscountChild)
    {
        _discount = newDiscountChild;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            playerInventory.AddMoney(100);
            RefreshUI();
        }

        // Listen for the Escape key each frame.
        // If pressed, toggle between Paused and Playing states.
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("opened shop");
            if (_paused)
            {
                // If game is currently paused, resume it.
                Play();
            }
            else
            {
                // If game is currently playing, pause it.
                Stop();
            }
        }
    }

    // -------------------------------------------------------------
    // STATE: Transition from "Playing" → "Paused"
    // -------------------------------------------------------------
    public void Stop()
    {
        // Show the pause menu UI.
        shopInterface.SetActive(true);

        // Stop in-game time so everything freezes.
        Time.timeScale = 0f;

        // Update the state flag.
        _paused = true;
        levelAudioManager.pauseBackgroundMusic();

        RefreshUI();
    }

    // -------------------------------------------------------------
    // STATE: Transition from "Paused" → "Playing"
    // -------------------------------------------------------------
    public void Play()
    {
        // Hide the pause menu UI.
        shopInterface.SetActive(false);

        // Resume normal time flow.
        Time.timeScale = 1f;

        // Update the state flag.
        _paused = false;
        levelAudioManager.unpauseBackgroundMusic();
    }


    public void UpgradeSword()
    {
        int discountedPrice = _discount.ApplyDiscount(_swordPrice);

        if (playerInventory.GetMoney() >= discountedPrice)
        {
            playerInventory.GetSword().upgradeWeapon();
            playerInventory.SpendMoney(discountedPrice);
            _swordPrice += 5 * playerInventory.GetSword().getWeaponTier();
        }
        else
        {
            shopAudioManager.ErrorSound();
            Debug.Log("Broke");
        }

        RefreshUI();
    }

    public void UpgradeBow()
    {
        int discountedPrice = _discount.ApplyDiscount(_bowPrice);

        if (playerInventory.GetMoney() >= discountedPrice)
        {
            playerInventory.GetBow().upgradeWeapon();
            playerInventory.SpendMoney(discountedPrice);
            _bowPrice += 5 * playerInventory.GetBow().getWeaponTier();
        }
        else
        {
            shopAudioManager.ErrorSound();
            Debug.Log("Broke");
        }

        RefreshUI();
    }

    public void UpgradeWand()
    {
        int discountedPrice = _discount.ApplyDiscount(_wandPrice);

        if (playerInventory.GetMoney() >= discountedPrice)
        {
            playerInventory.GetWand().upgradeWeapon();
            playerInventory.SpendMoney(discountedPrice);
            _wandPrice += 5 * playerInventory.GetWand().getWeaponTier();
        }
        else
        {
            shopAudioManager.ErrorSound();
            Debug.Log("Broke");
        }

        RefreshUI();
    }

    public void fireSword()
    {
        if (playerInventory.GetSword().getAugmentName() == "Fire")
        {
            shopAudioManager.ErrorSound();
            return;
        }

        int discountedPrice = _discount.ApplyDiscount(_augmentPrice);


        if (playerInventory.GetMoney() >= discountedPrice)
        {
            playerInventory.SpendMoney(discountedPrice);
            playerInventory.GetSword().setAugmentName("Fire");
        }
        else
        {
            shopAudioManager.ErrorSound();
            Debug.Log("Broke");
        }

        RefreshUI();
    }

    public void iceSword()
    {
        if (playerInventory.GetSword().getAugmentName() == "Ice")
        {
            shopAudioManager.ErrorSound();
            return;
        }

        int discountedPrice = _discount.ApplyDiscount(_augmentPrice);

        if (playerInventory.GetMoney() >= discountedPrice)
        {
            playerInventory.SpendMoney(discountedPrice);
            playerInventory.GetSword().setAugmentName("Ice");
        }
        else
        {
            shopAudioManager.ErrorSound();
            Debug.Log("Broke");
        }

        RefreshUI();
    }

    public void fireBow()
    {
        if (playerInventory.GetBow().getAugmentName() == "Fire")
        {
            shopAudioManager.ErrorSound();
            return;
        }

        int discountedPrice = _discount.ApplyDiscount(_augmentPrice);


        if (playerInventory.GetMoney() >= discountedPrice)
        {
            playerInventory.SpendMoney(discountedPrice);
            playerInventory.GetBow().setAugmentName("Fire");
        }
        else
        {
            shopAudioManager.ErrorSound();
            Debug.Log("Broke");
        }

        RefreshUI();
    }

    public void iceBow()
    {
        if (playerInventory.GetBow().getAugmentName() == "Ice")
        {
            shopAudioManager.ErrorSound();
            return;
        }

        int discountedPrice = _discount.ApplyDiscount(_augmentPrice);

        if (playerInventory.GetMoney() >= discountedPrice)
        {
            playerInventory.SpendMoney(discountedPrice);
            playerInventory.GetBow().setAugmentName("Ice");
        }
        else
        {
            shopAudioManager.ErrorSound();
            Debug.Log("Broke");
        }

        RefreshUI();
    }

    public void fireWand()
    {
        if (playerInventory.GetWand().getAugmentName() == "Fire")
        {
            shopAudioManager.ErrorSound();
            return;
        }

        int discountedPrice = _discount.ApplyDiscount(_augmentPrice);

        if (playerInventory.GetMoney() >= discountedPrice)
        {
            playerInventory.SpendMoney(discountedPrice);
            playerInventory.GetWand().setAugmentName("Fire");
        }
        else
        {
            shopAudioManager.ErrorSound();
            Debug.Log("Broke");
        }

        RefreshUI();
    }

    public void iceWand()
    {
        if (playerInventory.GetWand().getAugmentName() == "Ice")
        {
            shopAudioManager.ErrorSound();
            return;
        }

        int discountedPrice = _discount.ApplyDiscount(_augmentPrice);

        if (playerInventory.GetMoney() >= discountedPrice)
        {
            playerInventory.SpendMoney(discountedPrice);
            playerInventory.GetWand().setAugmentName("Ice");
        }
        else
        {
            shopAudioManager.ErrorSound();
            Debug.Log("Broke");
        }

        RefreshUI();
    }

    public void removeSwordAugment()
    {
        if (playerInventory.GetSword().getAugmentName() == "NONE")
        {
            shopAudioManager.ErrorSound();
            return;
        }

        playerInventory.GetSword().removeAugment();
        RefreshUI();
    }


    public void removeBowAugment()
    {
        if (playerInventory.GetBow().getAugmentName() == "NONE")
        {
            shopAudioManager.ErrorSound();
            return;
        }

        playerInventory.GetBow().removeAugment();
        RefreshUI();
    }


    public void removeWandAugment()
    {
        if (playerInventory.GetWand().getAugmentName() == "NONE")
        {
            shopAudioManager.ErrorSound();
            return;
        }

        playerInventory.GetWand().removeAugment();
        RefreshUI();
    }

    public void RefreshUI()
    {
        swordTierText.text = $"Tier: {playerInventory.GetSword().getWeaponTier()}";
        bowTierText.text = $"Tier: {playerInventory.GetBow().getWeaponTier()}";
        wandTierText.text = $"Tier: {playerInventory.GetWand().getWeaponTier()}";

        int discountedSwordPrice = _discount.ApplyDiscount(_swordPrice);
        swordPriceText.text = $"{discountedSwordPrice}";

        int discountedBowPrice = _discount.ApplyDiscount(_bowPrice);
        bowPriceText.text = $"{discountedBowPrice}";

        int discountedWandPrice = _discount.ApplyDiscount(_wandPrice);
        wandPriceText.text = $"{discountedWandPrice}";

        if (playerInventory.GetSword().getAugmentName() != "NONE")
        {
            swordAugmentText.text = $"{playerInventory.GetSword().getAugmentName()}\nClick To Remove";
        }
        else
        {
            swordAugmentText.text = "No Augment";
        }

        if (playerInventory.GetBow().getAugmentName() != "NONE")
        {
            bowAugmentText.text = $"{playerInventory.GetBow().getAugmentName()}\nClick To Remove";
        }
        else
        {
            bowAugmentText.text = "No Augment";
        }


        if (playerInventory.GetWand().getAugmentName() != "NONE")
        {
            wandAugmentText.text = $"{playerInventory.GetWand().getAugmentName()}\nClick To Remove";
        }
        else
        {
            wandAugmentText.text = "No Augment";
        }


        int discountedAugmentPrice = _discount.ApplyDiscount(_augmentPrice);

        swordFireAugmentPriceText.text = $"{discountedAugmentPrice}";
        bowFireAugmentPriceText.text = $"{discountedAugmentPrice}";
        wandFireAugmentPriceText.text = $"{discountedAugmentPrice}";

        swordIceAugmentPriceText.text = $"{discountedAugmentPrice}";
        bowIceAugmentPriceText.text = $"{discountedAugmentPrice}";
        wandIceAugmentPriceText.text = $"{discountedAugmentPrice}";

        moneyText.text = $"Dough: {playerInventory.GetMoney()}";
    }
}