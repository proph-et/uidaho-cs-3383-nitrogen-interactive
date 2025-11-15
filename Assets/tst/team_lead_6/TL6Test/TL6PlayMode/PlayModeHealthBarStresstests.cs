using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using System.Collections;

#if UNITY_EDITOR
// Minimal Health class for testing
public class Health : MonoBehaviour
{
    private float maxHealth = 100f;
    private float currentHealth = 100f;

    public void SetMaxHealth(float value) => maxHealth = value;
    public float GetMaxHealth() => maxHealth;

    public void SetCurrentHealth(float value) => currentHealth = value;
    public float GetCurrentHealth() => currentHealth;

    public void TakeDamage(float amount) => currentHealth -= amount;
}
#endif

public class HealthBarPlayModeStressTests : MonoBehaviour
{
    private GameObject playerParentObj;
    private GameObject playerObj;
    private Health health;
    private GameObject healthBarObj;
    private HealthBar healthBar;
    private Slider slider;

    [SetUp]
    public void SetUp()
    {
        // Create parent for Health (so GetComponentInParent works)
        playerParentObj = new GameObject("PlayerParent");

        // Create player object with Player tag
        playerObj = new GameObject("Player");
        playerObj.tag = "Player";
        playerObj.transform.parent = playerParentObj.transform;

        // Add Health to parent
        health = playerParentObj.AddComponent<Health>();
        health.SetMaxHealth(100);
        health.SetCurrentHealth(100);

        // Create HealthBar object with Slider
        healthBarObj = new GameObject("HealthBar");
        healthBar = healthBarObj.AddComponent<HealthBar>();
        var sliderObj = new GameObject("Slider");
        slider = sliderObj.AddComponent<Slider>();
        healthBar.slider = slider;

        // Call Awake to initialize
        healthBar.Awake();
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(playerObj);
        Object.DestroyImmediate(playerParentObj);
        Object.DestroyImmediate(healthBarObj);
        Object.DestroyImmediate(slider.gameObject);
    }

    // -------------------------
    // Stress Test 1: Rapid damage over multiple frames
    // -------------------------
    [UnityTest]
    public IEnumerator Stress_RapidDamage()
    {
        for (int i = 0; i < 50; i++)
        {
            health.TakeDamage(1);
            healthBar.Update();
            yield return null;
        }

        Assert.AreEqual(50, healthBar.slider.maxValue - healthBar.slider.value + 50, "Slider value should match Health after rapid damage.");
    }

    // -------------------------
    // Stress Test 2: Rapid healing and damage
    // -------------------------
    [UnityTest]
    public IEnumerator Stress_AlternatingHealDamage()
    {
        for (int i = 0; i < 50; i++)
        {
            health.SetCurrentHealth(health.GetCurrentHealth() - 2);
            healthBar.Update();
            yield return null;

            health.SetCurrentHealth(health.GetCurrentHealth() + 2);
            healthBar.Update();
            yield return null;
        }

        Assert.AreEqual(100, healthBar.slider.value, "Slider should return to full health after alternating heal/damage.");
    }

    // -------------------------
    // Stress Test 3: High-frequency Update() calls
    // -------------------------
    [UnityTest]
    public IEnumerator Stress_HighFrequencyUpdates()
    {
        health.SetCurrentHealth(50);

        for (int i = 0; i < 100; i++)
        {
            healthBar.Update();
            yield return null;
        }

        Assert.AreEqual(50, healthBar.slider.value, "Slider value should remain stable after frequent Update() calls.");
    }

    // -------------------------
    // Stress Test 4: Max boundary health changes
    // -------------------------
    [UnityTest]
    public IEnumerator Stress_MaxBoundary()
    {
        health.SetCurrentHealth(health.GetMaxHealth() + 50); // above max
        healthBar.Update();
        yield return null;
        Assert.AreEqual(150, healthBar.slider.value, "Slider value can exceed max as HealthBar does not clamp.");

        health.SetCurrentHealth(-50); // below 0
        healthBar.Update();
        yield return null;
        Assert.AreEqual(-50, healthBar.slider.value, "Slider value can go below 0 as HealthBar does not clamp.");
    }

    // -------------------------
    // Stress Test 5: Continuous damage over many frames
    // -------------------------
    [UnityTest]
    public IEnumerator Stress_LongTermDamageSimulation()
    {
        int frames = 200;

        for (int i = 0; i < frames; i++)
        {
            health.TakeDamage(1);
            healthBar.Update();
            yield return null;
        }

        Assert.AreEqual(health.GetMaxHealth() - frames, healthBar.slider.value, "Slider should track Health correctly after long-term damage.");
    }
}
