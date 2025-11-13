using UnityEngine;

public class MenuInvoker : MonoBehaviour
{
    private MenuBase menu;

    void Awake()
    {
        // Get the MenuBase component (which will actually be a MainMenu)
        menu = GetComponent<MenuBase>();
    }

    // This will be linked to the button OnClick in the inspector
    public void OnPlayButtonClicked()
    {
        // Now we call through the BASE CLASS reference!
        // This uses dynamic binding to run the MainMenu version of PlayGame()
        menu.PlayGame();
    }
}

