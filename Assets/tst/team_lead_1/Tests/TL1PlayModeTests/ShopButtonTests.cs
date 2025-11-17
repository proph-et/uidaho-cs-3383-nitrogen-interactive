using NUnit.Framework;
using UnityEngine;
using TMPro;

public class ShopTests
{
    private Shop _shop;
    private Inventory _fakeInventory;

    [SetUp]
    public void Setup()
    {
        var go = new GameObject();
        _shop = go.AddComponent<Shop>();
        _shop.CreateDiscount(new DiscountChild(5));

        // Fake inventory with enough money
        _fakeInventory = go.AddComponent<Inventory>();
        var swordPrefab = new GameObject("SwordPrefab");
        swordPrefab.AddComponent<BoxCollider>();
        _fakeInventory.SetTestPrefab("Sword", swordPrefab);
        _fakeInventory.SetTestPrefab("Bow", new GameObject("BowPrefab"));
        _fakeInventory.SetTestPrefab("Wand", new GameObject("WandPrefab"));
        _fakeInventory.SetTestPrefab("MagicOrb", new GameObject("MagicOrbPrefab"));
        _fakeInventory.SetTestPrefab("Arrow", new GameObject("ArrowPrefab"));

        _shop.playerInventory = _fakeInventory;

        // Stub audio managers
        _shop.shopAudioManager = go.AddComponent<SMScript>();
        _shop.levelAudioManager = go.AddComponent<SMScript>();

        _shop.swordTierText = new GameObject().AddComponent<TextMeshProUGUI>();
        _shop.bowTierText = new GameObject().AddComponent<TextMeshProUGUI>();
        _shop.wandTierText = new GameObject().AddComponent<TextMeshProUGUI>();

        _shop.swordPriceText = new GameObject().AddComponent<TextMeshProUGUI>();
        _shop.bowPriceText = new GameObject().AddComponent<TextMeshProUGUI>();
        _shop.wandPriceText = new GameObject().AddComponent<TextMeshProUGUI>();

        _shop.swordAugmentText = new GameObject().AddComponent<TextMeshProUGUI>();
        _shop.bowAugmentText = new GameObject().AddComponent<TextMeshProUGUI>();
        _shop.wandAugmentText = new GameObject().AddComponent<TextMeshProUGUI>();

        _shop.swordFireAugmentPriceText = new GameObject().AddComponent<TextMeshProUGUI>();
        _shop.bowFireAugmentPriceText = new GameObject().AddComponent<TextMeshProUGUI>();
        _shop.wandFireAugmentPriceText = new GameObject().AddComponent<TextMeshProUGUI>();

        _shop.swordIceAugmentPriceText = new GameObject().AddComponent<TextMeshProUGUI>();
        _shop.bowIceAugmentPriceText = new GameObject().AddComponent<TextMeshProUGUI>();
        _shop.wandIceAugmentPriceText = new GameObject().AddComponent<TextMeshProUGUI>();

        _shop.moneyText = new GameObject().AddComponent<TextMeshProUGUI>();
    }

    [Test]
    public void UpgradeSword_SpendsMoneyAndIncreasesTier()
    {
        // start with money
        _fakeInventory.AddMoney(100);
        int initialTier = _fakeInventory.GetSword().getWeaponTier();
        int initialMoney = _fakeInventory.GetMoney();

        _shop.UpgradeSword();

        Assert.Greater(_fakeInventory.GetSword().getWeaponTier(), initialTier);
        Assert.Less(_fakeInventory.GetMoney(), initialMoney);
    }

    [Test]
    public void UpgradeSword_NoMoney_SameMoneyAndTier()
    {
        int initialTier = _fakeInventory.GetSword().getWeaponTier();
        int initialMoney = _fakeInventory.GetMoney();

        _shop.UpgradeSword();

        Assert.AreEqual(_fakeInventory.GetSword().getWeaponTier(), initialTier);
        Assert.AreEqual(_fakeInventory.GetMoney(), initialMoney);
    }

    [Test]
    public void UpgradeBow_SpendsMoneyAndIncreasesTier()
    {
        // start with money
        _fakeInventory.AddMoney(100);
        int initialTier = _fakeInventory.GetBow().getWeaponTier();
        int initialMoney = _fakeInventory.GetMoney();

        _shop.UpgradeBow();

        Assert.Greater(_fakeInventory.GetBow().getWeaponTier(), initialTier);
        Assert.Less(_fakeInventory.GetMoney(), initialMoney);
    }

    [Test]
    public void UpgradeBow_NoMoney_SameMoneyAndTier()
    {
        int initialTier = _fakeInventory.GetBow().getWeaponTier();
        int initialMoney = _fakeInventory.GetMoney();

        _shop.UpgradeBow();

        Assert.AreEqual(_fakeInventory.GetBow().getWeaponTier(), initialTier);
        Assert.AreEqual(_fakeInventory.GetMoney(), initialMoney);
    }

    [Test]
    public void UpgradeWand_SpendsMoneyAndIncreasesTier()
    {
        // start with money
        _fakeInventory.AddMoney(100);
        int initialTier = _fakeInventory.GetWand().getWeaponTier();
        int initialMoney = _fakeInventory.GetMoney();

        _shop.UpgradeWand();

        Assert.Greater(_fakeInventory.GetWand().getWeaponTier(), initialTier);
        Assert.Less(_fakeInventory.GetMoney(), initialMoney);
    }

    [Test]
    public void UpgradeWand_NoMoney_SameMoneyAndTier()
    {
        int initialTier = _fakeInventory.GetWand().getWeaponTier();
        int initialMoney = _fakeInventory.GetMoney();

        _shop.UpgradeWand();

        Assert.AreEqual(_fakeInventory.GetWand().getWeaponTier(), initialTier);
        Assert.AreEqual(_fakeInventory.GetMoney(), initialMoney);
    }


    [Test]
    public void FireSword_SpendsMoneyAndAddsNewAugment()
    {
        // start with money
        _fakeInventory.AddMoney(100);
        string initialAugment = _fakeInventory.GetSword().getAugmentName();
        int initialMoney = _fakeInventory.GetMoney();

        _shop.fireSword();

        Assert.AreNotEqual(_fakeInventory.GetSword().getAugmentName(), initialAugment);
        Assert.Less(_fakeInventory.GetMoney(), initialMoney);
    }

    [Test]
    public void IceSword_SpendsMoneyAndAddsNewAugment()
    {
        // start with money
        _fakeInventory.AddMoney(100);
        string initialAugment = _fakeInventory.GetSword().getAugmentName();
        int initialMoney = _fakeInventory.GetMoney();

        _shop.iceSword();

        Assert.AreNotEqual(_fakeInventory.GetSword().getAugmentName(), initialAugment);
        Assert.Less(_fakeInventory.GetMoney(), initialMoney);
    }

    [Test]
    public void FireSword_AlreadyFire_SameMoneyAndAugment()
    {
        // start with money
        _fakeInventory.AddMoney(100);
        _shop.fireSword();
        string initialAugment = _fakeInventory.GetSword().getAugmentName();
        int initialMoney = _fakeInventory.GetMoney();

        _shop.fireSword();

        Assert.AreEqual(_fakeInventory.GetSword().getAugmentName(), initialAugment);
        Assert.AreEqual(_fakeInventory.GetMoney(), initialMoney);
    }

    [Test]
    public void IceSword_AlreadyIce_SameMoneyAndAugment()
    {
        // start with money
        _fakeInventory.AddMoney(100);
        _shop.iceSword();
        string initialAugment = _fakeInventory.GetSword().getAugmentName();
        int initialMoney = _fakeInventory.GetMoney();

        _shop.iceSword();

        Assert.AreEqual(_fakeInventory.GetSword().getAugmentName(), initialAugment);
        Assert.AreEqual(_fakeInventory.GetMoney(), initialMoney);
    }

    [Test]
    public void FireSword_NoMoney_SameMoneyAndAugment()
    {
        string initialAugment = _fakeInventory.GetSword().getAugmentName();
        int initialMoney = _fakeInventory.GetMoney();

        _shop.fireSword();

        Assert.AreEqual(_fakeInventory.GetSword().getAugmentName(), initialAugment);
        Assert.AreEqual(_fakeInventory.GetMoney(), initialMoney);
    }

    [Test]
    public void IceSword_NoMoney_SameMoneyAndAugment()
    {
        string initialAugment = _fakeInventory.GetSword().getAugmentName();
        int initialMoney = _fakeInventory.GetMoney();

        _shop.iceSword();

        Assert.AreEqual(_fakeInventory.GetSword().getAugmentName(), initialAugment);
        Assert.AreEqual(_fakeInventory.GetMoney(), initialMoney);
    }

    // Bow tests
    [Test]
    public void FireBow_SpendsMoneyAndAddsNewAugment()
    {
        // start with money
        _fakeInventory.AddMoney(100);
        string initialAugment = _fakeInventory.GetBow().getAugmentName();
        int initialMoney = _fakeInventory.GetMoney();

        _shop.fireBow();

        Assert.AreNotEqual(_fakeInventory.GetBow().getAugmentName(), initialAugment);
        Assert.Less(_fakeInventory.GetMoney(), initialMoney);
    }

    [Test]
    public void IceBow_SpendsMoneyAndAddsNewAugment()
    {
        // start with money
        _fakeInventory.AddMoney(100);
        string initialAugment = _fakeInventory.GetBow().getAugmentName();
        int initialMoney = _fakeInventory.GetMoney();

        _shop.iceBow();

        Assert.AreNotEqual(_fakeInventory.GetBow().getAugmentName(), initialAugment);
        Assert.Less(_fakeInventory.GetMoney(), initialMoney);
    }

    [Test]
    public void FireBow_AlreadyFire_SameMoneyAndAugment()
    {
        // start with money
        _fakeInventory.AddMoney(100);
        _shop.fireBow();
        string initialAugment = _fakeInventory.GetBow().getAugmentName();
        int initialMoney = _fakeInventory.GetMoney();

        _shop.fireBow();

        Assert.AreEqual(_fakeInventory.GetBow().getAugmentName(), initialAugment);
        Assert.AreEqual(_fakeInventory.GetMoney(), initialMoney);
    }

    [Test]
    public void IceBow_AlreadyIce_SameMoneyAndAugment()
    {
        // start with money
        _fakeInventory.AddMoney(100);
        _shop.iceBow();
        string initialAugment = _fakeInventory.GetBow().getAugmentName();
        int initialMoney = _fakeInventory.GetMoney();

        _shop.iceBow();

        Assert.AreEqual(_fakeInventory.GetBow().getAugmentName(), initialAugment);
        Assert.AreEqual(_fakeInventory.GetMoney(), initialMoney);
    }

    [Test]
    public void FireBow_NoMoney_SameMoneyAndAugment()
    {
        string initialAugment = _fakeInventory.GetBow().getAugmentName();
        int initialMoney = _fakeInventory.GetMoney();

        _shop.fireBow();

        Assert.AreEqual(_fakeInventory.GetBow().getAugmentName(), initialAugment);
        Assert.AreEqual(_fakeInventory.GetMoney(), initialMoney);
    }

    [Test]
    public void IceBow_NoMoney_SameMoneyAndAugment()
    {
        string initialAugment = _fakeInventory.GetBow().getAugmentName();
        int initialMoney = _fakeInventory.GetMoney();

        _shop.iceBow();

        Assert.AreEqual(_fakeInventory.GetBow().getAugmentName(), initialAugment);
        Assert.AreEqual(_fakeInventory.GetMoney(), initialMoney);
    }

    // Wand Tests

    [Test]
    public void FireWand_SpendsMoneyAndAddsNewAugment()
    {
        // start with money
        _fakeInventory.AddMoney(100);
        string initialAugment = _fakeInventory.GetWand().getAugmentName();
        int initialMoney = _fakeInventory.GetMoney();

        _shop.fireWand();

        Assert.AreNotEqual(_fakeInventory.GetWand().getAugmentName(), initialAugment);
        Assert.Less(_fakeInventory.GetMoney(), initialMoney);
    }

    [Test]
    public void IceWand_SpendsMoneyAndAddsNewAugment()
    {
        // start with money
        _fakeInventory.AddMoney(100);
        string initialAugment = _fakeInventory.GetWand().getAugmentName();
        int initialMoney = _fakeInventory.GetMoney();

        _shop.iceWand();

        Assert.AreNotEqual(_fakeInventory.GetWand().getAugmentName(), initialAugment);
        Assert.Less(_fakeInventory.GetMoney(), initialMoney);
    }

    [Test]
    public void FireWand_AlreadyFire_SameMoneyAndAugment()
    {
        // start with money
        _fakeInventory.AddMoney(100);
        _shop.fireWand();
        string initialAugment = _fakeInventory.GetWand().getAugmentName();
        int initialMoney = _fakeInventory.GetMoney();

        _shop.fireWand();

        Assert.AreEqual(_fakeInventory.GetWand().getAugmentName(), initialAugment);
        Assert.AreEqual(_fakeInventory.GetMoney(), initialMoney);
    }

    [Test]
    public void IceWand_AlreadyIce_SameMoneyAndAugment()
    {
        // start with money
        _fakeInventory.AddMoney(100);
        _shop.iceWand();
        string initialAugment = _fakeInventory.GetWand().getAugmentName();
        int initialMoney = _fakeInventory.GetMoney();

        _shop.iceWand();

        Assert.AreEqual(_fakeInventory.GetWand().getAugmentName(), initialAugment);
        Assert.AreEqual(_fakeInventory.GetMoney(), initialMoney);
    }

    [Test]
    public void FireWand_NoMoney_SameMoneyAndAugment()
    {
        string initialAugment = _fakeInventory.GetWand().getAugmentName();
        int initialMoney = _fakeInventory.GetMoney();

        _shop.fireWand();

        Assert.AreEqual(_fakeInventory.GetWand().getAugmentName(), initialAugment);
        Assert.AreEqual(_fakeInventory.GetMoney(), initialMoney);
    }

    [Test]
    public void IceWand_NoMoney_SameMoneyAndAugment()
    {
        string initialAugment = _fakeInventory.GetWand().getAugmentName();
        int initialMoney = _fakeInventory.GetMoney();

        _shop.iceWand();

        Assert.AreEqual(_fakeInventory.GetWand().getAugmentName(), initialAugment);
        Assert.AreEqual(_fakeInventory.GetMoney(), initialMoney);
    }

    [Test]
    public void RemoveSwordAugment_SameMoneyAndNoAugment()
    {
        int initialMoney = _fakeInventory.GetMoney();

        _shop.removeSwordAugment();

        Assert.AreEqual(_fakeInventory.GetSword().getAugmentName(), "NONE");
        Assert.AreEqual(_fakeInventory.GetMoney(), initialMoney);
    }

    [Test]
    public void RemoveBowAugment_SameMoneyAndNoAugment()
    {
        int initialMoney = _fakeInventory.GetMoney();

        _shop.removeBowAugment();

        Assert.AreEqual(_fakeInventory.GetBow().getAugmentName(), "NONE");
        Assert.AreEqual(_fakeInventory.GetMoney(), initialMoney);
    }

    [Test]
    public void RemoveWandAugment_SameMoneyAndNoAugment()
    {
        int initialMoney = _fakeInventory.GetMoney();

        _shop.removeWandAugment();

        Assert.AreEqual(_fakeInventory.GetWand().getAugmentName(), "NONE");
        Assert.AreEqual(_fakeInventory.GetMoney(), initialMoney);
    }
}