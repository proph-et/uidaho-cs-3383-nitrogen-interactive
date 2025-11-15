using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MenuBase
{
    // This script follows the Command Pattern.
    // -------------------------------------------------------
    // Each public method (PlayGame, Quit) acts as a "command"
    // that can be triggered by Unity UI buttons.
    // The buttons don’t need to know what the methods do —
    // they just execute a command when clicked.
    // This keeps UI logic (button presses) separate from the
    // functional logic (loading scenes, quitting the game).
    // -------------------------------------------------------

    // Called when the "Play" button is pressed.
    // This command loads the next scene in the Build Settings list.
    public override void PlayGame()
    {
        // Load the next scene by index.

        SceneManager.LoadScene("MainScene");

        // Alternative method: load by scene index asynchronously.
        // SceneManager.LoadSceneAsync(1);
    }

    // Called when the "Quit" button is pressed.
    // This command exits the application.
    public override void Quit()
    {

        Application.Quit();

        // Log message appears in the Editor for testing purposes,
        // since Application.Quit() only works in a built game.
        Debug.Log("Player Has Quit the Game");
    }
}
