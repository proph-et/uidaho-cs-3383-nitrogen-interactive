using UnityEngine;

public class Fighter : SkillTreeClass
{
    // theres needs to be a game object up here for the button

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
        int levReq = 2; // the required level
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
        bool flag = false;
        int levReq = 3;
        if (ab102 == true)
        {
            flag = true;
        }
        // add ability
        // AddSkill(103, levReq, fighterLevel, flag);
        fighterLevel = fighterLevel + 1;
        ab103 = true;
    }
    void Ability104()
    {
        bool flag = false;
        int levReq = 4;
        if (ab103 == true)
        {
            flag = true;
        }
        // add ability
        fighterLevel = fighterLevel + 1;
        ab104 = true;
    }
    void Ability105()
    {
        bool flag = false;
        int levReq = 5;
        if (ab104 == true)
        {
            flag = true;
        }
        // add ability
        fighterLevel = fighterLevel + 1;
        ab105 = true;
    }
    void Ability106()
    {
        bool flag = false;
        int levReq = 6;
        if (ab105 == true)
        {
            flag = true;
        }
        // add ability
        fighterLevel = fighterLevel + 1;
        ab106 = true;
    }
    void Ability107()
    {
        bool flag = false;
        int levReq = 7;
        if (ab106 == true)
        {
            flag = true;
        }
        // add ability
        fighterLevel = fighterLevel + 1;
        ab107 = true;
    }
    void Ability108()
    {
        bool flag = false;
        int levReq = 8;
        if (ab107 == true)
        {
            flag = true;
        }
        // add ability
        fighterLevel = fighterLevel + 1;
        ab108 = true;
    }
    void Ability109()
    {
        bool flag = false;
        int levReq = 9;
        if (ab108 == true)
        {
            flag = true;
        }
        // add ability
        fighterLevel = fighterLevel + 1;
        ab109 = true;
    }
    void Ability110()
    {
        bool flag = false;
        int levReq = 10;
        if (ab109 == true)
        {
            flag = true;
        }
        // add ability
        fighterLevel = fighterLevel + 1;
        ab110 = true;
    }
    void Ability111()
    {
        bool flag = false;
        int levReq = 11;
        if (ab110 == true)
        {
            flag = true;
        }
        // add ability
        fighterLevel = fighterLevel + 1;
        ab111 = true;
    }
    void Ability112()
    {
        bool flag = false;
        int levReq = 12;
        if (ab111 == true)
        {
            flag = true;
        }
        // add ability
        fighterLevel = fighterLevel + 1;
        ab112 = true;
    }

    public void GetAb(int ability)
    {
        switch (ability)
        {
            case 101:
                Ability101();
                break;
            case 102:
                Ability102();
                break;
            case 103:
                Ability103();
                break;
            case 104:
                Ability104();
                break;
            case 105:
                Ability105();
                break;
            case 106:
                Ability106();
                break;
            case 107:
                Ability107();
                break;
            case 108:
                Ability108();
                break;
            case 109:
                Ability109();
                break;
            case 110:
                Ability110();
                break;
            case 111:
                Ability111();
                break;
            case 112:
                Ability112();
                break;
        }
    }
}
