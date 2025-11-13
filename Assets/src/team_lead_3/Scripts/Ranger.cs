using UnityEngine;

public class Ranger : SkillTreeClass
{
    // need to put a gameobject up here for the button

    public int rangerLevel = 0;

    bool ab201 = false;
    bool ab202 = false;
    bool ab203 = false;
    bool ab204 = false;
    bool ab205 = false;
    bool ab206 = false;
    bool ab207 = false;
    bool ab208 = false;
    bool ab209 = false;

    void Ability201()
    {
        bool flag = true;
        int levReq = 1;
        if (AddSkill(201, levReq, rangerLevel, flag))
        {
            rangerLevel = rangerLevel + 1;
            ab201 = true;
            Debug.Log("201 Unlocked");
            // add ability
        }
        else
        {
            Debug.Log("Not enough skill points");
        }
    }
    void Ability202()
    {
        bool flag = false;
        int levReq = 2;
        if (ab201 == true)
        {
            flag = true;
        }
        if (AddSkill(202, levReq, rangerLevel, flag))
        {
            rangerLevel = rangerLevel + 1;
            ab202 = true;
            Debug.Log("Skill unlocked!");
            // will add the level here too
        }
        else
        {
            Debug.Log("Not enough skill points");
        }
    }
    void Ability203()
    {
        bool flag = false;
        int levReq = 3;
        if (ab202 == true)
        {
            flag = true;
        }
        if (AddSkill(203, levReq, rangerLevel, flag))
        {
            // add ability
            rangerLevel = rangerLevel + 1;
            ab203 = true;
            Debug.Log("Skill unlocked!");
        }
        else
        {
            Debug.Log("Not enough skill points");
        }
    }
    void Ability204()
    {
        bool flag = false;
        int levReq = 4;
        if (ab203 == true)
        {
            flag = true;
        }
        if (AddSkill(204, levReq, rangerLevel, flag))
        {
            // add ability
            rangerLevel = rangerLevel + 1;
            ab204 = true;
            Debug.Log("Skill unlocked!");
        }
        else
        {
            Debug.Log("Not enough skill points");
        }
    }
    void Ability205()
    {
        bool flag = false;
        int levReq = 5;
        if (ab204 == true)
        {
            flag = true;
        }
        if (AddSkill(205, levReq, rangerLevel, flag))
        {
            // add ability
            rangerLevel = rangerLevel + 1;
            ab205 = true;
            Debug.Log("Skill unlocked!");
        }
        else
        {
            Debug.Log("Not enough skill points");
        }
    }
    void Ability206()
    {
        bool flag = false;
        int levReq = 6;
        if (ab205 == true)
        {
            flag = true;
        }
        if (AddSkill(206, levReq, rangerLevel, flag))
        {
            // add ability
            rangerLevel = rangerLevel + 1;
            ab206 = true;
            Debug.Log("Skill unlocked!");
        }
        else
        {
            Debug.Log("Not enough skill points");
        }
    }
    void Ability207()
    {
        bool flag = false;
        int levReq = 7;
        if (ab206 == true)
        {
            flag = true;
        }
        if (AddSkill(207, levReq, rangerLevel, flag))
        {
            // add ability
            rangerLevel = rangerLevel + 1;
            ab207 = true;
            Debug.Log("Skill unlocked!");
        }
        else
        {
            Debug.Log("Not enough skill points");
        }
    }
    void Ability208()
    {
        bool flag = false;
        int levReq = 8;
        if (ab207 == true)
        {
            flag = true;
        }
        if (AddSkill(208, levReq, rangerLevel, flag))
        {
            // add ability
            rangerLevel = rangerLevel + 1;
            ab208 = true;
            Debug.Log("Skill unlocked!");
        }
        else
        {
            Debug.Log("Not enough skill points");
        }
    }
    void Ability209()
    {
        bool flag = false;
        int levReq = 9;
        if (ab208 == true)
        {
            flag = true;
        }
        if (AddSkill(209, levReq, rangerLevel, flag))
        {
            // add ability
            rangerLevel = rangerLevel + 1;
            ab209 = true;
            Debug.Log("Skill unlocked!");
        }
        else
        {
            Debug.Log("Not enough skill points");
        }
    }

    public void GetAb(int ability)
    {
        switch (ability)
        {
            case 201:
                Ability201();
                break;
            case 202:
                Ability202();
                break;
            case 203:
                Ability203();
                break;
            case 204:
                Ability204();
                break;
            case 205:
                Ability205();
                break;
            case 206:
                Ability206();
                break;
            case 207:
                Ability207();
                break;
            case 208:
                Ability208();
                break;
            case 209:
                Ability209();
                break;
        }
    }
}
