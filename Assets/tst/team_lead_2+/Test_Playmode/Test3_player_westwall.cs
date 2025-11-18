using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class TL2plus_PlayerBoundaryWestTest
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
        Assert.IsNotNull(player);

        rb = player.GetComponent<Rigidbody>();
        Assert.IsNotNull(rb);
    }

    [UnityTearDown]
    public IEnumerator UnloadScene()
    {
        yield return SceneManager.UnloadSceneAsync("Boss_test_player_behavior");
    }

    [UnityTest]
    public IEnumerator Player_ShouldStopAtWestWall()
    {
        Transform spawn = GameObject.Find("SpawnPoint")?.transform;
        Assert.IsNotNull(spawn);

        var cc = player.GetComponent<CharacterController>();
        if (cc != null) cc.enabled = false;

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.position = spawn.position + Vector3.up * 0.05f;

        yield return new WaitForFixedUpdate();
        yield return new WaitForFixedUpdate();

        rb.AddForce(Vector3.left * 80f, ForceMode.VelocityChange);

        float t = 0f;
        while (t < 5.0f)
        {
            yield return new WaitForFixedUpdate();
            t += Time.fixedDeltaTime;
        }

        float xPos = player.transform.position.x;

        Assert.GreaterOrEqual(xPos, -20.0f, "Player clipped through the west wall!");
        Assert.LessOrEqual(xPos, -15.0f, "Player stopped too early before the west wall!");

        if (cc != null) cc.enabled = true;
    }
}
