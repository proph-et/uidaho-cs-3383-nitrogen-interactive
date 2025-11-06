using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SkillTree : MonoBehaviour
{
    private string MainScene = "SkillTreeScene"; // probably will need to change this
    public static bool is_open = false;
    public GameObject SkillTreeMenu;
    public LevelWindow levelWindow;
    private LevelSystem levelSystem;

    private void Start()
    {
        levelSystem = new LevelSystem();
        levelWindow.SetLevelSystem(levelSystem);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Pressing the key");
            if (is_open)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void LoadScene()
    {
        Debug.Log("Loading the main scene");
        SceneManager.LoadScene(MainScene);
    }

    void Resume()
    {
        SkillTreeMenu.SetActive(false);
        Time.timeScale = 1f;
        is_open = false;
    }
    void Pause()
    {
        SkillTreeMenu.SetActive(true);
        Time.timeScale = 0f;
        is_open = true;
    }

    public LevelSystem GetLvlSystem()
    {
        return levelSystem;
    }
}
