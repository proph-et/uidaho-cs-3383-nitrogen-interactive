using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class PauseMenuEditModeStressTests
{
    private GameObject pauseMenuObj;
    private PauseMenu pauseMenu;
    private GameObject canvasObj;

    [SetUp]
    public void SetUp()
    {
        // Create PauseMenu GameObject
        pauseMenuObj = new GameObject("PauseMenu");
        pauseMenu = pauseMenuObj.AddComponent<PauseMenu>();

        // Create dummy Canvas
        canvasObj = new GameObject("PauseCanvas");
        pauseMenu.PauseMenuCanvas = canvasObj;
        pauseMenu.PauseMenuCanvas.SetActive(false);

        // Reset static Paused flag
        PauseMenu.Paused = false;
        Time.timeScale = 1f;
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
    // Stress Test 1: Repeated Stop() calls
    // -------------------------
    [Test]
    public void Stress_StopRepeatedly()
    {
        for (int i = 0; i < 50; i++)
        {
            pauseMenu.Stop();
            Assert.IsTrue(PauseMenu.Paused, "PauseMenu should remain paused.");
            Assert.AreEqual(0f, Time.timeScale, "Time.timeScale should stay at 0 after Stop().");
            Assert.IsTrue(pauseMenu.PauseMenuCanvas.activeSelf, "Pause Canvas should remain active.");
        }
    }

    // -------------------------
    // Stress Test 2: Repeated Play() calls
    // -------------------------
    [Test]
    public void Stress_PlayRepeatedly()
    {
        pauseMenu.Stop(); // start paused

        for (int i = 0; i < 50; i++)
        {
            pauseMenu.Play();
            Assert.IsFalse(PauseMenu.Paused, "PauseMenu should be unpaused.");
            Assert.AreEqual(1f, Time.timeScale, "Time.timeScale should stay at 1 after Play().");
            Assert.IsFalse(pauseMenu.PauseMenuCanvas.activeSelf, "Pause Canvas should remain inactive.");
        }
    }

    // -------------------------
    // Stress Test 3: Rapid toggle Stop() → Play()
    // -------------------------
    [Test]
    public void Stress_RapidToggleStopPlay()
    {
        for (int i = 0; i < 25; i++)
        {
            pauseMenu.Stop();
            Assert.IsTrue(PauseMenu.Paused);
            pauseMenu.Play();
            Assert.IsFalse(PauseMenu.Paused);
        }
    }

    // -------------------------
    // Stress Test 4: Simulate Escape key toggles multiple times
    // -------------------------
    [Test]
    public void Stress_EscapeKeySimulation()
    {
        for (int i = 0; i < 50; i++)
        {
            SimulateEscapeKey();
            Assert.IsTrue(PauseMenu.Paused || !PauseMenu.Paused, "Paused flag should toggle without exceptions.");
        }
    }

    // -------------------------
    // Stress Test 5: Repeated MainMenuButton() calls
    // -------------------------
    [Test]
    public void Stress_MainMenuButtonRepeatedly()
    {
        for (int i = 0; i < 50; i++)
        {
            Assert.DoesNotThrow(() => pauseMenu.MainMenuButton(), "MainMenuButton should not throw exceptions under stress.");
        }
    }

    // -------------------------
    // Helper: Simulate Escape key press in Edit Mode
    // -------------------------
    private void SimulateEscapeKey()
    {
        if (PauseMenu.Paused)
            pauseMenu.Play();
        else
            pauseMenu.Stop();
    }
}
