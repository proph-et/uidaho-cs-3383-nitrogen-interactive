using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

[TestFixture]
public class StressButtonTest
{
    private GameObject menuObj;
    private Button playButton;

    [SetUp]
    public void SetUp()
    {
        // Create a dummy MainMenu object
        menuObj = new GameObject("MainMenu");

        // Create a Play Button
        var buttonObj = new GameObject("PlayButton");
        playButton = buttonObj.AddComponent<Button>();

        // Ensure the button starts with no listeners
        playButton.onClick.RemoveAllListeners();
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(menuObj);
        Object.DestroyImmediate(playButton?.gameObject);
    }

    [Test]
    public void PlayButton_StressClickTest()
    {
        int clicks = 10000; // simulate 10,000 rapid clicks
        int invokedCount = 0;

        // Add a mock listener instead of the real PlayGame
        playButton.onClick.AddListener(() => invokedCount++);

        // Simulate rapid clicks
        for (int i = 0; i < clicks; i++)
        {
            playButton.onClick.Invoke();
        }

        // Verify all clicks invoked the listener
        Assert.AreEqual(clicks, invokedCount, $"All {clicks} simulated clicks should invoke the listener.");
        Debug.Log($"Play button survived {clicks} clicks without errors.");
    }

    [Test]
    public void PlayButton_CanHandleMultipleListeners_Stress()
    {
        int clicks = 100000000;
        int listener1 = 0;
        int listener2 = 0;

        // Add multiple mock listeners
        playButton.onClick.AddListener(() => listener1++);
        playButton.onClick.AddListener(() => listener2++);

        for (int i = 0; i < clicks; i++)
        {
            playButton.onClick.Invoke();
        }

        Assert.AreEqual(clicks, listener1, "Listener1 should be invoked on every click.");
        Assert.AreEqual(clicks, listener2, "Listener2 should be invoked on every click.");
        Debug.Log($"Play button handled {clicks} clicks with multiple listeners successfully.");
    }
}
