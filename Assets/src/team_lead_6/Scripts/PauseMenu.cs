using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // This script primarily follows the STATE PATTERN.
    // -------------------------------------------------------------
    // The game has two main states:
    //    1. Playing (Paused == false)
    //    2. Paused  (Paused == true)
    //
    // The script changes behavior based on which state the game is in.
    // When the player presses Escape, it toggles between those states
    // by calling Play() or Stop().
    // -------------------------------------------------------------

    // Static variable tracks the current "state" of the game.
    public static bool Paused = false;

    // Reference to the pause menu UI Canvas.
    public GameObject PauseMenuCanvas;

    void Start()
    {
        // Ensure the game starts in the "Playing" state.
        Time.timeScale = 1f;
    }

    void Update()
    {
        // Listen for the Escape key each frame.
        // If pressed, toggle between Paused and Playing states.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                // If game is currently paused, resume it.
                Play();
            }
            else
            {
                // If game is currently playing, pause it.
                Stop();
            }
        }
    }

    // -------------------------------------------------------------
    // STATE: Transition from "Playing" → "Paused"
    // -------------------------------------------------------------
    public void Stop()
    {
        // Show the pause menu UI.
        PauseMenuCanvas.SetActive(true);

        // Stop in-game time so everything freezes.
        Time.timeScale = 0f;

        // Update the state flag.
        Paused = true;
    }

    // -------------------------------------------------------------
    // STATE: Transition from "Paused" → "Playing"
    // -------------------------------------------------------------
    public void Play()
    {
        // Hide the pause menu UI.
        PauseMenuCanvas.SetActive(false);

        // Resume normal time flow.
        Time.timeScale = 1f;

        // Update the state flag.
        Paused = false;
    }

    // -------------------------------------------------------------
    // Load the main menu scene.
    // This method can be linked to a UI button, encapsulating the
    // logic for quitting to the main menu.
    // -------------------------------------------------------------
    public void MainMenuButton()
    {
        // Load the first scene (index 0) asynchronously.
        // Scene indexes are set in the Build Settings.
        
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        SceneManager.LoadSceneAsync(0);
    }
}

// +--------------------------------------+
// |            MonoBehaviour             |
// +--------------------------------------+
//                 ▲
//                 |
// +--------------------------------------+
// |              PauseMenu               |
// +--------------------------------------+
// | + PauseMenuCanvas : GameObject       |
// | + static Paused : bool               |
// +--------------------------------------+
// | + Start()                            |
// | + Update()                           |
// | + Stop()                             |
// | + Play()                             |
// | + MainMenuButton()                   |
// +--------------------------------------+
//                 |
//                 | modifies
//                 v
// +--------------------------------------+
// |           Time (UnityEngine)         |
// +--------------------------------------+
// | + timeScale : float                  |
// +--------------------------------------+

//                 |
//                 | accesses
//                 v
// +--------------------------------------+
// |           GameObject                 |
// +--------------------------------------+
// | + SetActive(active : bool)           |
// +--------------------------------------+

//                 |
//                 | loads scenes through
//                 v
// +--------------------------------------+
// |       SceneManager (UnityEngine)     |
// +--------------------------------------+
// | + LoadSceneAsync(index : int)        |
// +--------------------------------------+
