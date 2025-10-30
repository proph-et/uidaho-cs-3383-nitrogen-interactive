using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using System;

public class PlayerDashCollisionTest
{
    private GameObject player;
    private Rigidbody rb;
    private PlayerController controller;

    [UnitySetUp]
    public IEnumerator LoadSceneAndFindPlayer()
    {
        // Load your game scene so we can use the real player + walls
        if (SceneManager.GetActiveScene().name != "SampleScene")
            yield return SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Additive);

        // Wait for scene setup and physics to initialize
        yield return new WaitForSeconds(0.5f);

        player = GameObject.FindWithTag("Player");
        Assert.IsNotNull(player, "Player not found. Make sure it has the 'Player' tag.");

        rb = player.GetComponent<Rigidbody>();
        controller = player.GetComponent<PlayerController>();

        Assert.IsNotNull(rb, "Player is missing a Rigidbody component.");
        Assert.IsNotNull(controller, "Player is missing the PlayerController component.");

        // Reset player to origin
        rb.linearVelocity = Vector3.zero;
        player.transform.position = Vector3.zero;
        player.transform.rotation = Quaternion.identity;
    }

    [UnityTearDown]
    public IEnumerator UnloadScene()
    {
        yield return SceneManager.UnloadSceneAsync("SampleScene");
    }

    [UnityTest, Timeout(120000)]
    public IEnumerator Player_ShouldNotClip_WhileDashingIntoWall()
    {
        Debug.Log("Starting a continious dash collision test.");

        int dashCount = 10;
        float wallZ = 6f;
        for (int i = 0; i < dashCount; i++)
        {
            Debug.Log($" Dash {i + 1}/{dashCount} started.");

            yield return player.GetComponent<MonoBehaviour>().StartCoroutine("Dash");

            yield return new WaitForSeconds(controller.dashDuration + 0.1f);

            float playerZ = player.transform.position.z;

            if (playerZ >= wallZ)
            {
                Assert.Fail($"Player clipped through the wall on dash #{i + 1}. PlayerZ={playerZ}, WallZ={wallZ}");
                yield break;
            }

            Debug.Log($"Dash {i + 1} finished at Z={playerZ}");

            yield return new WaitForSeconds(controller.dashCooldown + 0.05f);
        }

        Debug.Log($"All {dashCount} dashes completed without clipping.");
        Assert.Pass("Player remained contained after all continious dashes.");
    }
}
