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
    // Stress Test 1: Rapid PlayGame Calls
    // -------------------------
    [UnityTest]
    public IEnumerator Stress_RapidPlayGameCalls()
    {
        for (int i = 0; i < 50; i++)
        {
            menu.PlayGame();
            yield return null;
        }

        Assert.Pass("PlayGame() handled rapid repeated calls without crashing.");
    }

    // -------------------------
    // Stress Test 2: Rapid Quit Calls
    // -------------------------
    [UnityTest]
    public IEnumerator Stress_RapidQuitCalls()
    {
        for (int i = 0; i < 50; i++)
        {
            menu.Quit();
            yield return null;
        }

        Assert.Pass("Quit() handled rapid repeated calls without crashing.");
    }

    // -------------------------
    // Stress Test 3: Rapid Play Button Clicks
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
    // Stress Test 4: Repeated Scene Loading
    // -------------------------
    [UnityTest]
    public IEnumerator Stress_RepeatedSceneLoading()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        for (int i = 0; i < 10; i++)
        {
            SceneManager.LoadScene(sceneIndex);
            yield return null;
        }

        Assert.Pass("SceneManager handled repeated loads of the same scene.");
    }

    // -------------------------
    // Stress Test 5: Mixed PlayGame and Quit Calls
    // -------------------------
    [UnityTest]
    public IEnumerator Stress_MixedPlayAndQuit()
    {
        for (int i = 0; i < 25; i++)
        {
            menu.PlayGame();
            yield return null;
            menu.Quit();
            yield return null;
        }

        Assert.Pass("MainMenu handled mixed PlayGame and Quit calls under stress.");
    }

    // -------------------------
    // Stress Test 6: High-Frequency Multiple Button Clicks
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
