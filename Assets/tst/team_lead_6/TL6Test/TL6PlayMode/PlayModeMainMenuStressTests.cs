using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.TestTools;
using System.Collections;

// -------------------------
// Facade for multiple button stress testing
// -------------------------
public class StressMenuFacade
{
    public GameObject menuObj { get; private set; }
    public Button[] buttons;
    public int[] clickCounts;

    public StressMenuFacade(int buttonCount = 10)
    {
        menuObj = new GameObject("StressMenu");
        buttons = new Button[buttonCount];
        clickCounts = new int[buttonCount];

        for (int i = 0; i < buttonCount; i++)
        {
            var btnObj = new GameObject("Button_" + i);
            var button = btnObj.AddComponent<Button>();
            int index = i; // capture for closure
            clickCounts[i] = 0;

            // Mock listener increments click count
            button.onClick.AddListener(() => clickCounts[index]++);
            buttons[i] = button;
        }
    }

    public void ClickButton(int index, int times = 1)
    {
        for (int i = 0; i < times; i++)
        {
            buttons[index].onClick.Invoke();
        }
    }

    public void Destroy()
    {
        Object.DestroyImmediate(menuObj);
        foreach (var b in buttons)
        {
            Object.DestroyImmediate(b.gameObject);
        }
    }
}

// -------------------------
// MainMenu Play Mode Stress Tests
// -------------------------
public class MainMenuPlayModeStressTests : MonoBehaviour
{
    private MainMenu menu;
    private GameObject menuObj;
    private Button playButton;

    [SetUp]
    public void SetUp()
    {
        // Setup MainMenu instance
        menuObj = new GameObject("MainMenu");

        // Direct instantiation since MainMenu is NOT a MonoBehaviour
        menu = new MainMenu();

        // Setup a single Play Button
        var buttonObj = new GameObject("PlayButton");
        playButton = buttonObj.AddComponent<Button>();
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(menuObj);
        Object.DestroyImmediate(playButton?.gameObject);
        menu = null;
    }

    // -------------------------
    // Stress Test 1: Rapid Play Button Clicks
    // -------------------------
    [UnityTest]
    public IEnumerator Stress_RapidButtonClicks()
    {
        bool invoked = false;
        playButton.onClick.AddListener(() => invoked = true);

        for (int i = 0; i < 50; i++)
        {
            invoked = false;
            playButton.onClick.Invoke();
            Assert.IsTrue(invoked, $"Button click listener failed on iteration {i}");
            yield return null;
        }
    }


    // -------------------------
    // Stress Test 2: High-Frequency Multiple Button Clicks
    // -------------------------
    [UnityTest]
    public IEnumerator Stress_MultipleButtons_HighFrequencyClicks()
    {
        var facade = new StressMenuFacade(20);
        int clicksPerButton = 1000;

        for (int i = 0; i < clicksPerButton; i++)
        {
            for (int j = 0; j < facade.buttons.Length; j++)
            {
                facade.ClickButton(j, 1);
            }

            yield return null; // wait a frame
        }

        for (int j = 0; j < facade.buttons.Length; j++)
        {
            Assert.AreEqual(clicksPerButton, facade.clickCounts[j],
                $"Button {j} should have been clicked {clicksPerButton} times.");
        }

        Debug.Log($"Stress test complete: {facade.buttons.Length} buttons clicked {clicksPerButton} times each.");

        facade.Destroy();
    }
}
