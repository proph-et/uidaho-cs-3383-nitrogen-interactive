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


    /*

    // A Test behaves as an ordinary method
    [Test]
    public void CurrencyDefaultValueEqualTo0()
    {
        int amount = currencySO.GetCurrency();

        Assert.GreaterOrEqual(amount, 0);
    }

    // [Test]
    // public void CurrencyManuallySetToNegativeThisShouldFail()
    // {
    //     SerializedObject serialized = new SerializedObject(currencySO);
    //     serialized.FindProperty("Currency").intValue = -10;
    //     serialized.ApplyModifiedProperties();

    //     int amount = currencySO.GetCurrency();


    //     Assert.Less(amount, 0);
    // }

    [Test]
    public void SubtractTotalCurrencyResultsInZero()
    {
        int amount = currencySO.GetCurrency();
        int shouldBeZero = amount - (currencySO.GetCurrency());

        Assert.AreEqual(shouldBeZero, 0);
    }

    [Test]
    public void CurrencyDoesNotExceedIntegerMaxOverflow()
    {
        currencySO.SetCurrency(int.MaxValue);

        currencySO.Collect(null);

        long amount = currencySO.GetCurrency();

        Assert.AreEqual(int.MaxValue, amount);
    }

    */
}