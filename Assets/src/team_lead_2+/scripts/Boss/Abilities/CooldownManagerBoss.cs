using System.Collections.Generic;
using UnityEngine;

public class CooldownManagerBoss : MonoBehaviour
{   
    private float CooldownMultiplier = 1f;

    private class CooldownData
    {
        private float endTime;
        public float EndTime => endTime;

        public void Start(float duration)
        {
            endTime = Time.time + duration;
        }
    }

    private Dictionary<string, CooldownData> cooldowns = new Dictionary<string, CooldownData>();

    public bool Ready(string abilityName)
    {
        if (!cooldowns.ContainsKey(abilityName))
        {
            return true;
        }

        return Time.time >= cooldowns[abilityName].EndTime;
    }

    public void StartCooldown(string abilityName, float duration)
    {
        float finalDuration = duration * CooldownMultiplier;

        if (!cooldowns.ContainsKey(abilityName))
        {
            cooldowns.Add(abilityName, new CooldownData());
        }

        cooldowns[abilityName].Start(duration);
    }

    public float TimeRemaining(string abilityName)
    {
        if (!cooldowns.ContainsKey(abilityName))
        {
            return 0f;
        }

        return Mathf.Max(0f, cooldowns[abilityName].EndTime - Time.time);
    }

    public void SetCooldownMultiplier(float multiplier)
    {
        CooldownMultiplier = multiplier;
    }
}
