using UnityEngine;

public class Fighter : SkillTreeClass
{
    // there should be 12 fighter nodes
    public int fighterLevel = 0;

// these will be used by the add function to see if the required skills have been unlocked before adding the skill
    bool ab101 = false; 
    bool ab102 = false;
    bool ab103 = false;
    bool ab104 = false;
    bool ab105 = false;
    bool ab106 = false;
    bool ab107 = false;
    bool ab108 = false;
    bool ab109 = false;
    bool ab110 = false;
    bool ab111 = false;
    bool ab112 = false;

    void Ability101()
    {
        /* playerHealth = playerHealth * 0.1 + playerHealth;
        * fighterLevel = fighterLevel + 1;
        * AddSkill(101, 1, fighterLevel, true)
        * ab101 = true;
        */
    }
    void Ability102()
    {
        /*
        bool flag = false;
        int req = 2; // the required level
        if (ab101 == true)
        {
            flag = true;
        }
        punchDamage = punchDamage + 0.1 + punchDamage;
        fighterLevel = fighterLevel + 1;
        AddSkill(102, req, fighterLevel, flag);
        ab102 = true;
        */
    }
    void Ability103()
    {
        // empty function for now
    }
    void Ability104()
    {
        // empty function for now
    }
    void Ability105()
    {
        // empty function for now
    }
    void Ability106()
    {
        // empty function for now
    }
    void Ability107()
    {
        // empty function for now
    }
    void Ability108()
    {
        // empty function for now
    }
    void Ability109()
    {
        // empty function for now
    }
    void Ability110()
    {
        // empty function for now
    }
    void Ability111()
    {
        // empty function for now
    }
    void Ability112()
    {
        // empty function for now
    }
}
