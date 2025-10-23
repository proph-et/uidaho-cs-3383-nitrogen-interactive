using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class stress_test_because_tarded : MonoBehaviour
{
    private string prefabpath = "prefabs/Boss_obj";
    private int totalNumberOfSpawns = 10000;
    private int spawnPerFrame = 10;
    private Vector3 spawnpoint = new Vector3(0f, 1f, 0f);

    private GameObject bossPrefab;

    public void Start()
    {
        bossPrefab = Resources.Load<GameObject>(prefabpath);

        if (bossPrefab == null)
        {
            Debug.LogError("Prefab not found at path: " + prefabpath);
            return;
        }

        StartCoroutine(stress_test_because_tarded_spawn_infinite_amount_of_Bosses_for_no_fucking_reason());
    }
    public IEnumerator stress_test_because_tarded_spawn_infinite_amount_of_Bosses_for_no_fucking_reason()
    {
        int spawnedCount = 0;


        while (spawnedCount < totalNumberOfSpawns)
        {
            int spawnThisFrame = Mathf.Min(spawnPerFrame, totalNumberOfSpawns - spawnedCount);
        

            //spawn in multiple bosses each frame
            for (int i = 0; i < spawnThisFrame; i++)
            {
                GameObject bossObj = Object.Instantiate(bossPrefab, spawnpoint, Quaternion.identity);
                var agent = bossObj.GetComponent<NavMeshAgent>();
            }
            spawnedCount += spawnThisFrame;

            Debug.Log($"Spawned {spawnedCount}/{totalNumberOfSpawns} totalNumberOfSpawns");

            yield return null;
        }
        Debug.Log("survieved stress test completed!");
    }
}
