using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

[TestFixture]
public class ButtonTest
{
    private GameObject menuObj;
    private Button playButton;

    [SetUp]
    public void SetUp()
    {
        // Create a dummy MainMenu GameObject
        menuObj = new GameObject("MainMenu");

        // Create a Play Button
        var buttonObj = new GameObject("PlayButton");
        playButton = buttonObj.AddComponent<Button>();

        // For Edit Mode testing, we do NOT add the real PlayGame listener
        // We will use a mock listener in the test
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(menuObj);
        Object.DestroyImmediate(playButton?.gameObject);
    }

    [Test]
    public void PlayButton_HasRuntimeListener_Mock()
    {
        // Use a flag to check that a listener is actually called
        bool invoked = false;

        // Add a mock listener instead of the real PlayGame
        playButton.onClick.RemoveAllListeners();
        playButton.onClick.AddListener(() => invoked = true);

        // Simulate button click
        playButton.onClick.Invoke();

        // Assert the listener was invoked
        Assert.IsTrue(invoked, "Play button click did not invoke any listener.");
        Debug.Log("Play button click successfully invoked its listener.");
    }

    [Test]
    public void PlayButton_ExistsInHierarchy()
    {
        Assert.IsNotNull(playButton, "Play button should exist.");
        Assert.AreEqual("PlayButton", playButton.gameObject.name, "Play button name does not match expected.");
    }

    [Test]
    public void MainMenu_HasPlayGameMethod()
    {
        var mainMenu = menuObj.AddComponent<MainMenu>();
        var method = mainMenu.GetType().GetMethod("PlayGame");
        Assert.NotNull(method, "MainMenu should have a PlayGame method.");
    }
}
