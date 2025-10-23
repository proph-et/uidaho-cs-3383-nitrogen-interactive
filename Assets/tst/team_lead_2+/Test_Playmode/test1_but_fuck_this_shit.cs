using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class test1_but_fuck_this_shit
{
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator test1_but_fuck_this_shit_boss_does_not_leave_NavMesh()
    {
        //Load the scene and wait a frame for it
        yield return SceneManager.LoadSceneAsync("Boss_test_boundries", LoadSceneMode.Single);
        yield return null;

        //spawn boss in
        Vector3 spawnPoint = new Vector3(0f, 1f, 0f);
        GameObject bossPrefab = Resources.Load<GameObject>("prefabs/Boss_obj");
        GameObject bossObj = Object.Instantiate(bossPrefab, spawnPoint, Quaternion.identity);
        var agent = bossObj.GetComponent<NavMeshAgent>();

        NavMeshHit starthit;
        Assert.IsTrue(NavMesh.SamplePosition(bossObj.transform.position, out starthit, 1f, NavMesh.AllAreas));

        float moveSpeed = 3f;
        float duration = 5f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            Vector3 moveDelta = Vector3.right * moveSpeed * Time.deltaTime;
            agent.Move(moveDelta);

            yield return null;
        }


        //assert
        bool stillOnNavMesh = NavMesh.SamplePosition(bossObj.transform.position,out _, 1f, NavMesh.AllAreas);
        Assert.IsTrue(stillOnNavMesh);

        Object.Destroy(bossObj);
    }
}
