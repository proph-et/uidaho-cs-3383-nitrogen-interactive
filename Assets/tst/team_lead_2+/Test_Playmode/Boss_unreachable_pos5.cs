using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class Boss_unreachable_pos5
{
    [UnityTest]
    public IEnumerator Boss_Cannot_Walk_Into_Lava()
    {
        yield return SceneManager.LoadSceneAsync("Boss_Boundri_test_boss", LoadSceneMode.Single);
        yield return null;

        GameObject bossObj = GameObject.FindWithTag("Boss");
        Assert.IsNotNull(bossObj, "Boss not found. Make sure it has tag 'Boss'.");

        NavMeshAgent agent = bossObj.GetComponent<NavMeshAgent>();
        Assert.IsNotNull(agent, "Boss missing NavMeshAgent.");

        GameObject startPos = GameObject.Find("Boss_Sauce_Spawn");
        Assert.IsNotNull(startPos, "Missing Boss_Lava_Start object in the scene!");

        agent.Warp(startPos.transform.position);

        Assert.IsTrue(
            NavMesh.SamplePosition(agent.transform.position, out _, 1f, NavMesh.AllAreas),
            "Boss start position is NOT on the NavMesh!"
        );

        float moveSpeed = 5f;
        float duration = 3f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            agent.Move(agent.transform.forward * moveSpeed * Time.deltaTime);

            yield return null;
        }

        // Boss must STILL be on the navmesh (lava should be unwalkable)
        bool stillOnMesh = NavMesh.SamplePosition(agent.transform.position, out _, 0.1f, NavMesh.AllAreas);

        Assert.IsTrue(stillOnMesh, "Boss entered the lava! He left the NavMesh.");
    }
}