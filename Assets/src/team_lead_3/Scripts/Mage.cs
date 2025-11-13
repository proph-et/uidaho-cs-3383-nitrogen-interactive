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
        bool flag = true;
        int levReq = 1;
        if (AddSkill(301, levReq, mageLevel, flag))
        {
            mageLevel = mageLevel + 1;
            ab301 = true;
        }
        Debug.Log("This is 301");
    }
    void Ability302()
    {
        bool flag = false;
        int levReq = 2;
        if (ab301 == true)
        {
            flag = true;
        }
        if (AddSkill(302, levReq, mageLevel, flag))
        {
            mageLevel = mageLevel + 1;
            ab302 = true;
            // add ability here
        }
        else
        {
            Debug.Log("302");
        }
    }
    void Ability303()
    {
        bool flag = false;
        int levReq = 3;
        if (ab302 == true)
        {
            flag = true;
        }
        if (AddSkill(303, levReq, mageLevel, flag))
        {
            mageLevel = mageLevel + 1;
            ab303 = true;
            // add ability here
        }
        else
        {
            Debug.Log("303");
        }
    }
    void Ability304()
    {
        bool flag = false;
        int levReq = 4;
        if (ab303 == true)
        {
            flag = true;
        }
        if (AddSkill(304, levReq, mageLevel, flag))
        {
            mageLevel = mageLevel + 1;
            ab304 = true;
            // add ability here
        }
        else
        {
            Debug.Log("304");
        }
    }
    void Ability305()
    {
        bool flag = false;
        int levReq = 5;
        if (ab304 == true)
        {
            flag = true;
        }
        if (AddSkill(305, levReq, mageLevel, flag))
        {
            mageLevel = mageLevel + 1;
            ab305 = true;
            // add ability here
        }
        else
        {
            Debug.Log("305");
        }
    }
    void Ability306()
    {
        bool flag = false;
        int levReq = 6;
        if (ab305 == true)
        {
            flag = true;
        }
        if (AddSkill(306, levReq, mageLevel, flag))
        {
            mageLevel = mageLevel + 1;
            ab306 = true;
            // add ability here
        }
        else
        {
            Debug.Log("306");
        }
    }
    void Ability307()
    {
        bool flag = false;
        int levReq = 7;
        if (ab306 == true)
        {
            flag = true;
        }
        if (AddSkill(307, levReq, mageLevel, flag))
        {
            mageLevel = mageLevel + 1;
            ab307 = true;
            // add ability here
        }
        else
        {
            Debug.Log("307");
        }
    }
    void Ability308()
    {
        bool flag = false;
        int levReq = 8;
        if (ab307 == true)
        {
            flag = true;
        }
        if (AddSkill(308, levReq, mageLevel, flag))
        {
            mageLevel = mageLevel + 1;
            ab308 = true;
            // add ability here
        }
        else
        {
            Debug.Log("308");
        }
    }

    public void GetAb(int ability)
    {
        switch (ability)
        {
            case 301:
                Ability301();
                break;
            case 302:
                Ability302();
                break;
            case 303:
                Ability303();
                break;
            case 304:
                Ability304();
                break;
            case 305:
                Ability305();
                break;
            case 306:
                Ability306();
                break;
            case 307:
                Ability307();
                break;
            case 308:
                Ability308();
                break;
        }
    }
}
