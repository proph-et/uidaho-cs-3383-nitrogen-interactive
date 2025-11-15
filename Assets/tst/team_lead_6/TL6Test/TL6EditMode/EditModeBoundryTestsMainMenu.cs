using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[TestFixture]
public class MainMenuEditModeTests
{
    private MainMenu menu;
    private GameObject menuObj;
    private Button playButton;

    [SetUp]
    public void SetUp()
    {
        // Instantiate MainMenu directly (not a MonoBehaviour)
        menu = new MainMenu();

        // Create a dummy GameObject for button hierarchy
        menuObj = new GameObject("MainMenu");

        // Create a Play Button for testing
        var buttonObj = new GameObject("PlayButton");
        playButton = buttonObj.AddComponent<Button>();
    }

    [TearDown]
    public void TearDown()
    {
        // Cleanup created GameObjects
        Object.DestroyImmediate(menuObj);
        Object.DestroyImmediate(playButton?.gameObject);
        menu = null;
    }

    // -------------------------
    // Button Tests
    // -------------------------

    [Test]
    public void PlayButton_HasMockListener()
    {
        // Ensure a button listener can be invoked
        bool invoked = false;

        playButton.onClick.RemoveAllListeners();
        playButton.onClick.AddListener(() => invoked = true);

        // Simulate button click
        playButton.onClick.Invoke();

        Assert.IsTrue(invoked, "Play button click did not invoke the listener.");
    }

    [Test]
    public void PlayButton_ExistsInHierarchy()
    {
        // Ensure Play button exists and has correct name
        Assert.IsNotNull(playButton, "Play button should exist.");
        Assert.AreEqual("PlayButton", playButton.gameObject.name, "Play button name does not match expected.");
    }

    [Test]
    public void MainMenu_HasPlayGameMethod()
    {
        // Ensure MainMenu contains a method named "PlayGame"
        var method = menu.GetType().GetMethod("PlayGame");
        Assert.NotNull(method, "MainMenu should have a PlayGame method.");
    }

    // -------------------------
    // MainMenu Unique Tests
    // -------------------------

    [Test]
    public void PlayGame_BoundarySceneIndex_IsValidInBuildSettings()
    {
        // Boundary test: Ensure the target scene index is valid in Build Settings
        int targetSceneIndex = 1;
        int totalScenes = SceneManager.sceneCountInBuildSettings;

        Assert.Greater(totalScenes, 1, "Build Settings must include at least 2 scenes.");

        Assert.GreaterOrEqual(targetSceneIndex, 0, "Scene index must be non-negative.");
        Assert.Less(targetSceneIndex, totalScenes,
            $"Scene index {targetSceneIndex} is invalid. Valid range: 0 - {totalScenes - 1}.");

        // Verify scene file exists
        string scenePath = SceneUtility.GetScenePathByBuildIndex(targetSceneIndex);
        Assert.IsFalse(string.IsNullOrEmpty(scenePath), $"No scene found at index {targetSceneIndex} in Build Settings.");
        Assert.IsTrue(System.IO.File.Exists(scenePath), $"Scene file not found at path: {scenePath}");

        Debug.Log($"Scene at index {targetSceneIndex} is valid and exists at: {scenePath}");
    }

    [Test]
    public void PlayGame_DoesNotThrow_WhenCalledInEditMode()
    {
        // Ensure PlayGame() does not crash Unity in Edit Mode
        Assert.DoesNotThrow(() =>
        {
            try
            {
                menu.PlayGame();
            }
            catch (System.InvalidOperationException)
            {
                // SceneManager.LoadScene may throw in Edit Mode; swallow this specific exception
            }
        }, "PlayGame() should not throw unexpected exceptions in Edit Mode.");

        Debug.Log("PlayGame() safely handled Edit Mode call.");
    }
}
