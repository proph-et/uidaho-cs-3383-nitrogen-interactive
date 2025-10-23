using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class test2_here_we_go_again
{
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator test2_here_we_go_again_with_more_speed()
    {
        //Load the scene and wait a frame for it
        yield return SceneManager.LoadSceneAsync("Boss_test_boundries", LoadSceneMode.Single);
        yield return null;

        //spawn boss in
        Vector3 spawnPoint = new Vector3(0f, 1f, 0f); // x, y, z
        GameObject bossPrefab = Resources.Load<GameObject>("prefabs/Boss_obj");
        GameObject bossObj = Object.Instantiate(bossPrefab, spawnPoint, Quaternion.identity);
        var agent = bossObj.GetComponent<NavMeshAgent>();

        NavMeshHit starthit;
        Assert.IsTrue(NavMesh.SamplePosition(bossObj.transform.position, out starthit, 1f, NavMesh.AllAreas));

        float moveSpeed = 3f;
        float duration = 10f;
        float elapsed = 0f;

        agent.SetDestination(bossObj.transform.position + Vector3.back * 10f);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            moveSpeed += 5f * Time.deltaTime;
            Debug.Log($"MoveSpeed: {moveSpeed}");
            agent.speed = moveSpeed;

            yield return null;
        }


        //assert
        bool stillOnNavMesh = NavMesh.SamplePosition(bossObj.transform.position,out _, 1f, NavMesh.AllAreas);
        Assert.IsTrue(stillOnNavMesh);

        Object.Destroy(bossObj);
    }
}
