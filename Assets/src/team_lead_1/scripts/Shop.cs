using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    // Parent reference, child object
    DiscountParent discount = new DiscountChild(0.2f);
    
    public static bool Paused = false;

    // Reference to the pause menu UI Canvas.
    public GameObject ShopInterface;

    public SMScript levelAudioManager;
    public SMScript shopAudioManager;

    public Inventory playerInventory;

    private int _swordPrice = 10;
    private int _wandPrice = 10;
    private int _bowPrice = 10;

    private int _augmentPrice = 10;

    public TextMeshProUGUI swordTierText;
    public TextMeshProUGUI bowTierText;
    public TextMeshProUGUI wandTierText;

    public TextMeshProUGUI swordPriceText;
    public TextMeshProUGUI bowPriceText;
    public TextMeshProUGUI wandPriceText;

    public TextMeshProUGUI swordAugmentText;
    public TextMeshProUGUI bowAugmentText;
    public TextMeshProUGUI wandAugmentText;

    public TextMeshProUGUI swordFireAugmentPriceText;
    public TextMeshProUGUI bowFireAugmentPriceText;
    public TextMeshProUGUI wandFireAugmentPriceText;

    public TextMeshProUGUI swordIceAugmentPriceText;
    public TextMeshProUGUI bowIceAugmentPriceText;
    public TextMeshProUGUI wandIceAugmentPriceText;

    public TextMeshProUGUI moneyText;


    void Start()
    {
        // Ensure the game starts in the "Playing" state.
        Time.timeScale = 1f;
        RefreshUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerInventory.addMoney(100);
            RefreshUI();
        }

        // Listen for the Escape key each frame.
        // If pressed, toggle between Paused and Playing states.
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("opened shop");
            if (Paused)
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
        ShopInterface.SetActive(true);

        // Stop in-game time so everything freezes.
        Time.timeScale = 0f;

        // Update the state flag.
        Paused = true;
        levelAudioManager.pauseBackgroundMusic();

        RefreshUI();
    }

    // -------------------------------------------------------------
    // STATE: Transition from "Paused" → "Playing"
    // -------------------------------------------------------------
    public void Play()
    {
        // Hide the pause menu UI.
        ShopInterface.SetActive(false);

        // Resume normal time flow.
        Time.timeScale = 1f;

        // Update the state flag.
        Paused = false;
        levelAudioManager.unpauseBackgroundMusic();
    }


    public void UpgradeSword()
    {
        int discountedPrice = (int)discount.apply_discount(_swordPrice);

        if (playerInventory.getMoney() >= discountedPrice)
        {
            playerInventory.getSword().upgradeWeapon();
            playerInventory.spendMoney(discountedPrice);
            _swordPrice += 5 * playerInventory.getSword().getWeaponTier();
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
        int discountedPrice = (int)discount.apply_discount(_bowPrice);

        if (playerInventory.getMoney() >= discountedPrice)
        {
            playerInventory.getBow().upgradeWeapon();
            playerInventory.spendMoney(discountedPrice);
            _bowPrice += 5 * playerInventory.getBow().getWeaponTier();
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
        int discountedPrice = (int)discount.apply_discount(_wandPrice);

        if (playerInventory.getMoney() >= discountedPrice)
        {
            playerInventory.getWand().upgradeWeapon();
            playerInventory.spendMoney(discountedPrice);
            _wandPrice += 5 * playerInventory.getWand().getWeaponTier();
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
        if (playerInventory.getSword().getAugmentName() == "Fire")
        {
            shopAudioManager.ErrorSound();
            return;
        }

        int discountedPrice = (int)discount.apply_discount(_augmentPrice);


        if (playerInventory.getMoney() >= discountedPrice)
        {
            playerInventory.spendMoney(discountedPrice);
            // playerInventory.getSword().addAugment("Fire");
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
        if (playerInventory.getSword().getAugmentName() == "Ice")
        {
            shopAudioManager.ErrorSound();
            return;
        }

        int discountedPrice = (int)discount.apply_discount(_augmentPrice);

        if (playerInventory.getMoney() >= discountedPrice)
        {
            playerInventory.spendMoney(discountedPrice);
            // playerInventory.getSword().addAugment("Ice");
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
        if (playerInventory.getSword().getAugmentName() == "Fire")
        {
            shopAudioManager.ErrorSound();
            return;
        }

        int discountedPrice = (int)discount.apply_discount(_augmentPrice);


        if (playerInventory.getMoney() >= discountedPrice)
        {
            playerInventory.spendMoney(discountedPrice);
            // playerInventory.getBow().addAugment("Fire");
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
        if (playerInventory.getSword().getAugmentName() == "Ice")
        {
            shopAudioManager.ErrorSound();
            return;
        }

        int discountedPrice = (int)discount.apply_discount(_augmentPrice);


        if (playerInventory.getMoney() >= discountedPrice)
        {
            playerInventory.spendMoney(discountedPrice);
            // playerInventory.getBow().addAugment("Ice");
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
        if (playerInventory.getSword().getAugmentName() == "Fire")
        {
            shopAudioManager.ErrorSound();
            return;
        }

        int discountedPrice = (int)discount.apply_discount(_augmentPrice);

        if (playerInventory.getMoney() >= discountedPrice)
        {
            playerInventory.spendMoney(discountedPrice);
            // playerInventory.getWand().addAugment("Fire");
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
        if (playerInventory.getSword().getAugmentName() == "Ice")
        {
            shopAudioManager.ErrorSound();
            return;
        }

        int discountedPrice = (int)discount.apply_discount(_augmentPrice);

        if (playerInventory.getMoney() >= discountedPrice)
        {
            playerInventory.spendMoney(discountedPrice);
            // playerInventory.getWand().addAugment("Ice");
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
        if (playerInventory.getSword().getAugmentName() == "NONE")
        {
            shopAudioManager.ErrorSound();
            return;
        }

        // playerInventory.getSword().removeAugment();
        RefreshUI();
    }


    public void removeBowAugment()
    {
        if (playerInventory.getSword().getAugmentName() == "NONE")
        {
            shopAudioManager.ErrorSound();
            return;
        }

        // playerInventory.getSword().removeAugment();
        RefreshUI();
    }


    public void removeWandAugment()
    {
        if (playerInventory.getSword().getAugmentName() == "NONE")
        {
            shopAudioManager.ErrorSound();
            return;
        }

        // playerInventory.getSword().removeAugment();
        RefreshUI();
    }

    public void RefreshUI()
    {
        swordTierText.text = $"Tier: {playerInventory.getSword().getWeaponTier()}";
        bowTierText.text = $"Tier: {playerInventory.getBow().getWeaponTier()}";
        wandTierText.text = $"Tier: {playerInventory.getWand().getWeaponTier()}";

        int discountedSwordPrice = (int)discount.apply_discount(_swordPrice);
        swordPriceText.text = $"{discountedSwordPrice}";

        int discountedBowPrice = (int)discount.apply_discount(_bowPrice);
        bowPriceText.text = $"{discountedBowPrice}";

        int discountedWandPrice = (int)discount.apply_discount(_wandPrice);
        wandPriceText.text = $"{discountedWandPrice}";

        if (playerInventory.getSword().getAugmentName() != "NONE")
        {
            swordAugmentText.text = $"{playerInventory.getSword().getAugmentName()}\nClick To Remove";
        }
        else
        {
            swordAugmentText.text = "No Augment";
        }

        if (playerInventory.getSword().getAugmentName() != "NONE")
        {
            bowAugmentText.text = $"{playerInventory.getBow().getAugmentName()}\nClick To Remove";
        }
        else
        {
            bowAugmentText.text = "No Augment";
        }


        if (playerInventory.getSword().getAugmentName() != "NONE")
        {
            bowAugmentText.text = $"{playerInventory.getBow().getAugmentName()}\nClick To Remove";
        }
        else
        {
            wandAugmentText.text = "No Augment";
        }


        swordFireAugmentPriceText.text = $"{_augmentPrice}";
        bowFireAugmentPriceText.text = $"{_augmentPrice}";
        wandFireAugmentPriceText.text = $"{_augmentPrice}";

        swordIceAugmentPriceText.text = $"{_augmentPrice}";
        bowIceAugmentPriceText.text = $"{_augmentPrice}";
        wandIceAugmentPriceText.text = $"{_augmentPrice}";

        moneyText.text = $"Dough: {playerInventory.getMoney()}";
    }
}