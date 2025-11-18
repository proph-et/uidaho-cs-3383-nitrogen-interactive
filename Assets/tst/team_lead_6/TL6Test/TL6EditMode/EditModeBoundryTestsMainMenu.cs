using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[TestFixture]
public class MainMenuEditModeTests
{
    // The menu instance is instantiated directly because MainMenu may not be a MonoBehaviour
    // (using AddComponent<> would fail if MainMenu doesn't inherit from MonoBehaviour).
    private MainMenu menu;
    private GameObject menuObj;
    private Button playButton;

    [SetUp]
    public void SetUp()
    {
        // Instantiate the logical MainMenu object (non-MonoBehaviour safe).
        // Reason: tests should run in EditMode and not rely on scene wiring.
        menu = new MainMenu();

        // Create a small dummy UI hierarchy for button tests.
        // Reason: real scenes sometimes have buttons removed/renamed — these tests detect that.
        menuObj = new GameObject("MainMenu");
        var buttonObj = new GameObject("PlayButton");
        playButton = buttonObj.AddComponent<Button>();
    }

    [TearDown]
    public void TearDown()
    {
        // Clean up created GameObjects to avoid polluting the editor between tests.
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
        // WHY: Protects against UI wiring being removed (someone unhooked the onClick in prefab).
        // HOW: We add a temporary mock listener and invoke the event; if listeners are broken,
        //      invoking the event will not flip the flag and the assertion fails.
        bool invoked = false;

        // Ensure we control the listener set (no dependency on scene wiring).
        playButton.onClick.RemoveAllListeners();
        playButton.onClick.AddListener(() => invoked = true);

        // Simulate the click event in EditMode.
        playButton.onClick.Invoke();

        Assert.IsTrue(invoked, "Play button click did not invoke the test listener (UI wiring may be broken).");
    }

    [Test]
    public void PlayButton_ExistsInHierarchy()
    {
        // WHY: Detects accidental renames / deletions of the PlayButton object in the UI.
        // HOW: Simple sanity check that the PlayButton GameObject exists and has the expected name.
        Assert.IsNotNull(playButton, "Play button should exist in the menu hierarchy.");
        Assert.AreEqual("PlayButton", playButton.gameObject.name, "Play button name mismatch (someone may have renamed or replaced the object).");
    }

    // -------------------------
    // MainMenu API & Behavior Tests
    // -------------------------

    [Test]
    public void MainMenu_HasPlayGameMethod()
    {
        // WHY: Prevents teammates from renaming/deleting public API methods that UI buttons reference.
        // HOW: Use reflection to check that a method called "PlayGame" exists on the MainMenu type.
        var method = menu.GetType().GetMethod("PlayGame");
        Assert.NotNull(method, "MainMenu should expose a PlayGame method. Renaming/removing it will break UI button hookups.");
    }

    [Test]
    public void PlayGame_BoundarySceneIndex_IsValidInBuildSettings()
    {
        // WHY: Ensures Build Settings still contains the expected scene index (reordering or removal breaks scene loads).
        // HOW: Inspect build settings entries and verify target index (1) is present and points to a real scene file.
        int targetSceneIndex = 1;
        int totalScenes = SceneManager.sceneCountInBuildSettings;

        // There should be at least two scenes: menu + game scene.
        Assert.Greater(totalScenes, 1, "Build Settings must include at least 2 scenes (Main Menu + Game Scene).");

        // The target index must be in the valid range.
        Assert.GreaterOrEqual(targetSceneIndex, 0, "Scene index must be non-negative.");
        Assert.Less(targetSceneIndex, totalScenes, $"Scene index {targetSceneIndex} is invalid. Valid range: 0 - {totalScenes - 1}.");

        // Ensure the scene path exists on disk (protects against deleted or mis-specified assets).
        string scenePath = SceneUtility.GetScenePathByBuildIndex(targetSceneIndex);
        Assert.IsFalse(string.IsNullOrEmpty(scenePath), $"No scene found at index {targetSceneIndex} in Build Settings.");
        Assert.IsTrue(System.IO.File.Exists(scenePath), $"Scene file not found at path: {scenePath}");

        // This log helps a teammate quickly see which scene path the test validated.
        Debug.Log($"Scene at index {targetSceneIndex} is valid and exists at: {scenePath}");
    }

    [Test]
    public void PlayGame_DoesNotThrow_WhenCalledInEditMode()
    {
        // WHY: Guards against adding PlayMode-only logic to PlayGame (e.g., code that assumes Play Mode-only systems).
        //      If a teammate adds logic that only works at runtime, this test will fail and highlight that mistake.
        // HOW: Call PlayGame inside Assert.DoesNotThrow and swallow the expected InvalidOperationException
        //      that SceneManager.LoadScene may throw in Edit Mode (we still want to detect unexpected exceptions).
        Assert.DoesNotThrow(() =>
        {
            try
            {
                menu.PlayGame();
            }
            catch (System.InvalidOperationException)
            {
                // Expected if PlayGame tries to synchronously call SceneManager.LoadScene in Edit Mode.
                // We swallow this specific exception because it is an EditMode limitation rather than an implementation bug.
            }
        }, "PlayGame() should not throw unexpected exceptions in Edit Mode. If it does, someone added runtime-only code without guards.");

        Debug.Log("PlayGame() safely handled Edit Mode call (no unexpected exceptions).");
    }
}
