using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class TL2plus_Corner_test
{
    private GameObject player;
    private Rigidbody rb;

    [UnitySetUp]
    public IEnumerator LoadSceneAndFindPlayer()
    {
        // Load your scene additively so the TestRunner object isn't destroyed
        if (SceneManager.GetActiveScene().name != "Boss_test_player_behavior")
            yield return SceneManager.LoadSceneAsync("Boss_test_player_behavior", LoadSceneMode.Additive);

        // Wait a short moment for scene physics and Awake() calls to finish
        yield return new WaitForSeconds(0.5f);

        player = GameObject.FindWithTag("Player");
        Assert.IsNotNull(player, "Player not found. Make sure the object is tagged 'Player'.");

        rb = player.GetComponent<Rigidbody>();
        Assert.IsNotNull(rb, "Player needs a Rigidbody.");

        rb.collisionDetectionMode = CollisionDetectionMode.Discrete;

        rb.linearVelocity = Vector3.zero;
        player.transform.position = Vector3.zero;
    }

    [UnityTearDown]
    public IEnumerator UnloadScene()
    {
        yield return SceneManager.UnloadSceneAsync("Boss_test_player_behavior");
    }

    [UnityTest]
    public IEnumerator Player_ShouldClipAtHighSpeed()
    {
        bool clipped = false;
        float safeSpeed = 0f;

        Transform spawn = GameObject.Find("SpawnPoint").transform;
        Assert.IsNotNull(spawn, "Missing SpawnPoint transform!");

        for (float speed = 10f; speed <= 400f; speed += 10f)
        {
            rb.linearVelocity = Vector3.zero;

            rb.position = spawn.position;
            yield return new WaitForFixedUpdate();

            rb.linearVelocity = (Vector3.forward + Vector3.left).normalized * speed;

            float elapsed = 0f;
            while (elapsed < 0.5f)
            {
                yield return new WaitForFixedUpdate();
                elapsed += Time.fixedDeltaTime;
            }

            if (player.transform.position.z >= 17f || player.transform.position.x <= -17f)
            {
                Debug.LogWarning($"Player clipped through wall at ≈ {speed}");
                clipped = true;
                break;
            }

            safeSpeed = speed;
        }

        Assert.IsTrue(safeSpeed > 0f, "Player clipped immediately — check player collider bounds.");
    }
}