using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

/// <summary>
/// Fake menu used for testing. This avoids running real scene loads
/// or quitting the game. Counts how many times actions are invoked.
/// </summary>
public class FakeMainMenu : MenuBase
{
    public int playCalls = 0;
    public int quitCalls = 0;

    public override void PlayGame()
    {
        playCalls++;
    }

    public override void Quit()
    {
        quitCalls++;
    }
}

/// <summary>
/// Testable version of MenuInvoker that lets us substitute FakeMainMenu.
/// </summary>
public class TestableMenuInvoker : MenuInvoker
{
    public void InjectMenu(MenuBase newMenu)
    {
        var menuField = typeof(MenuInvoker).GetField("menu",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

        menuField.SetValue(this, newMenu);
    }

    public void InvokePlay()
    {
        var method = typeof(MenuInvoker).GetMethod("OnPlayButtonClicked",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        method.Invoke(this, null);
    }

    public void InvokeQuit()
    {
        var method = typeof(MenuInvoker).GetMethod("OnQuitButtonClicked",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        method.Invoke(this, null);
    }
}

/// <summary>
/// FULL PlayMode Stress Test Suite for MenuInvoker
/// </summary>
public class MenuInvokerPlayModeStressTests
{
    private GameObject invokerObj;
    private TestableMenuInvoker invoker;
    private FakeMainMenu fakeMenu;

    [SetUp]
    public void SetUp()
    {
        invokerObj = new GameObject("Invoker");
        invoker = invokerObj.AddComponent<TestableMenuInvoker>();

        fakeMenu = new FakeMainMenu();
        invoker.InjectMenu(fakeMenu);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(invokerObj);
    }

    // ----------------------------------------------------------
    // TEST 1: Rapid PlayGame calls (50)
    // ----------------------------------------------------------
    [UnityTest]
    public IEnumerator Stress_RapidPlayCalls()
    {
        for (int i = 0; i < 50; i++)
        {
            invoker.InvokePlay();
            yield return null;
        }

        Assert.AreEqual(50, fakeMenu.playCalls,
            "MenuInvoker should forward all PlayGame() calls to the active menu.");
    }

    // ----------------------------------------------------------
    // TEST 2: Rapid Quit calls (50)
    // ----------------------------------------------------------
    [UnityTest]
    public IEnumerator Stress_RapidQuitCalls()
    {
        for (int i = 0; i < 50; i++)
        {
            invoker.InvokeQuit();
            yield return null;
        }

        Assert.AreEqual(50, fakeMenu.quitCalls,
            "MenuInvoker should forward all Quit() calls to the active menu.");
    }

    // ----------------------------------------------------------
    // TEST 3: Mixed Play and Quit calls (100 total)
    // ----------------------------------------------------------
    [UnityTest]
    public IEnumerator Stress_MixedPlayAndQuit()
    {
        for (int i = 0; i < 50; i++)
        {
            invoker.InvokePlay();
            yield return null;
            invoker.InvokeQuit();
            yield return null;
        }

        Assert.AreEqual(50, fakeMenu.playCalls);
        Assert.AreEqual(50, fakeMenu.quitCalls);
    }

    // ----------------------------------------------------------
    // TEST 4: Very High Frequency Play calls (1000)
    // ----------------------------------------------------------
    [UnityTest]
    public IEnumerator Stress_HighFrequencyPlay()
    {
        for (int i = 0; i < 1000; i++)
            invoker.InvokePlay();

        yield return null;

        Assert.AreEqual(1000, fakeMenu.playCalls,
            "Invoker should handle 1000 simulated button presses easily.");
    }

    // ----------------------------------------------------------
    // TEST 5: Ensure MenuInvoker survives multiple Awake cycles
    // ----------------------------------------------------------
    [UnityTest]
    public IEnumerator Stress_RecreateInvokerManyTimes()
    {
        for (int i = 0; i < 20; i++)
        {
            Object.DestroyImmediate(invokerObj);
            yield return null;

            invokerObj = new GameObject("Invoker_" + i);
            invoker = invokerObj.AddComponent<TestableMenuInvoker>();

            // Inject new fake menu each iteration
            fakeMenu = new FakeMainMenu();
            invoker.InjectMenu(fakeMenu);

            invoker.InvokePlay();
            invoker.InvokeQuit();

            yield return null;

            Assert.AreEqual(1, fakeMenu.playCalls);
            Assert.AreEqual(1, fakeMenu.quitCalls);
        }
    }
}
