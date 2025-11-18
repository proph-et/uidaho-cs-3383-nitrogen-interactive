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

    void Ability201() // gives you max health
    {
        bool flag = true;
        int levReq = 1;
        if (AddSkill(201, levReq, rangerLevel, flag))
        {
            rangerLevel = rangerLevel + 1;
            ab201 = true;
            float amountToHeal = health.GetMaxHealth() - health.GetCurrentHealth();
            health.Heal(amountToHeal);
            Debug.Log("We healing up boys");
        }
        else
        {
            Debug.Log("Not enough skill points");
        }
    }
    void Ability202() // makes the player invincible?
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
            Debug.Log("Invincible");
            pc.IsInvincible();
        }
        else
        {
            Debug.Log("Not enough skill points");
        }
    }
    void Ability203() // gives you five health
    {
        bool flag = false;
        int levReq = 3;
        if (ab202 == true)
        {
            flag = true;
        }
        if (AddSkill(203, levReq, rangerLevel, flag))
        {
            rangerLevel = rangerLevel + 1;
            ab203 = true;
            Debug.Log("Adding some health");
            health.Heal((float)5.0);
        }
        else
        {
            Debug.Log("Not enough skill points");
        }
    }
    void Ability204() // adds 15 health
    {
        bool flag = false;
        int levReq = 4;
        if (ab203 == true)
        {
            flag = true;
        }
        if (AddSkill(204, levReq, rangerLevel, flag))
        {
            rangerLevel = rangerLevel + 1;
            ab204 = true;
            Debug.Log("Adding 15 health");
            health.Heal((float)15);
        }
        else
        {
            Debug.Log("Not enough skill points");
        }
    }
    void Ability205() // makes player take less damage
    {
        bool flag = false;
        int levReq = 5;
        if (ab204 == true)
        {
            flag = true;
        }
        if (AddSkill(205, levReq, rangerLevel, flag)) 
        {
            rangerLevel = rangerLevel + 1;
            ab205 = true;
            Debug.Log("Skill unlocked!");
            health.TakeDamage(0);
        }
        else
        {
            Debug.Log("Not enough skill points");
        }
    }
    void Ability206() // makes the player invincible again
    {
        bool flag = false;
        int levReq = 6;
        if (ab205 == true)
        {
            flag = true;
        }
        if (AddSkill(206, levReq, rangerLevel, flag))
        {
            rangerLevel = rangerLevel + 1;
            ab206 = true;
            Debug.Log("Skill unlocked!");
            pc.IsInvincible();
        }
        else
        {
            Debug.Log("Not enough skill points");
        }
    }
    void Ability207() // heals the player by 35
    {
        bool flag = false;
        int levReq = 7;
        if (ab206 == true)
        {
            flag = true;
        }
        if (AddSkill(207, levReq, rangerLevel, flag))
        {
            rangerLevel = rangerLevel + 1;
            ab207 = true;
            Debug.Log("Skill unlocked!");
            health.Heal(35);
        }
        else
        {
            Debug.Log("Not enough skill points");
        }
    }
    void Ability208() // adds 50xp
    {
        bool flag = false;
        int levReq = 8;
        if (ab207 == true)
        {
            flag = true;
        }
        if (AddSkill(208, levReq, rangerLevel, flag))
        {
            rangerLevel = rangerLevel + 1;
            ab208 = true;
            Debug.Log("Skill unlocked!");
            LevelSystem.Instance.GetAddXp(50);
        }
        else
        {
            Debug.Log("Not enough skill points");
        }
    }
    void Ability209() // fully restores health again
    {
        bool flag = false;
        int levReq = 9;
        if (ab208 == true)
        {
            flag = true;
        }
        if (AddSkill(209, levReq, rangerLevel, flag))
        {
            float amountToHeal = health.GetMaxHealth() - health.GetCurrentHealth();
            rangerLevel = rangerLevel + 1;
            ab209 = true;
            Debug.Log("Skill unlocked!");
            health.Heal(amountToHeal);
        }
        else
        {
            Debug.Log("Not enough skill points");
        }
    }

    // getters
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
