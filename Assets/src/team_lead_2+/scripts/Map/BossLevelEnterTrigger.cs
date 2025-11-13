using UnityEngine;
using UnityEngine.SceneManagement;

public class BossLevelEnterTrigger : MonoBehaviour
{
    [SerializeField] private string SceneToLoad;
    private KeyCode interactKey = KeyCode.E;
    [SerializeField] private GameObject interactPrompt;

    private bool playerInRange = false;

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(interactKey))
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene(SceneToLoad);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Transform spawnpoint = GameObject.Find("SpawnPoint").transform;

        player.transform.position = spawnpoint.position;

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            interactPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            interactPrompt.SetActive(false);
        }
    }
}
