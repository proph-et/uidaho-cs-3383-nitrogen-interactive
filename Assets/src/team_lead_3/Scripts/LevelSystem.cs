using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelSystem
{
    public int skillPoint;
    // singleton pattern
    private static LevelSystem _instance;
    public static LevelSystem Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new LevelSystem();
            }
            return _instance;
        }
    }

    // observer pattern
    // Level system is the observable, things that subscribe to the event are the observers
    public event EventHandler OnXpChanged; // means that the xp changed
    public event EventHandler OnlvlChanged; // means that the level changed

    int level;
    int xp;
    int xpToNext;

    public LevelSystem()
    {
        level = 1;
        xp = 0;
        xpToNext = 10;

        OnlvlChanged?.Invoke(this, EventArgs.Empty);
        OnXpChanged?.Invoke(this, EventArgs.Empty);
    }

    private void AddXp(int amount)
    {
        xp = xp + amount;
        while (xp >= xpToNext) // if you have enough xp
        {
            xp = xp - xpToNext;
            level++;
            xpToNext = GetXpToNext(level);
            if (OnXpChanged != null)
            {
                OnlvlChanged(this, EventArgs.Empty);
                AddSp(1);
            }
        }
        if (OnXpChanged != null)
        {
            OnXpChanged(this, EventArgs.Empty);
        }
    }

    private void XpBoost(int duration)
    {
        for (int i = 0; i < duration; i++)
        {
            AddXp(1);
        }
    }

    private void AddSp(int amount)
    {
        skillPoint = skillPoint + amount;
    }

    // ***** Getters ********
    public float GetLevelNum()
    {
        return level;
    }

    public float GetXpNum()
    {
        return (float)xp;
    }

    public int GetXpToNext(int level)
    {
        return level * 10;
    }
    public void GetXpBoost(int duration)
    {
        XpBoost(duration);
    }
    public void GetAddSp(int amount)
    {
        AddSp(amount);
    }
    public void GetAddXp(int amount)
    {
        AddXp(amount);
    }
    public int GetSp()
    {
        return skillPoint;
    }
}
