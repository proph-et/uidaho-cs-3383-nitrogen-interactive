using UnityEngine;
using UnityEngine.SceneManagement;
// STATE PATTERN EXPLANATION:
    //
    // MenuBase is the *abstract parent state* for all menu states.
    // It defines the common actions that every menu state must support
    // (PlayGame and Quit), but it does NOT decide how those actions behave.
    //
    // Instead, child classes like MainMenu, PauseMenu, GameOverMenu, etc.
    // override these methods to provide their own state-specific behavior.
    //
    // This is exactly how the State Pattern works:
    //   - MenuBase = the "State" interface/base.
    //   - Each menu class = a "Concrete State."
    //   - The game switches states by using different subclasses.
    //
    // The virtual keyword allows dynamic binding: Unity 
    // will call the correct version depending on which menu state
    // is currently active.

// Base class for all menu types
public class MenuBase
{
    // Virtual methods allow child classes to override them dynamically
    public virtual void PlayGame() // Cannot be private becasue Unitys said "virtual or Abstract methods cannot be private"
    {
        SceneManager.LoadScene("Boss");
    }

    public virtual void Quit() // Cannot be private becasue Unitys said "virtual or Abstract methods cannot be private"
    {
        Debug.Log("Quit a generic Scene...");
    }

}
