using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;
using src.team_lead_1.scripts;
using TMPro;

public class RapidBuySellItems
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
    public IEnumerator StressTest_BuySellLoop_MaintainsValidState()
    {
        int itemValue = 5;
        int iterations = 1000000000;

        for (int i = 0; i < iterations; i++)
        {
            if (_uiManager.money >= itemValue)
            {
                _uiManager.BuyItem(itemValue);
            }

            if (_uiManager.numItems > 0)
            {
                _uiManager.SellItem(itemValue);
            }
        }

        // Final assertions
        Assert.GreaterOrEqual(_uiManager.money, 0);
        Assert.GreaterOrEqual(_uiManager.numItems, 0);
        Assert.LessOrEqual(_uiManager.money, 1000);
        Assert.LessOrEqual(_uiManager.numItems, iterations);

        yield return null;
    }
}