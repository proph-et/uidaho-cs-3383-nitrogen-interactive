using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class TL2plus_PlayerBoundaryEastTest
{
    private GameObject player;
    private Rigidbody rb;

    [UnitySetUp]
    public IEnumerator LoadSceneAndFindPlayer()
    {
        if (SceneManager.GetActiveScene().name != "Boss_test_player_behavior")
            yield return SceneManager.LoadSceneAsync("Boss_test_player_behavior", LoadSceneMode.Additive);

        yield return new WaitForSeconds(0.5f);

        player = GameObject.FindWithTag("Player");
        Assert.IsNotNull(player, "Player not found.");

        rb = player.GetComponent<Rigidbody>();
        Assert.IsNotNull(rb, "Player missing Rigidbody.");
    }

    [UnityTearDown]
    public IEnumerator UnloadScene()
    {
        yield return SceneManager.UnloadSceneAsync("Boss_test_player_behavior");
    }

    [UnityTest]
    public IEnumerator Player_ShouldStopAtEastWall()
    {
        Transform spawn = GameObject.Find("SpawnPoint")?.transform;
        Assert.IsNotNull(spawn, "Missing SpawnPoint in scene!");

        rb.linearVelocity = Vector3.zero;
        rb.position = spawn.position;
        yield return new WaitForFixedUpdate();

        rb.AddForce(Vector3.right * 80f, ForceMode.VelocityChange);

        float elapsed = 0f;
        while (elapsed < 5f)
        {
            yield return new WaitForFixedUpdate();
            elapsed += Time.fixedDeltaTime;
        }

        float xPos = player.transform.position.x;
        Debug.Log($"Player final X position: {xPos:F2}");

        Assert.LessOrEqual(xPos, 20.0f, "Player clipped through the east wall!");
        Assert.Greater(xPos, 15.0f, "Player stopped too far from the east wall.");

        Debug.Log("Player stopped correctly at the east wall.");
    }
}
