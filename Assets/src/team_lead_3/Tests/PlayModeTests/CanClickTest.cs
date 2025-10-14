using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CanClickTest
{
    Mouse mouse;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        mouse = InputSystem.AddDevice<Mouse>();

        yield return null;
    }
    [UnityTest]
    public IEnumerator DoesSkillTreeWork()
    {
        Press(mouse.leftButton);
        yield return null; // best to wait a frame

        if (mouse.leftButton.wasPressedThisFrame)
        {
            Debug.Log("Buying a skill");
            Assert.Pass();
        }
        else
        {
            Assert.Fail();
        }
        yield return null;
    }

    [UnityTearDown]
    public IEnumerator TearDown()
    {
        if (mouse != null)
        {
            InputSystem.RemoveDevice(mouse);
        }
        yield return null;
    }
}
