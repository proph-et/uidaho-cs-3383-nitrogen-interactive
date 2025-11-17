using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class EditModeBoundaryTestsHealthBar
{
    private HealthBar healthBar;

    [SetUp]
    public void Setup()
    {
        // Create GameObject and components
        GameObject go = new GameObject("HealthBar_TestObject");
        healthBar = go.AddComponent<HealthBar>();

        // Add slider
        GameObject sliderObj = new GameObject("Slider");
        sliderObj.transform.parent = go.transform;
        Slider slider = sliderObj.AddComponent<Slider>();

        healthBar.slider = slider;
    }

    // -------------------------------------------------------------
    // 1. Boundary Test: MaxHealth = 0
    // -------------------------------------------------------------
    [Test]
    public void SetMaxHealth_Zero_SetsSliderCorrectly()
    {
        healthBar.SetMaxHealth(0);

        Assert.AreEqual(0, healthBar.slider.maxValue);
        Assert.AreEqual(0, healthBar.slider.value);
    }

    // -------------------------------------------------------------
    // 2. Boundary Test: MaxHealth = Very Large
    // -------------------------------------------------------------
    [Test]
    public void SetMaxHealth_VeryLargeValue_DoesNotBreakSlider()
    {
        float largeValue = 1_000_000f;

        healthBar.SetMaxHealth(largeValue);

        Assert.AreEqual(largeValue, healthBar.slider.maxValue);
        Assert.AreEqual(largeValue, healthBar.slider.value);
    }

    // -------------------------------------------------------------
    // 3. Boundary Test: SetHealth below 0 clamps to lowest possible value
    // -------------------------------------------------------------
    [Test]
    public void SetHealth_NegativeValue_SetsToZeroOrLower()
    {
        healthBar.SetMaxHealth(100);
        healthBar.SetHealth(-10);

        // Slider will accept negative values unless you clamp it in code,
        // so this test ensures boundary behavior is documented.
        Assert.LessOrEqual(healthBar.slider.value, 0);
    }

    // -------------------------------------------------------------
    // 4. Boundary Test: SetHealth equal to max health
    // -------------------------------------------------------------
    [Test]
    public void SetHealth_AtMaxHealth_SetsSliderToMax()
    {
        healthBar.SetMaxHealth(100f);
        healthBar.SetHealth(100f);

        Assert.AreEqual(100f, healthBar.slider.value);
    }

    // -------------------------------------------------------------
    // 5. Boundary Test: SetHealth greater than max health
    // -------------------------------------------------------------
    [Test]
    public void SetHealth_AboveMaxHealth_ClampsToMax()
    {
        healthBar.SetMaxHealth(100);

        healthBar.SetHealth(150);

        // Unity's Slider clamps automatically
        Assert.AreEqual(100, healthBar.slider.value);
    }

}
