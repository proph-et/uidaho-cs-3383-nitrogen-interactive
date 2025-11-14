using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Shop : MonoBehaviour
{
    public Inventory playerInventory;


    // public void UpgradeSword()
    // {
    //     playerInventory.AddItem(sword);
    // }
    //
    // public void UpgradeBow()
    // {
    //     playerInventory.AddItem(bow);
    // }
    //
    // public void UpgradeWand()
    // {
    //     playerInventory.AddItem(wand);
    // }


    // Static variable tracks the current "state" of the game.
    public static bool Paused = false;

    // Reference to the pause menu UI Canvas.
    public GameObject ShopInterface;

    public SMScript audioManager;

    void Start()
    {
        // Ensure the game starts in the "Playing" state.
        Time.timeScale = 1f;
    }

    void Update()
    {
        // Listen for the Escape key each frame.
        // If pressed, toggle between Paused and Playing states.
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("opened shop");
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
        ShopInterface.SetActive(true);

        // Stop in-game time so everything freezes.
        Time.timeScale = 0f;

        // Update the state flag.
        Paused = true;
        audioManager.pauseBackgroundMusic();
    }

    // -------------------------------------------------------------
    // STATE: Transition from "Paused" → "Playing"
    // -------------------------------------------------------------
    public void Play()
    {
        // Hide the pause menu UI.
        ShopInterface.SetActive(false);

        // Resume normal time flow.
        Time.timeScale = 1f;

        // Update the state flag.
        Paused = false;
        audioManager.unpauseBackgroundMusic();
        
        
    }
}