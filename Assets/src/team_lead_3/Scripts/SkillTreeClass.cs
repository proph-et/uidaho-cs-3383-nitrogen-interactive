using UnityEngine;

public class SkillTreeClass : Ability
{
    public int overallLevel = 1; 
    private LevelSystem levelSystem;
    protected int skillPoints;
    int levReq; // the level required to unlock that skill

    public void SetLevelSystem(LevelSystem levelSystem)
    {
        this.levelSystem = levelSystem;
    }

    private void Start() // no idea if this works until we call the class later
    {

        overallLevel = (int)LevelSystem.Instance.GetLevelNum();
        Debug.Log($"The level is {overallLevel}");
        skillPoints = 1;
    }
    public bool AddSkill(int skillID, int levReq, int classLevel, bool flag) 
    {
        Debug.Log("ADD SKILL IS BEING CALLED");
        Debug.Log($"YOU HAVE {skillPoints} skill points");
        if (classLevel >= levReq && flag == true && skillPoints >= 1)
        {
            //add the skill
            overallLevel = overallLevel + 1;
            skillPoints = skillPoints - 1;
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
