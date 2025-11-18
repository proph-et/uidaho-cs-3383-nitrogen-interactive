using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class RuntimeLvlTests
{
    [UnityTest]
    public IEnumerator LevelUpCheck()
    {
        int initLvl = 1;
        yield return new WaitForSeconds(10);
        Assert.Greater(LevelSystem.Instance.GetLevelNum(), initLvl);
        yield return null;
    }
    [UnityTest]
    public IEnumerator LevelWindowCheck()
    {
        int shouldbe = 1;
        if (LevelSystem.Instance.GetLevelNum() == shouldbe)
        {
            Assert.Pass();
        }
        else
        {
            Assert.Fail();
        }
        yield return null;
    }
}
