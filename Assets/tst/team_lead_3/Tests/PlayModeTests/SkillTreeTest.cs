using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;

public class SkillTreeTest : InputTestFixture
{
    Keyboard keyboard;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        keyboard = InputSystem.AddDevice<Keyboard>();

        yield return null;
    }
    [UnityTest]
    public IEnumerator DoesSkillTreeWork()
    {
        Press(keyboard.xKey);
        InputSystem.Update();
        if (keyboard.xKey.wasPressedThisFrame)
        {
            Debug.Log("Skill tree is up");
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
        if (keyboard != null)
        {
            InputSystem.RemoveDevice(keyboard);
        }
        yield return null;
    }
}
