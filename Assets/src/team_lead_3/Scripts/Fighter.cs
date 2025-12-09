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

    void Ability101() // adds 35xp
    {
        bool flag = true;
        int levReq = 1;
        if (AddSkill(101, levReq, fighterLevel, flag))
        {
            fighterLevel = fighterLevel + 1;
            ab101 = true;
            pc.SetSpeed(pc.speed * 1.1f);
        }
        Debug.Log("This is 101");
    }
    void Ability102() // adds 9 health
    {
        bool flag = false;
        int levReq = 2;
        if (ab101 == true)
        {
            flag = true;
        }
        if (AddSkill(102, levReq, fighterLevel, flag))
        {
            fighterLevel = fighterLevel + 1;
            ab102 = true;
            pc.SetSpeed(pc.speed * 1.1f);
        }
        else
        {
            Debug.Log("Unable to lock skill rn");
        }
    }
    void Ability103() // adds 12xp
    {
        bool flag = false;
        int levReq = 3;
        if (ab102 == true)
        {
            flag = true;
        }
        if (AddSkill(103, levReq, fighterLevel, flag))
        {
            fighterLevel = fighterLevel + 1;
            ab103 = true;
            pc.SetSpeed(pc.speed * 1.1f);
        }
        else
        {
            Debug.Log("Unable to lock skill rn");
        }
    }
    void Ability104() // adds a free skill point
    {
        bool flag = false;
        int levReq = 4;
        if (ab103 == true)
        {
            flag = true;
        }
        if (AddSkill(104, levReq, fighterLevel, flag))
        {
            fighterLevel = fighterLevel + 1;
            ab104 = true;
            pc.SetSpeed(pc.speed * 1.1f);
        }
        else
        {
            Debug.Log("Unable to lock skill rn");
        }
    }
    void Ability105() // adds 34 health
    {
        bool flag = false;
        int levReq = 5;
        if (ab104 == true)
        {
            flag = true;
        }
        if (AddSkill(105, levReq, fighterLevel, flag))
        {
            fighterLevel = fighterLevel + 1;
            ab105 = true;
            pc.SetSpeed(pc.speed * 1.1f);
        }
        else
        {
            Debug.Log("Unable to lock skill rn");
        }
    }
    void Ability106() // temp xp boost
    {
        bool flag = false;
        int levReq = 6;
        if (ab105 == true)
        {
            flag = true;
        }
        if (AddSkill(106, levReq, fighterLevel, flag))
        {
            fighterLevel = fighterLevel + 1;
            ab106 = true;
            pc.SetSpeed(pc.speed * 1.1f);
        }
        else
        {
            Debug.Log("Unable to lock skill rn");
        }
    }
    void Ability107() // free skill point
    {
        bool flag = false;
        int levReq = 7;
        if (ab106 == true)
        {
            flag = true;
        }
        if (AddSkill(107, levReq, fighterLevel, flag))
        {
            fighterLevel = fighterLevel + 1;
            ab107 = true;
            pc.SetSpeed(pc.speed * 1.1f);
        }
        else
        {
            Debug.Log("Unable to lock skill rn");
        }
    }
    void Ability108() // adds 18 health
    {
        bool flag = false;
        int levReq = 8;
        if (ab107 == true)
        {
            flag = true;
        }
        if (AddSkill(108, levReq, fighterLevel, flag))
        {
            fighterLevel = fighterLevel + 1;
            ab108 = true;
            pc.SetSpeed(pc.speed * 1.1f);
        }
        else
        {
            Debug.Log("Unable to lock skill rn");
        }
    }
    void Ability109() // adds 70 xp
    {
        bool flag = false;
        int levReq = 9;
        if (ab108 == true)
        {
            flag = true;
        }
        if (AddSkill(109, levReq, fighterLevel, flag))
        {
            fighterLevel = fighterLevel + 1;
            ab109 = true;
            pc.SetSpeed(pc.speed * 1.1f);
        }
        else
        {
            Debug.Log("Unable to lock skill rn");
        }
    }
    void Ability110() // xp boost
    {
        bool flag = false;
        int levReq = 10;
        if (ab109 == true)
        {
            flag = true;
        }
        if (AddSkill(110, levReq, fighterLevel, flag))
        {
            fighterLevel = fighterLevel + 1;
            ab110 = true;
            pc.SetSpeed(pc.speed * 1.1f);
        }
        else
        {
            Debug.Log("Unable to lock skill rn");
        }
    }
    void Ability111() // fully restores health
    {
        bool flag = false;
        int levReq = 11;
        if (ab110 == true)
        {
            flag = true;
        }
        if (AddSkill(111, levReq, fighterLevel, flag))
        {
            fighterLevel = fighterLevel + 1;
            ab111 = true;

            float amountToRestore = health.GetMaxHealth() - health.GetCurrentHealth();
            pc.SetSpeed(pc.speed * 1.1f);
        }
        else
        {
            Debug.Log("Unable to lock skill rn");
        }
    }
    void Ability112() // adds 2 skill points and 100xp
    {
        bool flag = false;
        int levReq = 12;
        if (ab112 == true)
        {
            flag = true;
        }
        if (AddSkill(112, levReq, fighterLevel, flag))
        {
            fighterLevel = fighterLevel + 1;
            ab112 = true;
            pc.SetSpeed(pc.speed * 1.1f);
        }
        else
        {
            Debug.Log("Unable to lock skill rn");
        }
    }

    // getters
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


