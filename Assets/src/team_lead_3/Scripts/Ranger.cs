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
        // add ability
        rangerLevel = rangerLevel + 1;
        ab202 = true;
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
}
