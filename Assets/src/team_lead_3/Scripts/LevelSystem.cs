using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelSystem
{
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


    public event EventHandler OnXpChanged;
    public event EventHandler OnlvlChanged;

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

    public void AddXp(int amount) // might want to make this private, but other classes call it
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
            }
        }
        if (OnXpChanged != null)
        {
            OnXpChanged(this, EventArgs.Empty);
        }
    }

    public float GetLevelNum() // a getter so it must be public 
    {
        return level;
    }

    public float GetXpNum() // also a getter
    {
        return (float)xp;
    }

    public int GetXpToNext(int level)
    {
        return level * 10;
    }
}
