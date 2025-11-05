using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class LevelCheck
{
    SkillTreeClass level;
    Fighter fighter;
    Ranger ranger;
    Mage mage;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        level = new SkillTreeClass();
        fighter = new Fighter();
        ranger = new Ranger();
        mage = new Mage();

        yield return null;
    }
    // overall level should be the three class levels combined
    [UnityTest]
    public IEnumerator DoesOverallLevelWork()
    {
        int shouldbe = fighter.fighterLevel + ranger.rangerLevel + mage.mageLevel;
        if (level.overallLevel == shouldbe)
        {
            Assert.Pass();
        }
        else
        {
            Assert.Fail();
        }
        yield return null;
    }

    [UnityTest]
    public IEnumerator AreAllClassesEqual()
    {
        bool equal = false;
        if (fighter.fighterLevel == ranger.rangerLevel && ranger.rangerLevel == mage.mageLevel)
        {
            equal = true;
        }
        if (equal == true)
        {
            Assert.Pass();
        }
        Assert.Fail();
        yield return null;
    }
}
