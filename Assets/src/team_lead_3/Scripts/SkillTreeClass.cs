using UnityEngine;
using System.Collections.Generic;

public class SkillTreeClass
{
    public static Health health;
    public static PlayerController pc;
    private int overallLevel = 1;
    private LevelSystem levelSystem;
    private int levReq; // the level required to unlock that skill

    public void SetLevelSystem(LevelSystem levelSystem)
    {
        this.levelSystem = levelSystem;
        //levelSystem = LevelSystem.Instance;
    }

    public void Init() // I have a good reason for this to be public
    {
        
        overallLevel = (int)LevelSystem.Instance.GetLevelNum();
        Debug.Log($"The level is {overallLevel}");
        LevelSystem.Instance.skillPoint = 1;
        int current_sp = LevelSystem.Instance.GetSp();
        Debug.Log($"You have {current_sp} skill points");

        // *** This is where the dynamic binding gets called so uncomment this ****
        //DynamicAbility ability = new Ability101();
        // ability.Unlock();
    }

    protected bool AddSkill(int skillID, int levReq, int classLevel, bool flag)
    {
        Debug.Log("ADD SKILL IS BEING CALLED");
        // Debug.Log($"YOU HAVE {skillPoints} skill points");
        if (flag == true && LevelSystem.Instance.GetSp() >= 1)
        {
            //add the skill
            overallLevel = overallLevel + 1;
            LevelSystem.Instance.skillPoint = LevelSystem.Instance.GetSp() - 1;
            return true;
        }
        else
        {
            Debug.Log("Not enough skill points");
            return false;
            // probably will put a canvas message here to display an error message
        }
    }

    // getters 
    public int GetOverallLvl()
    {
        return overallLevel;
    }
}
