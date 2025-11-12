using UnityEngine;
using UnityEngine.SceneManagement;

public class SkillTreeManager : MonoBehaviour
{
    [SerializeField] private string Scene = "SkillTreeScene";
    private bool sceneOn = false;

    void Start()
    {
        SceneManager.LoadSceneAsync(Scene, LoadSceneMode.Additive);
        sceneOn = true;
    }
}
