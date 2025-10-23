using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;

public class CanClickTest : InputTestFixture
{
    Mouse mouse;
    

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        mouse = InputSystem.AddDevice<Mouse>();

        yield return null;
    }

    [UnityTest]
    public IEnumerator CanClickTest()
    {
        // Assert.Pass();
        Press(mouse.leftButton);
        yield return null; // best to wait a frame

        if (mouse.leftButton.wasPressedThisFrame)
        {
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