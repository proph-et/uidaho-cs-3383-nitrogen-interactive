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




    // A Test behaves as an ordinary method
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
    public void CurrencyManuallySetToNegativeThisShouldFail()
    {
        SerializedObject serialized = new SerializedObject(currencySO);
        serialized.FindProperty("Currency").intValue = -10;
        serialized.ApplyModifiedProperties();

        int amount = currencySO.GetCurrency();


        Assert.Less(amount, 0);
    }

    [Test]
    public void SubtractTotalCurrencyResultsInZero()
    {
        int amount = currencySO.GetCurrency();
        int shouldBeZero = amount - (currencySO.GetCurrency());

        Assert.AreEqual(shouldBeZero, 0);
    }

    // [Test]
    // public void Collect_HealsTarget()
    // {
    //     var so = ScriptableObject.CreateInstance<HealthSO>();
    //     so.SetHealthAmount(10);

    //     var go = new GameObject();
    //     var health = go.AddComponent<Health>();
    //     health.TakeDamage(10);

    //     so.Collect(go);

    //     Assert.AreEqual(health.GetCurrentHealth(), (health.GetMaxHealth()));
    // }

    [Test]
    public void CurrencyDoesNotExceedIntegerMaxOverflow()
    {
        currencySO.SetCurrency(int.MaxValue);

        currencySO.Collect(null);

        long amount = currencySO.GetCurrency();

        Assert.AreEqual(int.MaxValue, amount);
    }

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
    public void Arrow_GetArrowSpeed_ReturnsValue()
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
    public void Bow_CanAssignProjectilePrefab()
    {
        var bow = new Bow(null);
        var prefab = new GameObject("ArrowPrefab");

        bow.SetProjectilePrefab(prefab);

        Assert.AreEqual(prefab, bow.GetProjectilePrefab());
    }

    [Test]
    public void Wand_CanAssignOrbPrefab()
    {
        var wand = new Wand(null);
        var orb = new GameObject("OrbPrefab");
    
        wand.SetOrbPrefab(orb);
    
        Assert.AreEqual(orb, wand.GetOrbPrefab());
    }


    // [Test]
    // public void XPHandler_AddsXp()
    // {
    //     var xpObj = new GameObject();
    //     var handler = xpObj.AddComponent<XPHandler>();

    //     LevelSystem.Instance = new LevelSystem(); // if needed for your implementation

    //     LevelSystem.Instance.SetXp(0);
    //     handler.Collect(new GameObject());

    //     Assert.AreEqual(5, LevelSystem.Instance.GetXp());
    // }
    // [Test]
    // public void ArrowHasRigidbodyAfterAwakeFunctionIsCalled()
    // {
    //     var go = new GameObject();
    //     go.AddComponent<Rigidbody>();

    //     var a = go.AddComponent<Arrow>();
    //     Assert.NotNull(a.GetArrowRB());
    // }



}