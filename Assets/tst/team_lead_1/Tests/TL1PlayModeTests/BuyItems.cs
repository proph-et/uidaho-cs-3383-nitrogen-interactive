using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;
using src.team_lead_1.scripts;
using TMPro;

public class BuyItems
{
    private GameObject _uiManagerGo;
    private UIManager _uiManager;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        _uiManagerGo = new GameObject("UIManager");
        _uiManager = _uiManagerGo.AddComponent<UIManager>();

        // Create and assign money TMPTextBox
        var moneyBoxGo = new GameObject("MoneyTMPTextBox");
        var moneyTMPTextBox = moneyBoxGo.AddComponent<TMPTextBox>();
        var moneyTmpugui = moneyBoxGo.AddComponent<TextMeshProUGUI>();
        moneyTMPTextBox.myTMPTextElement = moneyTmpugui;

        // Create and assign items TMPTextBox
        var itemsBoxGo = new GameObject("ItemsTMPTextBox");
        var itemsTMPTextBox = itemsBoxGo.AddComponent<TMPTextBox>();
        var itemsTmpugui = itemsBoxGo.AddComponent<TextMeshProUGUI>();
        itemsTMPTextBox.myTMPTextElement = itemsTmpugui;

        _uiManager.moneyTMPTextBox = moneyTMPTextBox;
        _uiManager.itemsTMPTextBox = itemsTMPTextBox;

        _uiManager.money = 100;
        _uiManager.numItems = 5;

        _uiManager.InitializeUI();

        yield return null;
    }


    [UnityTest]
    public IEnumerator BuyButton_IncreasesItems_DecreasesMoney()
    {
        int initialMoney = _uiManager.money;
        int initialItems = _uiManager.numItems;

        int itemValue = 5;

        _uiManager.BuyItem(itemValue); // Simulate button click

        Assert.AreEqual(initialItems + 1, _uiManager.numItems);
        Assert.AreEqual(initialMoney - itemValue, _uiManager.money);

        yield return null;
    }
}