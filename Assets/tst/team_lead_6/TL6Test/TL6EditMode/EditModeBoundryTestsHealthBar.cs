using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
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

[TestFixture]
public class HealthBarEditModeBoundaryTests
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
        health.SetCurrentHealth(50);

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

    [Test]
    public void SetMaxHealth_InitializesSlider()
    {
        Assert.AreEqual(health.GetMaxHealth(), slider.maxValue);
        Assert.AreEqual(health.GetMaxHealth(), slider.value);
    }

    [Test]
    public void SetHealth_UpdatesSliderValue()
    {
        healthBar.SetHealth(80);
        Assert.AreEqual(80, slider.value);

        healthBar.SetHealth(0);
        Assert.AreEqual(0, slider.value);
    }

    [Test]
    public void Awake_HandlesPlayerAndHealthSetup()
    {
        Assert.NotNull(healthBar.slider);
        Assert.NotNull(health);
        Assert.NotNull(playerObj);
    }

    [Test]
    public void Update_ReflectsHealthChanges()
    {
        health.SetCurrentHealth(30);
        healthBar.Update();
        Assert.AreEqual(30, slider.value);

        health.SetCurrentHealth(90);
        healthBar.Update();
        Assert.AreEqual(90, slider.value);
    }

    [Test]
    public void TakeDamage_UpdatesSliderCorrectly()
    {
        float initial = health.GetCurrentHealth();
        health.TakeDamage(10);
        healthBar.Update();
        Assert.AreEqual(initial - 10, slider.value);
    }
}
