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
    private SkillTreeClass skilltree;

    [SerializeField] private Button fighterButton;
    [SerializeField] private Button rangerButton;
    [SerializeField] private Button mageButton;

    private void Start()
    {
        // levelSystem = new LevelSystem();
        levelWindow.SetLevelSystem(levelSystem);
        
        skilltree = new SkillTreeClass();
        skilltree.SetLevelSystem(levelSystem);
        skilltree.Init();
        SkillTreeClass.health = FindObjectOfType<Health>();
    }

    private void Awake()
    {
        levelSystem = LevelSystem.Instance;

        DontDestroyOnLoad(gameObject);

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
        int check = (int)levelSystem.GetLevelNum();
        xpTimer += Time.deltaTime;
        if (xpTimer >= OneSec)
        {
            levelSystem.GetAddXp(1);
            xpTimer = 0f;
        }

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
        if (levelSystem.GetLevelNum() > check)
        {
            levelSystem.skillPoint++;
            Debug.Log("Added a skill point");
            Debug.Log($"You now have {levelSystem.skillPoint}");
        }
    }

    public void LoadScene()
    {
        // Debug.Log("Loading the main scene");
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
