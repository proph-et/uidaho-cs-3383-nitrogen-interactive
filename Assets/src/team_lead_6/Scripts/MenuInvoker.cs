using UnityEngine;

//This class MUST be public (or left with no access modifier)
// because C# does NOT allow classes defined at the *namespace level*
// to be private, protected, or private protected.
//
// In C#, "private" only applies to members INSIDE a class.
// It cannot be used on a class that sits directly in a namespace.
//
// If we try to make MenuInvoker private, the compiler errors:
//   "CS1527: Elements defined in a namespace cannot be explicitly
//    declared as private, protected, protected internal,
//    or private protected."
//
// Unity ALSO requires MonoBehaviour classes to be accessible
// so that it can:
//   - Attach them to GameObjects
//   - Instantiate them
//   - Call lifecycle methods (Awake, Update, etc.)


// MenuInvoker is the Context in the State Pattern. 
// It stores a reference to a MenuBase (the base state) 
// but actually holds a concrete state like MainMenu. 
// When buttons call PlayGame or Quit, the behavior depends on which state is active.
// MenuInvoker doesn't need to know which menu type it is using  
// it just delegates actions to the current state, which is exactly how the State Pattern works.


public class MenuInvoker : MonoBehaviour
{
    private MenuBase menu;

    void Awake()
    {
        // Get the MenuBase component (which will actually be a MainMenu)
        menu = new MainMenu();
    }

    // This will be linked to the button OnClick in the inspector
    private void OnPlayButtonClicked()
    {
        // Now we call through the BASE CLASS reference
        // This uses dynamic binding to run the MainMenu version of PlayGame()
        menu.PlayGame();
    }

    private void OnQuitButtonClicked()
    {
        menu.Quit();
    }
}

