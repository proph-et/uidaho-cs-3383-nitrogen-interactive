using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEditor;

public class TL4PlayModeTests
{
    private GameObject CollectablePrefab;
    private Transform parentContainer;

    public IEnumerator LoadScene()
    {
        SceneManager.LoadScene("SampleSceneCollectibles");
        yield return null;
    }

    [SetUp]
    public void Setup()
    {
        CollectablePrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/src/team_lead_4/PreFabs/Item.prefab");
        parentContainer = new GameObject("CollectibleContainer").transform;

        Assert.NotNull(CollectablePrefab);
   //     Debug.Log($"Scene exists? {System.IO.File.Exists("Assets/src/team_lead_4/Scenes/SampleSceneCollectibles.unity")}");
    }

    [UnityTest]
    public IEnumerator SpawnAsManyItemsAsPossible()
    {
        yield return LoadScene();
        int maxSpawn = 100000;
        int count = 0;

        while (true){
            GameObject spawned = Object.Instantiate(CollectablePrefab, Random.insideUnitSphere * 5f, Quaternion.identity, parentContainer);
            Assert.NotNull(spawned);
            count ++;
            if (count % 1000 == 0)
            {
                Debug.Log ($"Spawned {count} collectibles");
                yield return null;
            }

            if (Time.deltaTime > 0.1f)
            {
                Debug.Log("performance issues, failed");
                Assert.Fail();

            }

        }

        // Assert.Fail("limit reached");

    }
}
