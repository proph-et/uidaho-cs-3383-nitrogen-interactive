using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopInterfaceManager : MonoBehaviour
{
    [SerializeField] private string Scene = "ShopInterfaceScene";
    private bool sceneOn = false;

    void Start()
    {
        SceneManager.LoadSceneAsync(Scene, LoadSceneMode.Additive);
        sceneOn = true;
    }
}