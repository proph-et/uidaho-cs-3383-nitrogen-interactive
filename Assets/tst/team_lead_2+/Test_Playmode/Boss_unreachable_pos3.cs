using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class Boss_unreachable_pos3
{
    [UnityTest]
    public IEnumerator Boss_Does_Not_Leave_Map()
    {
        yield return SceneManager.LoadSceneAsync("Boss_Boundri_test_boss", LoadSceneMode.Single);
        yield return null;

        GameObject bossObj = GameObject.FindWithTag("Boss");
        Assert.IsNotNull(bossObj, "Boss object not found in scene! Make sure it has tag 'Boss'.");

        var agent = bossObj.GetComponent<NavMeshAgent>();
        Assert.IsNotNull(agent, "Boss does not have a NavMeshAgent!");

        NavMeshHit hit;
        Assert.IsTrue(
            NavMesh.SamplePosition(bossObj.transform.position, out hit, 1f, NavMesh.AllAreas),
            "Boss is NOT placed on the NavMesh at start!"
        );

        float moveSpeed = 5f;
        float duration = 4f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            agent.Move(Vector3.forward * moveSpeed * Time.deltaTime);

            yield return null;
        }

        bool stillOnMesh = NavMesh.SamplePosition(bossObj.transform.position, out _, 0.1f, NavMesh.AllAreas);
        Assert.IsTrue(stillOnMesh, "Boss left the NavMesh! Boundary check failed.");
    }
}