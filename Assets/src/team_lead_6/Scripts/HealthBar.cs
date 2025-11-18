using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// OBSERVER PATTERN (Unity Style)
// ------------------------------------------------------------
// This script acts as an *observer* of the player's Health.
// The Health component is the "subject," and this UI script
// updates itself based on the subject's current state.
// this script uses Unity's Update loop to *pull* the latest
// health value each frame. 
// The HealthBar does not control or modify the Health system.
// It simply watches ("observes") the player's health and
// updates the UI when the Health value changes.
public class HealthBar : MonoBehaviour
{
    public Slider slider; // needs to be public to be set in inspector
    private Health health;
    private GameObject player;

    public void SetMaxHealth(float health) 
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(float health) 
    {
        slider.value = health;
    }

    public void Awake()
    {
        // Find the player object and get the Health component
        // This establishes the observer → subject relationship.
        player = GameObject.FindWithTag("Player");
        health = player.GetComponentInParent<Health>();
        SetMaxHealth(health.GetMaxHealth());
    }

    public void Update()
    {
        // Every frame, the HealthBar "checks in" with the subject
        // (the Health component) to see if the data changed.
        // This is a pull-style observer instead of push events.

        SetHealth(health.GetCurrentHealth());

        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("Play a generic Scene...");
            health.TakeDamage(10);
        }


    }
}

// +--------------------------------------+
// |          MonoBehaviour               |
// +--------------------------------------+
//                 ▲
//                 |
// +--------------------------------------+
// |             HealthBar                |
// +--------------------------------------+
// | - slider : Slider                    |
// | - health : Health                    |
// | - player : GameObject                |
// +--------------------------------------+
// | + SetMaxHealth(health : float)       |
// | + SetHealth(health : float)          |
// | + Awake()                            |
// | + Update()                           |
// +--------------------------------------+
//                 |
//      observes ("pulls state from")
//                 v
// +--------------------------------------+
// |               Health                 |
// +--------------------------------------+
// | + GetMaxHealth() : float             |
// | + GetCurrentHealth() : float         |
// | + TakeDamage(amount : float)         |
// +--------------------------------------+

// +--------------------------------------+
// |               Slider                 |
// +--------------------------------------+
// | + maxValue : float                   |
// | + value : float                      |
// +--------------------------------------+

// +--------------------------------------+
// |             GameObject               |
// +--------------------------------------+
// | + tag : string                       |
// | + GetComponentInParent<T>()          |
// +--------------------------------------+
