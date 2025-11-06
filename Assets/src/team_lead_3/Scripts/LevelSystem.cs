using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelSystem
{
    public event EventHandler OnXpChanged;
    public event EventHandler OnlvlChanged;

    int level;
    public int xp;
    int xpToNext;

    public LevelSystem()
    {
        level = 0;
        xp = 0;
        xpToNext = 100;

        OnlvlChanged?.Invoke(this, EventArgs.Empty);
        OnXpChanged?.Invoke(this, EventArgs.Empty);
    }

    public void AddXp(int amount)
    {
        xp = xp + amount;
        if (xp >= xpToNext) // if you have enough xp
        {
            level++;
            xp = xp - xpToNext;
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

    public float GetLevelNum()
    {
        return level;
    }

    public float GetXpNum()
    {
        return (float)xp; //  / (float)xpToNext;
    }

}
