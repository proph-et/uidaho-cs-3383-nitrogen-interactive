using UnityEngine;

public class SkillTreeClass
{
    public int overallLevel = 0;
    int levReq; // the level required to unlock that skill
    void AddSkill(int skillID, int levReq, int classLevel, bool flag) 
    {
        if (classLevel >= levReq && flag == true)
        {
            //add the skill
            overallLevel = overallLevel + 1;
        }
        else
        {
            Debug.Log("Not enough skill points");
            // probably will put a canvas message here to display an error message
        }
    }
}
