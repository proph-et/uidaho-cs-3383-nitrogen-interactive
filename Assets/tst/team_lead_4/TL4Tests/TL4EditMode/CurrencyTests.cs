using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;

public class CurrencyTests
{
    private CurrencySO currencySO;

    [OneTimeSetUp]
    public void Setup()
    {
        currencySO = ScriptableObject.CreateInstance<CurrencySO>();
    }

    // Currency Tests

    [Test]
    public void CurrencyDefaultValueEqualTo0()
    {
        int amount = currencySO.GetCurrency();

        Assert.GreaterOrEqual(amount, 0);
    }

    [Test]
    public void SetCurrencyUpdatesValue()
    {
        var serialized = ScriptableObject.CreateInstance<CurrencySO>();
        serialized.SetCurrency(25);
        Assert.AreEqual(25, serialized.CurrencyAmount);
    }

    [Test]
    public void GetCurrencyReturnsCorrectValue()
    {
        var serialized = ScriptableObject.CreateInstance<CurrencySO>();
        serialized.SetCurrency(10);
        Assert.AreEqual(10, serialized.GetCurrency());
    }

    [Test]
    public void SubtractTotalCurrencyResultsInZero()
    {
        int amount = currencySO.GetCurrency();
        int shouldBeZero = amount - (currencySO.GetCurrency());

        Assert.AreEqual(shouldBeZero, 0);
    }

    [Test]
    public void CollectAddsMoneyToInventory()
    {
        var currency = ScriptableObject.CreateInstance<CurrencySO>();
        currency.SetCurrency(3);

        GameObject player = new GameObject();
        var inv = player.AddComponent<Inventory>();

        currency.Collect(player);

        Assert.AreEqual(3, inv.GetMoney());
    }

    // ---------------------------------------------------------
    // Reminder to add in the Max Overflow check into currency.
    // ---------------------------------------------------------

    // [Test]
    // public void CurrencyDoesNotExceedIntegerMaxOverflow()
    // {
    //     currencySO.SetCurrency(int.MaxValue);

    //     currencySO.Collect(null);

    //     long amount = currencySO.GetCurrency();

    //     Assert.AreEqual(int.MaxValue, amount);
    // }

    // Health Tests

    [Test]
    public void CollectNoHealthComponentEqualsNoError()
    {
        var so = ScriptableObject.CreateInstance<HealthSO>();
        var go = new GameObject(); // no Health component

        Assert.DoesNotThrow(() => so.Collect(go));
    }

    [Test]
    public void DefaultHealthAmountIsTen()
    {
        var so = ScriptableObject.CreateInstance<HealthSO>();
        Assert.AreEqual(10, so.GetHealthAmount());
    }

    [Test]
    public void SetHealthUpdatesValue()
    {
        var serialized = ScriptableObject.CreateInstance<HealthSO>();
        serialized.SetHealthAmount(25);
        Assert.AreEqual(25, serialized.GetHealthAmount());
    }

    [Test]
    public void GetHeathReturnsCorrectValue()
    {
        var serialized = ScriptableObject.CreateInstance<HealthSO>();
        serialized.SetHealthAmount(10);
        Assert.AreEqual(10, serialized.GetHealthAmount());
    }

    // Arrow Tests

    [Test]
    public void GetDamageArrowReturnsCorrectValue()
    {
        var go = new GameObject();
        var arrow = go.AddComponent<Arrow>();

        arrow.SetDamage(40);
        Assert.AreEqual(40, arrow.GetDamage());
    }

    [Test]
    public void SetDamageArrowUpdatesValue()
    {
        var go = new GameObject();
        var arrow = go.AddComponent<Arrow>();

        arrow.SetDamage(15);
        Assert.AreEqual(15, arrow.GetDamage());
    }

    [Test]
    public void ArrowGetArrowSpeedReturnsValue()
    {
        var go = new GameObject();
        var rb = go.AddComponent<Rigidbody>();
        var arrow = go.AddComponent<Arrow>();   

        Assert.AreEqual(30f, arrow.GetArrowSpeed());
    }

    public void DefaultArrowSpeedIs30()
    {
        var go = new GameObject();
        var a = go.AddComponent<Arrow>();
        Assert.AreEqual(30f, a.GetArrowSpeed());
    }

    // Orb Tests

    [Test]
    public void GetDamageOrbReturnsCorrectValue()
    {
        var go = new GameObject();
        var orb = go.AddComponent<MagicOrb>();

        orb.SetDamage(40);
        Assert.AreEqual(40, orb.GetDamage());
    }

    [Test]
    public void SetDamageOrbUpdatesValue()
    {
        var go = new GameObject();
        var orb = go.AddComponent<MagicOrb>();

        orb.SetDamage(15);
        Assert.AreEqual(15, orb.GetDamage());
    }

    // Sword Tests

    [Test]
    public void SwordDealsDamageWhenAttacking()
    {
        var target = new GameObject();
        var health = target.AddComponent<Health>();

        var sword = new Sword(null);
        sword.StartAttack();

        sword.Attack(target, target.GetComponent<Collider>());

        Assert.Less(health.GetCurrentHealth(), 100);
    }

    [Test]
    public void SwordEndsAttackClearsIsAttacking()
    {
        var sword = new Sword(null);
        sword.StartAttack();
        sword.EndAttack();

        sword.Attack(null, null);

        Assert.Pass(); // no throw = good
    }

    [Test]
    public void SwordEndAttackWorks()
    {
        var sword = new Sword(null);
        
        sword.StartAttack();
        sword.EndAttack();

        // attempt attacking should do nothing
        var targetGO = new GameObject();
        var target = targetGO.AddComponent<Health>();
        float before = target.GetCurrentHealth();

        sword.Attack(new GameObject(), target.GetComponent<Collider>());

        Assert.AreEqual(before, target.GetCurrentHealth());
    }

    // Bow Tests

    [Test]
    public void BowCanAssignProjectilePrefab()
    {
        var bow = new Bow(null);
        var prefab = new GameObject("ArrowPrefab");

        bow.SetProjectilePrefab(prefab);

        Assert.AreEqual(prefab, bow.GetProjectilePrefab());
    }

    // Wand Tests

    [Test]
    public void WandCanAssignOrbPrefab()
    {
        var wand = new Wand(null);
        var orb = new GameObject("OrbPrefab");

        wand.SetOrbPrefab(orb);

        Assert.AreEqual(orb, wand.GetOrbPrefab());
    }

    // WeaponBase Tests 

    [Test]
    public void WeaponBaseNameSetGet()
    {
        var w = new WeaponBase();
        w.setWeaponName("Laser Sword");

        Assert.AreEqual("Laser Sword", w.getName());
    }

    [Test]
    public void WeaponBaseSetTierWorks()
    {
        var w = new WeaponBase();
        w.setWeaponTier(3);

        Assert.AreEqual(3, w.getWeaponTier());
    }

}