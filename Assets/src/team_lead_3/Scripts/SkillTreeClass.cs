using UnityEngine;

public class SkillTreeClass : Ability
{

    // protected static Health health;
    public int overallLevel = 1; 
    private LevelSystem levelSystem;
    int levReq; // the level required to unlock that skill

    public void SetLevelSystem(LevelSystem levelSystem)
    {
        //this.levelSystem = levelSystem;
        levelSystem = LevelSystem.Instance;
    }

    public void Init() // no idea if this works until we call the class later
    {

        overallLevel = (int)LevelSystem.Instance.GetLevelNum();
        Debug.Log($"The level is {overallLevel}");
        LevelSystem.Instance.skillPoint = 1;
        Debug.Log($"You have {LevelSystem.Instance.skillPoint} skill points");
        // health = new Health();
        // skillPoints = (int)levelSystem.GetLevelNum(); // just added this, this seems like a logic error
    }
    public bool AddSkill(int skillID, int levReq, int classLevel, bool flag) 
    {
        Debug.Log("ADD SKILL IS BEING CALLED");
        // Debug.Log($"YOU HAVE {skillPoints} skill points");
        if (flag == true && LevelSystem.Instance.skillPoint >= 1)
        {
            //add the skill
            overallLevel = overallLevel + 1;
            LevelSystem.Instance.skillPoint = LevelSystem.Instance.skillPoint - 1;
            return true;
        }
        else
        {
            Debug.Log("Not enough skill points");
            return false;
            // probably will put a canvas message here to display an error message
        }
    }
}
