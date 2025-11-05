using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using System;

public class PlayerDashCollision_WestTest
{
    private GameObject player;
    private Rigidbody rb;
    private PlayerController controller;

    [UnitySetUp]
    public IEnumerator LoadSceneAndFindPlayer()
    {
        if (SceneManager.GetActiveScene().name != "SampleScene")
            yield return SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Additive);

        yield return new WaitForSeconds(0.5f);

        player = GameObject.FindWithTag("Player");
        Assert.IsNotNull(player, "Player not found. Make sure it has the 'Player' tag.");

        rb = player.GetComponent<Rigidbody>();
        controller = player.GetComponent<PlayerController>();

        Assert.IsNotNull(rb, "Player is missing a Rigidbody component.");
        Assert.IsNotNull(controller, "Player is missing the PlayerController component.");

        rb.linearVelocity = Vector3.zero;
        player.transform.position = Vector3.zero;
        player.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
    }

    [UnityTearDown]
    public IEnumerator UnloadScene()
    {
        yield return SceneManager.UnloadSceneAsync("SampleScene");
    }

    [UnityTest, Timeout(120000)]
    public IEnumerator Player_ShouldNotClip_WhileDashingIntoWestWall()
    {
        Debug.Log("Starting continuous west-wall dash collision test.");

        player.transform.rotation = Quaternion.Euler(0f, -90f, 0f);

        int dashCount = 10;
        float wallX = -6f; 

        for (int i = 0; i < dashCount; i++)
        {
            Debug.Log($"Dash {i + 1}/{dashCount} started.");

            yield return player.GetComponent<MonoBehaviour>().StartCoroutine("Dash");

            yield return new WaitForSeconds(controller.dashDuration + 0.1f);

            float playerX = player.transform.position.x;

            if (playerX <= wallX)
            {
                Assert.Fail($"Player clipped through the west wall on dash #{i + 1}. PlayerX={playerX}, WallX={wallX}");
                yield break;
            }

            Debug.Log($"Dash {i + 1} finished at X={playerX}");

            yield return new WaitForSeconds(controller.dashCooldown + 0.05f);
        }

        Debug.Log($"All {dashCount} west-facing dashes completed without clipping.");
        Assert.Pass("Player remained contained after all continuous west-facing dashes.");
    }
}
