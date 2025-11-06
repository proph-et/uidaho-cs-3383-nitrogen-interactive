using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class LevelSystemTest
{
    private LevelSystem levelSystem;

    [SetUp]
    private void SetUp()
    {
        levelSystem = new LevelSystem();
    }

    [UnityTest]
    public IEnumerator DoesXPWork()
    {
        Debug.Log(levelSystem.GetLevelNum());
        levelSystem.AddXp(50);
        Debug.Log(levelSystem.GetLevelNum());
        levelSystem.AddXp(60);

        Assert.AreEqual(2, levelSystem.GetLevelNum());
        yield return null;
    }
}
