using UnityEngine;

// Base class for all menu types
public abstract class MenuBase : MonoBehaviour
{
    // Virtual methods allow child classes to override them dynamically
    public virtual void PlayGame()
    {
        Debug.Log("Play a generic Scene...");
    }

    public virtual void Quit()
    {
        Debug.Log("Quit a generic Scene...");
    }

}
