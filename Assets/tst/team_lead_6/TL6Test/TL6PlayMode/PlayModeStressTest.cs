using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using System.Collections;

// --- Facade for stress testing multiple buttons ---
public class StressMenuFacade
{
    public GameObject menuObj { get; private set; }
    public Button[] buttons;
    public int[] clickCounts;

    public StressMenuFacade(int buttonCount = 10)
    {
        menuObj = new GameObject("StressMenu");

        buttons = new Button[buttonCount];
        clickCounts = new int[buttonCount];

        for (int i = 0; i < buttonCount; i++)
        {
            var btnObj = new GameObject("Button_" + i);
            var button = btnObj.AddComponent<Button>();
            int index = i; // capture index for closure
            clickCounts[i] = 0;

            // Mock listener increments the click count
            button.onClick.AddListener(() => clickCounts[index]++);
            buttons[i] = button;
        }
    }

    public void ClickButton(int index, int times = 1)
    {
        for (int i = 0; i < times; i++)
        {
            buttons[index].onClick.Invoke();
        }
    }

    public void Destroy()
    {
        Object.Destroy(menuObj);
        foreach (var b in buttons)
        {
            Object.Destroy(b.gameObject);
        }
    }
}

// --- Play Mode Stress Test ---
public class SafeStressMenuTest
{
    private StressMenuFacade menuFacade;

    [UnityTest]
    public IEnumerator MultipleButtons_MultipleClicks_StressTest()
    {
        // Create facade with 20 buttons
        menuFacade = new StressMenuFacade(20);

        int clicksPerButton = 1000;

        // Simulate clicks over multiple frames
        for (int i = 0; i < clicksPerButton; i++)
        {
            for (int j = 0; j < menuFacade.buttons.Length; j++)
            {
                menuFacade.ClickButton(j, 1); // 1 click per frame per button
            }

            yield return null; // wait one frame
        }

        // Verify all clicks were counted correctly
        for (int j = 0; j < menuFacade.buttons.Length; j++)
        {
            Assert.AreEqual(clicksPerButton, menuFacade.clickCounts[j],
                $"Button {j} should have been clicked {clicksPerButton} times.");
        }

        Debug.Log($"Stress test complete: {menuFacade.buttons.Length} buttons clicked {clicksPerButton} times each.");

        menuFacade.Destroy();
    }
}
