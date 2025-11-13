using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkillTree : MonoBehaviour
{
    private string MainScene = "SkillTreeScene"; // probably will need to change this
    public static bool is_open = false;
    public GameObject SkillTreeMenu;
    public LevelWindow levelWindow;
    private LevelSystem levelSystem;
    private float xpTimer = 0f;
    private float OneSec = 1f;

    [SerializeField] private Button fighterButton;
    [SerializeField] private Button rangerButton;
    [SerializeField] private Button mageButton;

    private void Start()
    {
        levelSystem = new LevelSystem();
        levelWindow.SetLevelSystem(levelSystem);
    }

    private void Awake()
    {
        fighterButton.onClick.AddListener(() =>
        {
            Debug.Log("Fighter button was pushed");
        });
        if (rangerButton != null)
        {
            rangerButton.onClick.AddListener(() =>
            {
                Debug.Log("Ranger button was pushed");
            });
        }
        if (mageButton != null)
        {
            mageButton.onClick.AddListener(() =>
            {
                Debug.Log("Mage button was pushed");
            });
        }

    }
    void Update()
    {
        xpTimer += Time.deltaTime;
        if (xpTimer >= OneSec)
        {
            levelSystem.AddXp(1);
            xpTimer = 0f;
        }
        // Debug.Log("Adding 1xp rn");

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
