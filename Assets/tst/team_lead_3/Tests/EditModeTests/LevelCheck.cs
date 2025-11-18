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
        if (level.GetOverallLvl() == shouldbe)
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
    [UnityTest]
    public IEnumerator IsLevelSystemSet()
    {
        float level_num = LevelSystem.Instance.GetLevelNum();
        if (level_num == 1)
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
    public IEnumerator AreSkillPointsSet()
    {
        int sp = LevelSystem.Instance.GetSp();
        if (sp == 1)
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
    public IEnumerator IsXpSetCorrectly()
    {
        float xp = LevelSystem.Instance.GetXpNum();
        if (xp == 0)
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
    public IEnumerator IsXpNext()
    {
        int xpnext = LevelSystem.Instance.GetXpToNext(1);
        int shouldbe = 10;
        if (xpnext == shouldbe)
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
    public IEnumerator CheckThatXpToNextDoubles() // make sure it takes 20xp to reach next level
    {
        int xpnext = LevelSystem.Instance.GetXpToNext(2);
        int shouldbe = 20;
        if (xpnext == shouldbe)
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
    public IEnumerator CheckThatXpToNextDoubles2() // make sure it takes 20xp to reach next level
    {
        int xpnext = LevelSystem.Instance.GetXpToNext(3);
        int shouldbe = 30;
        if (xpnext == shouldbe)
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
    public IEnumerator RangerLvlCheck()
    {
        if (ranger.rangerLevel == 0)
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
    public IEnumerator MageLvlCheck()
    {
        if (mage.mageLevel == 0)
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
    public IEnumerator FighterLvlCheck()
    {
        if (fighter.fighterLevel == 0)
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
