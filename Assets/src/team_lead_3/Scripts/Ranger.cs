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
        // add ability
        rangerLevel = rangerLevel + 1;
        ab201 = true;
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
        // add ability
        rangerLevel = rangerLevel + 1;
        ab203 = true;
    }
    void Ability204()
    {
        bool flag = false;
        int levReq = 4;
        if (ab203 == true)
        {
            flag = true;
        }
        // add ability
        rangerLevel = rangerLevel + 1;
        ab204 = true;
    }
    void Ability205()
    {
        bool flag = false;
        int levReq = 5;
        if (ab204 == true)
        {
            flag = true;
        }
        // add ability
        rangerLevel = rangerLevel + 1;
        ab205 = true;
    }
    void Ability206()
    {
        bool flag = false;
        int levReq = 6;
        if (ab205 == true)
        {
            flag = true;
        }
        // add ability
        rangerLevel = rangerLevel + 1;
        ab206 = true;
    }
    void Ability207()
    {
        bool flag = false;
        int levReq = 7;
        if (ab206 == true)
        {
            flag = true;
        }
        // add ability
        rangerLevel = rangerLevel + 1;
        ab207 = true;
    }
    void Ability208()
    {
        bool flag = false;
        int levReq = 8;
        if (ab207 == true)
        {
            flag = true;
        }
        // add ability
        rangerLevel = rangerLevel + 1;
        ab208 = true;
    }
    void Ability209()
    {
        bool flag = false;
        int levReq = 9;
        if (ab208 == true)
        {
            flag = true;
        }
        // add ability
        rangerLevel = rangerLevel + 1;
        ab209 = true;
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
