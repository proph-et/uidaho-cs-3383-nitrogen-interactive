using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class LevelWindow : MonoBehaviour
{
    private TMPro.TMP_Text levelDisplay;
    private TMPro.TMP_Text xpDisplay;
    private LevelSystem levelSystem;

    private void Start()
    {
        if (levelSystem == null)
        {
            levelSystem = new LevelSystem();
        }
        else
        {
            Debug.Log("levelSystem was already created. message from the level window script");
        }
    } 

    private void Awake()
    {
        levelDisplay = transform.Find("levelText").GetComponent<TMP_Text>();
        xpDisplay = transform.Find("xpText").GetComponent<TMP_Text>();
    }

    private void SetXpNum()
    {
        xpDisplay.text = "XP: " + levelSystem.GetXpNum().ToString() + "/" + levelSystem.GetXpToNext((int)levelSystem.GetLevelNum()).ToString();
        // Debug.Log("Setting the Xp");
    }

    private void SetLvlNum()
    {
        levelDisplay.text = "LEVEL " + levelSystem.GetLevelNum();
        // Debug.Log("Setting the lvl");
    }

    public void SetLevelSystem(LevelSystem levelSystem)
    {
        // sets the game object
        this.levelSystem = levelSystem;

        SetLvlNum();
        SetXpNum();

        // sets the starting values
        levelSystem.OnXpChanged += LevelSystem_OnXpChanged;
        levelSystem.OnlvlChanged += LevelSystem_OnlvlChanged;

        transform.Find("AddXpButton").GetComponent<Button>().onClick.AddListener(() => levelSystem.AddXp(100));
    }
    private void LevelSystem_OnlvlChanged(object sender, EventArgs e)
    {
        // the level has changed, so update the text
        SetLvlNum();
        float stuff = levelSystem.GetLevelNum();
        // Debug.Log($"Setting the lvl {stuff}");
    }

    private void LevelSystem_OnXpChanged(object sender, EventArgs e)
    {
        // the xp has gone up, so update the text
        SetXpNum();
        float stuff = levelSystem.GetXpNum();
        // Debug.Log($"Setting the xp {stuff}");
    }
}
