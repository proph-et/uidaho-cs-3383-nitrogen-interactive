using NUnit.Framework;
using UnityEngine;

// A mock menu so PlayGame() and Quit() won't try to load scenes during Edit Mode
public class MockMenu : MenuBase
{
    public int playCallCount = 0;
    public int quitCallCount = 0;

    public override void PlayGame()
    {
        playCallCount++;
    }

    public override void Quit()
    {
        quitCallCount++;
    }
}

[TestFixture]
public class EditModeMenuInvokerStressTests
{
    private GameObject invokerObj;
    private MenuInvoker invoker;
    private MockMenu mockMenu;

    [SetUp]
    public void SetUp()
    {
        // Create invoker GameObject
        invokerObj = new GameObject("MenuInvoker");
        invoker = invokerObj.AddComponent<MenuInvoker>();

        // Replace internal menu state with mock state
        mockMenu = new MockMenu();

        // Use reflection because "menu" is private
        var menuField = typeof(MenuInvoker).GetField("menu",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

        menuField.SetValue(invoker, mockMenu);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(invokerObj);
    }

    // ------------------------------------------------------
    // Stress Test 1 — Call PlayGame() 100 times via invoker
    // ------------------------------------------------------
    [Test]
    public void Stress_PlayButton_100Times()
    {
        for (int i = 0; i < 100; i++)
        {
            InvokePrivate("OnPlayButtonClicked");
        }

        Assert.AreEqual(100, mockMenu.playCallCount,
            "PlayGame should be called exactly 100 times.");
    }

    // ------------------------------------------------------
    // Stress Test 2 — Call Quit() 100 times via invoker
    // ------------------------------------------------------
    [Test]
    public void Stress_QuitButton_100Times()
    {
        for (int i = 0; i < 100; i++)
        {
            InvokePrivate("OnQuitButtonClicked");
        }

        Assert.AreEqual(100, mockMenu.quitCallCount,
            "Quit should be called exactly 100 times.");
    }

    // ------------------------------------------------------
    // Stress Test 3 — Rapid alternating play/quit 200 times
    // ------------------------------------------------------
    [Test]
    public void Stress_RapidAlternatingCalls()
    {
        for (int i = 0; i < 200; i++)
        {
            if (i % 2 == 0)
                InvokePrivate("OnPlayButtonClicked");
            else
                InvokePrivate("OnQuitButtonClicked");
        }

        Assert.AreEqual(100, mockMenu.playCallCount);
        Assert.AreEqual(100, mockMenu.quitCallCount);
    }

    // ------------------------------------------------------
    // Stress Test 4 — Ensure dynamic binding never breaks
    // ------------------------------------------------------
    [Test]
    public void Stress_DynamicBindingStillWorks()
    {
        // Call both methods many times
        for (int i = 0; i < 150; i++)
        {
            InvokePrivate("OnPlayButtonClicked");
            InvokePrivate("OnQuitButtonClicked");
        }

        Assert.Greater(mockMenu.playCallCount, 0);
        Assert.Greater(mockMenu.quitCallCount, 0);
    }

    // ------------------------------------------------------
    // Stress Test 5 — Ensure MenuInvoker can handle
    //                 thousands of calls without throwing.
    // ------------------------------------------------------
    [Test]
    public void Stress_NoExceptionsDuringHeavyUsage()
    {
        Assert.DoesNotThrow(() =>
        {
            for (int i = 0; i < 1000; i++)
            {
                InvokePrivate("OnPlayButtonClicked");
                InvokePrivate("OnQuitButtonClicked");
            }
        });
    }

    // Helper: Invoke private methods using reflection
    private void InvokePrivate(string methodName)
    {
        var method = typeof(MenuInvoker).GetMethod(methodName,
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

        method.Invoke(invoker, null);
    }
}
