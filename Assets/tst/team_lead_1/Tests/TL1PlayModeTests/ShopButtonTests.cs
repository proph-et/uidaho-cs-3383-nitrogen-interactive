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

        // Fake inventory with enough money
        _fakeInventory = go.AddComponent<Inventory>();
        _fakeInventory.swordPrefab = new GameObject("SwordPrefab");
        _fakeInventory.bowPrefab = new GameObject("BowPrefab");
        _fakeInventory.wandPrefab = new GameObject("WandPrefab");
        _fakeInventory.magicOrbPrefab = new GameObject("OrbPrefab");
        _fakeInventory.arrowPrefab = new GameObject("ArrowPrefab");

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
        _fakeInventory.addMoney(100);
        int initialTier = _fakeInventory.getSword().getWeaponTier();
        int initialMoney = _fakeInventory.getMoney();

        _shop.UpgradeSword();

        Assert.Greater(_fakeInventory.getSword().getWeaponTier(), initialTier);
        Assert.Less(_fakeInventory.getMoney(), initialMoney);
    }

    [Test]
    public void UpgradeSword_NoMoney_SameMoneyAndTier()
    {
        int initialTier = _fakeInventory.getSword().getWeaponTier();
        int initialMoney = _fakeInventory.getMoney();

        _shop.UpgradeSword();

        Assert.AreEqual(_fakeInventory.getSword().getWeaponTier(), initialTier);
        Assert.AreEqual(_fakeInventory.getMoney(), initialMoney);
    }

    [Test]
    public void UpgradeBow_SpendsMoneyAndIncreasesTier()
    {
        // start with money
        _fakeInventory.addMoney(100);
        int initialTier = _fakeInventory.getBow().getWeaponTier();
        int initialMoney = _fakeInventory.getMoney();

        _shop.UpgradeBow();

        Assert.Greater(_fakeInventory.getBow().getWeaponTier(), initialTier);
        Assert.Less(_fakeInventory.getMoney(), initialMoney);
    }

    [Test]
    public void UpgradeBow_NoMoney_SameMoneyAndTier()
    {
        int initialTier = _fakeInventory.getBow().getWeaponTier();
        int initialMoney = _fakeInventory.getMoney();

        _shop.UpgradeBow();

        Assert.AreEqual(_fakeInventory.getBow().getWeaponTier(), initialTier);
        Assert.AreEqual(_fakeInventory.getMoney(), initialMoney);
    }

    [Test]
    public void UpgradeWand_SpendsMoneyAndIncreasesTier()
    {
        // start with money
        _fakeInventory.addMoney(100);
        int initialTier = _fakeInventory.getWand().getWeaponTier();
        int initialMoney = _fakeInventory.getMoney();

        _shop.UpgradeWand();

        Assert.Greater(_fakeInventory.getWand().getWeaponTier(), initialTier);
        Assert.Less(_fakeInventory.getMoney(), initialMoney);
    }

    [Test]
    public void UpgradeWand_NoMoney_SameMoneyAndTier()
    {
        int initialTier = _fakeInventory.getWand().getWeaponTier();
        int initialMoney = _fakeInventory.getMoney();

        _shop.UpgradeWand();

        Assert.AreEqual(_fakeInventory.getWand().getWeaponTier(), initialTier);
        Assert.AreEqual(_fakeInventory.getMoney(), initialMoney);
    }


    [Test]
    public void FireSword_SpendsMoneyAndAddsNewAugment()
    {
        // start with money
        _fakeInventory.addMoney(100);
        string initialAugment = _fakeInventory.getSword().getAugmentName();
        int initialMoney = _fakeInventory.getMoney();

        _shop.fireSword();

        Assert.AreNotEqual(_fakeInventory.getSword().getAugmentName(), initialAugment);
        Assert.Less(_fakeInventory.getMoney(), initialMoney);
    }

    [Test]
    public void IceSword_SpendsMoneyAndAddsNewAugment()
    {
        // start with money
        _fakeInventory.addMoney(100);
        string initialAugment = _fakeInventory.getSword().getAugmentName();
        int initialMoney = _fakeInventory.getMoney();

        _shop.iceSword();

        Assert.AreNotEqual(_fakeInventory.getSword().getAugmentName(), initialAugment);
        Assert.Less(_fakeInventory.getMoney(), initialMoney);
    }

    [Test]
    public void FireSword_AlreadyFire_SameMoneyAndAugment()
    {
        // start with money
        _fakeInventory.addMoney(100);
        _shop.fireSword();
        string initialAugment = _fakeInventory.getSword().getAugmentName();
        int initialMoney = _fakeInventory.getMoney();

        _shop.fireSword();

        Assert.AreEqual(_fakeInventory.getSword().getAugmentName(), initialAugment);
        Assert.AreEqual(_fakeInventory.getMoney(), initialMoney);
    }

    [Test]
    public void IceSword_AlreadyIce_SameMoneyAndAugment()
    {
        // start with money
        _fakeInventory.addMoney(100);
        _shop.iceSword();
        string initialAugment = _fakeInventory.getSword().getAugmentName();
        int initialMoney = _fakeInventory.getMoney();

        _shop.iceSword();

        Assert.AreEqual(_fakeInventory.getSword().getAugmentName(), initialAugment);
        Assert.AreEqual(_fakeInventory.getMoney(), initialMoney);
    }

    [Test]
    public void FireSword_NoMoney_SameMoneyAndAugment()
    {
        string initialAugment = _fakeInventory.getSword().getAugmentName();
        int initialMoney = _fakeInventory.getMoney();

        _shop.fireSword();

        Assert.AreEqual(_fakeInventory.getSword().getAugmentName(), initialAugment);
        Assert.AreEqual(_fakeInventory.getMoney(), initialMoney);
    }

    [Test]
    public void IceSword_NoMoney_SameMoneyAndAugment()
    {
        string initialAugment = _fakeInventory.getSword().getAugmentName();
        int initialMoney = _fakeInventory.getMoney();

        _shop.iceSword();

        Assert.AreEqual(_fakeInventory.getSword().getAugmentName(), initialAugment);
        Assert.AreEqual(_fakeInventory.getMoney(), initialMoney);
    }

    // Bow tests
    [Test]
    public void FireBow_SpendsMoneyAndAddsNewAugment()
    {
        // start with money
        _fakeInventory.addMoney(100);
        string initialAugment = _fakeInventory.getBow().getAugmentName();
        int initialMoney = _fakeInventory.getMoney();

        _shop.fireBow();

        Assert.AreNotEqual(_fakeInventory.getBow().getAugmentName(), initialAugment);
        Assert.Less(_fakeInventory.getMoney(), initialMoney);
    }

    [Test]
    public void IceBow_SpendsMoneyAndAddsNewAugment()
    {
        // start with money
        _fakeInventory.addMoney(100);
        string initialAugment = _fakeInventory.getBow().getAugmentName();
        int initialMoney = _fakeInventory.getMoney();

        _shop.iceBow();

        Assert.AreNotEqual(_fakeInventory.getBow().getAugmentName(), initialAugment);
        Assert.Less(_fakeInventory.getMoney(), initialMoney);
    }

    [Test]
    public void FireBow_AlreadyFire_SameMoneyAndAugment()
    {
        // start with money
        _fakeInventory.addMoney(100);
        _shop.fireBow();
        string initialAugment = _fakeInventory.getBow().getAugmentName();
        int initialMoney = _fakeInventory.getMoney();

        _shop.fireBow();

        Assert.AreEqual(_fakeInventory.getBow().getAugmentName(), initialAugment);
        Assert.AreEqual(_fakeInventory.getMoney(), initialMoney);
    }

    [Test]
    public void IceBow_AlreadyIce_SameMoneyAndAugment()
    {
        // start with money
        _fakeInventory.addMoney(100);
        _shop.iceBow();
        string initialAugment = _fakeInventory.getBow().getAugmentName();
        int initialMoney = _fakeInventory.getMoney();

        _shop.iceBow();

        Assert.AreEqual(_fakeInventory.getBow().getAugmentName(), initialAugment);
        Assert.AreEqual(_fakeInventory.getMoney(), initialMoney);
    }

    [Test]
    public void FireBow_NoMoney_SameMoneyAndAugment()
    {
        string initialAugment = _fakeInventory.getBow().getAugmentName();
        int initialMoney = _fakeInventory.getMoney();

        _shop.fireBow();

        Assert.AreEqual(_fakeInventory.getBow().getAugmentName(), initialAugment);
        Assert.AreEqual(_fakeInventory.getMoney(), initialMoney);
    }

    [Test]
    public void IceBow_NoMoney_SameMoneyAndAugment()
    {
        string initialAugment = _fakeInventory.getBow().getAugmentName();
        int initialMoney = _fakeInventory.getMoney();

        _shop.iceBow();

        Assert.AreEqual(_fakeInventory.getBow().getAugmentName(), initialAugment);
        Assert.AreEqual(_fakeInventory.getMoney(), initialMoney);
    }

    // Wand Tests

    [Test]
    public void FireWand_SpendsMoneyAndAddsNewAugment()
    {
        // start with money
        _fakeInventory.addMoney(100);
        string initialAugment = _fakeInventory.getWand().getAugmentName();
        int initialMoney = _fakeInventory.getMoney();

        _shop.fireWand();

        Assert.AreNotEqual(_fakeInventory.getWand().getAugmentName(), initialAugment);
        Assert.Less(_fakeInventory.getMoney(), initialMoney);
    }

    [Test]
    public void IceWand_SpendsMoneyAndAddsNewAugment()
    {
        // start with money
        _fakeInventory.addMoney(100);
        string initialAugment = _fakeInventory.getWand().getAugmentName();
        int initialMoney = _fakeInventory.getMoney();

        _shop.iceWand();

        Assert.AreNotEqual(_fakeInventory.getWand().getAugmentName(), initialAugment);
        Assert.Less(_fakeInventory.getMoney(), initialMoney);
    }

    [Test]
    public void FireWand_AlreadyFire_SameMoneyAndAugment()
    {
        // start with money
        _fakeInventory.addMoney(100);
        _shop.fireWand();
        string initialAugment = _fakeInventory.getWand().getAugmentName();
        int initialMoney = _fakeInventory.getMoney();

        _shop.fireWand();

        Assert.AreEqual(_fakeInventory.getWand().getAugmentName(), initialAugment);
        Assert.AreEqual(_fakeInventory.getMoney(), initialMoney);
    }

    [Test]
    public void IceWand_AlreadyIce_SameMoneyAndAugment()
    {
        // start with money
        _fakeInventory.addMoney(100);
        _shop.iceWand();
        string initialAugment = _fakeInventory.getWand().getAugmentName();
        int initialMoney = _fakeInventory.getMoney();

        _shop.iceWand();

        Assert.AreEqual(_fakeInventory.getWand().getAugmentName(), initialAugment);
        Assert.AreEqual(_fakeInventory.getMoney(), initialMoney);
    }

    [Test]
    public void FireWand_NoMoney_SameMoneyAndAugment()
    {
        string initialAugment = _fakeInventory.getWand().getAugmentName();
        int initialMoney = _fakeInventory.getMoney();

        _shop.fireWand();

        Assert.AreEqual(_fakeInventory.getWand().getAugmentName(), initialAugment);
        Assert.AreEqual(_fakeInventory.getMoney(), initialMoney);
    }

    [Test]
    public void IceWand_NoMoney_SameMoneyAndAugment()
    {
        string initialAugment = _fakeInventory.getWand().getAugmentName();
        int initialMoney = _fakeInventory.getMoney();

        _shop.iceWand();

        Assert.AreEqual(_fakeInventory.getWand().getAugmentName(), initialAugment);
        Assert.AreEqual(_fakeInventory.getMoney(), initialMoney);
    }

    [Test]
    public void RemoveSwordAugment_SameMoneyAndNoAugment()
    {
        int initialMoney = _fakeInventory.getMoney();

        _shop.removeSwordAugment();

        Assert.AreEqual(_fakeInventory.getSword().getAugmentName(), "NONE");
        Assert.AreEqual(_fakeInventory.getMoney(), initialMoney);
    }

    [Test]
    public void RemoveBowAugment_SameMoneyAndNoAugment()
    {
        int initialMoney = _fakeInventory.getMoney();

        _shop.removeBowAugment();

        Assert.AreEqual(_fakeInventory.getBow().getAugmentName(), "NONE");
        Assert.AreEqual(_fakeInventory.getMoney(), initialMoney);
    }

    [Test]
    public void RemoveWandAugment_SameMoneyAndNoAugment()
    {
        int initialMoney = _fakeInventory.getMoney();

        _shop.removeWandAugment();

        Assert.AreEqual(_fakeInventory.getWand().getAugmentName(), "NONE");
        Assert.AreEqual(_fakeInventory.getMoney(), initialMoney);
    }
}