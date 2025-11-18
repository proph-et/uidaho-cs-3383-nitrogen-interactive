using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class PlayerBoundaryNorthTest
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
        Assert.IsNotNull(player, "Player not found. Make sure it's tagged 'Player'.");

        rb = player.GetComponent<Rigidbody>();
        Assert.IsNotNull(rb, "Player must have a Rigidbody.");
    }

    [UnityTearDown]
    public IEnumerator UnloadScene()
    {
        yield return SceneManager.UnloadSceneAsync("Boss_test_player_behavior");
    }

    [UnityTest]
    public IEnumerator Player_ShouldStopAtNorthWall()
    {
        Transform spawn = GameObject.Find("SpawnPoint")?.transform;
        Assert.IsNotNull(spawn, "Missing SpawnPoint in scene!");

        var cc = player.GetComponent<CharacterController>();
        if (cc != null) cc.enabled = false;

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        rb.position = spawn.position + Vector3.up * 0.05f;

        yield return new WaitForFixedUpdate();
        yield return new WaitForFixedUpdate();

        rb.AddForce(Vector3.forward * 80f, ForceMode.VelocityChange);

        float elapsed = 0f;
        while (elapsed < 5.0f)
        {
            yield return new WaitForFixedUpdate();
            elapsed += Time.fixedDeltaTime;
        }

        float zPos = player.transform.position.z;
        Debug.Log($"Player final Z position: {zPos:F2}");

        Assert.LessOrEqual(zPos, 20.0f, "Player clipped through the north wall!");
        Assert.Greater(zPos, 16.0f, "Player stopped too early before the north wall!");

        if (cc != null) cc.enabled = true;

        Debug.Log("Player stopped correctly at the north wall.");
    }
}
