using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MenuBase
{
    // STATE PATTERN EXPLANATION:
    // -------------------------------------------------------------
    // MainMenu represents a *state* the game can be in — specifically,
    // the "Main Menu State" that exists before gameplay starts.
    //
    // By inheriting from MenuBase, this class provides the specific
    // behavior for this particular state. Each state (MainMenu, PauseMenu,
    // etc.) overrides the same base methods but performs different actions.
    //
    // When the game is in the Main Menu State:
    //   - PlayGame() means "transition to gameplay"
    //   - Quit() means "exit the application"
    //
    // These behaviors are *state-specific*, not global. That is why
    // the State Pattern fits: each state defines its own version of
    // the shared actions from MenuBase.
    // Called when the "Play" button is pressed.
    // This command loads the next scene in the Build Settings list.
    public void PlayGame() //Cant be priivate because of inheritance
    {
        // Load the next scene by index.

        SceneManager.LoadScene("MainScene");

        // Alternative method: load by scene index asynchronously.
        // SceneManager.LoadSceneAsync(1);
    }

    // Called when the "Quit" button is pressed.
    // This command exits the application.
    public override void Quit() //Cant be priivate because of inheritance
    {

        Application.Quit();

        // Log message appears in the Editor for testing purposes,
        // since Application.Quit() only works in a built game.
        Debug.Log("Player Has Quit the Game");
    }
}
