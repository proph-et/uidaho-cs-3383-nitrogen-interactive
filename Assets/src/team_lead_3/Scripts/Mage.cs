using UnityEngine;

public class Mage : SkillTreeClass
{
    public int mageLevel = 0;
    bool ab301 = false;
    bool ab302 = false;
    bool ab303 = false;
    bool ab304 = false;
    bool ab305 = false;
    bool ab306 = false;
    bool ab307 = false;
    bool ab308 = false;

    void Ability301()
    {
        // add ability
        mageLevel = mageLevel + 1;
        ab301 = true;
    }
    void Ability302()
    {
        bool flag = false;
        int levReq = 2;
        if (ab301 == true)
        {
            flag = true;
        }
        // add ability
        mageLevel = mageLevel + 1;
        ab302 = true;
    }
    void Ability303()
    {
        bool flag = false;
        int levReq = 3;
        if (ab302 == true)
        {
            flag = true;
        }
        // add ability
        mageLevel = mageLevel + 1;
        ab303 = true;
    }
    void Ability304()
    {
        bool flag = false;
        int levReq = 4;
        if (ab303 == true)
        {
            flag = true;
        }
        // add ability
        mageLevel = mageLevel + 1;
        ab304 = true;
    }
    void Ability305()
    {
        bool flag = false;
        int levReq = 5;
        if (ab304 == true)
        {
            flag = true;
        }
        // add ability
        mageLevel = mageLevel + 1;
        ab305 = true;
    }
    void Ability306()
    {
        bool flag = false;
        int levReq = 6;
        if (ab305 == true)
        {
            flag = true;
        }
        // add ability
        mageLevel = mageLevel + 1;
        ab306 = true;
    }
    void Ability307()
    {
        bool flag = false;
        int levReq = 7;
        if (ab306 == true)
        {
            flag = true;
        }
        // add ability
        mageLevel = mageLevel + 1;
        ab307 = true;
    }
    void Ability308()
    {
        bool flag = false;
        int levReq = 8;
        if (ab307 == true)
        {
            flag = true;
        }
        // add ability
        mageLevel = mageLevel + 1;
        ab308 = true;
    }
}
