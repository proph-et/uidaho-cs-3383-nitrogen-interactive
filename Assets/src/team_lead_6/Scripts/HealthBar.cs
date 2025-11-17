using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public Gradient gradient;

    //private Image fill;
    private Health health;
    private GameObject player;

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;

        //fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }

    public void Awake()
    {
        player = GameObject.FindWithTag("Player");
        health = player.GetComponentInParent<Health>();
        SetMaxHealth(health.GetMaxHealth());
    }

    public void Update()
    {
        SetHealth(health.GetCurrentHealth());

        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("Play a generic Scene...");
            health.TakeDamage(10);
        }

        //fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}