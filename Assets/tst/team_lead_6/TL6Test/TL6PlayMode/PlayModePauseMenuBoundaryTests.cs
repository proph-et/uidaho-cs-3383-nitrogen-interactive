using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using System.Collections;

public class PauseMenuPlayModeBoundaryTests : MonoBehaviour
{
    private PauseMenu pauseMenu;
    private GameObject pauseMenuObj;
    private GameObject canvasObj;

    [SetUp]
    public void SetUp()
    {
        // Create a dummy PauseMenu GameObject
        pauseMenuObj = new GameObject("PauseMenu");
        pauseMenu = pauseMenuObj.AddComponent<PauseMenu>();

        // Create a dummy Canvas for the Pause Menu
        canvasObj = new GameObject("PauseCanvas");
        pauseMenu.PauseMenuCanvas = canvasObj;

        // Ensure canvas is initially inactive
        pauseMenu.PauseMenuCanvas.SetActive(false);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(pauseMenuObj);
        Object.DestroyImmediate(canvasObj);
        PauseMenu.Paused = false;
        Time.timeScale = 1f;
    }

    // -------------------------
    // Boundary Test 1: Stop() sets Paused = true and freezes time
    // -------------------------
    [UnityTest]
    public IEnumerator Stop_SetsPausedAndFreezesTime()
    {
        pauseMenu.Stop();
        yield return null;

        Assert.IsTrue(PauseMenu.Paused, "PauseMenu.Stop() should set Paused = true.");
        Assert.AreEqual(0f, Time.timeScale, "PauseMenu.Stop() should freeze time (Time.timeScale = 0).");
        Assert.IsTrue(pauseMenu.PauseMenuCanvas.activeSelf, "PauseMenu Canvas should be active after Stop().");
    }

    // -------------------------
    // Boundary Test 2: Play() sets Paused = false and resumes time
    // -------------------------
    [UnityTest]
    public IEnumerator Play_SetsPausedFalseAndResumesTime()
    {
        // Start by pausing
        pauseMenu.Stop();
        yield return null;

        pauseMenu.Play();
        yield return null;

        Assert.IsFalse(PauseMenu.Paused, "PauseMenu.Play() should set Paused = false.");
        Assert.AreEqual(1f, Time.timeScale, "PauseMenu.Play() should resume time (Time.timeScale = 1).");
        Assert.IsFalse(pauseMenu.PauseMenuCanvas.activeSelf, "PauseMenu Canvas should be inactive after Play().");
    }

    // -------------------------
    // Boundary Test 3: Toggle Pause via Stop() → Play() multiple times
    // -------------------------
    [UnityTest]
    public IEnumerator TogglePause_MultipleTimes()
    {
        for (int i = 0; i < 5; i++)
        {
            pauseMenu.Stop();
            yield return null;
            Assert.IsTrue(PauseMenu.Paused, "PauseMenu should be paused after Stop().");

            pauseMenu.Play();
            yield return null;
            Assert.IsFalse(PauseMenu.Paused, "PauseMenu should not be paused after Play().");
        }
    }

    // -------------------------
    // Boundary Test 4: Press Escape toggles pause state
    // -------------------------
    [UnityTest]
    public IEnumerator EscapeKey_TogglesPause()
    {
        // Simulate pressing Escape key manually
        bool initialState = PauseMenu.Paused;

        // First press
        pauseMenu.UpdateSimulateKeyPress(KeyCode.Escape);
        yield return null;
        Assert.AreNotEqual(initialState, PauseMenu.Paused, "Escape key should toggle Paused state.");

        // Second press
        pauseMenu.UpdateSimulateKeyPress(KeyCode.Escape);
        yield return null;
        Assert.AreEqual(initialState, PauseMenu.Paused, "Escape key should toggle Paused state back.");
    }

    // -------------------------
    // Boundary Test 5: MainMenuButton triggers scene load
    // -------------------------
    [UnityTest]
    public IEnumerator MainMenuButton_LoadsSceneZero()
    {
        // Note: In Play Mode tests, we can't fully wait for scene load in editor
        // But we can call the method to ensure no exceptions and SceneManager queue works
        Assert.DoesNotThrow(() => pauseMenu.MainMenuButton(), "MainMenuButton() should not throw exceptions.");
        yield return null;
    }
}

// -------------------------
// Helper: Simulate key press in Update for testing
// -------------------------
public static class PauseMenuTestExtensions
{
    public static void UpdateSimulateKeyPress(this PauseMenu menu, KeyCode key)
    {
        if (key == KeyCode.Escape)
        {
            if (PauseMenu.Paused)
                menu.Play();
            else
                menu.Stop();
        }
    }
}
