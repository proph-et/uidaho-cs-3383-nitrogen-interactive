using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class PlayerSceneClipTest
{
    private GameObject player;
    private Rigidbody rb;

    [UnitySetUp]
    public IEnumerator LoadSceneAndFindPlayer()
    {
        // Load your scene additively so the TestRunner object isn't destroyed
        if (SceneManager.GetActiveScene().name != "SampleScene")
            yield return SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Additive);

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
        yield return SceneManager.UnloadSceneAsync("SampleScene");
    }

    [UnityTest, Timeout(120000)]
    public IEnumerator Player_ShouldClipAtHighSpeed()
    {
        bool clipped = false;
        float safeSpeed = 0f;

        for (float speed = 10f; speed <= 400f; speed += 10f)
        {
            rb.linearVelocity = Vector3.zero;
            player.transform.position = Vector3.zero;
            yield return new WaitForFixedUpdate();

            // Push player forward
            rb.linearVelocity = (Vector3.forward + Vector3.left) * speed;

            float elapsed = 0f;
            while (elapsed < 0.5f)
            {
                yield return new WaitForFixedUpdate();
                elapsed += Time.fixedDeltaTime;
            }

            // If player moved past expected wall position, assume clipping
            if (player.transform.position.z >= 6f) // adjust for your map scale
            {
                Debug.LogWarning($"Player clipped through wall at ≈ {speed}");
                clipped = true;
                break;
            }

            safeSpeed = speed;
        }

        if (!clipped)
            Debug.Log($"Player stayed contained up to {safeSpeed} speed.");
        else
            Debug.Log($"Player started clipping near {safeSpeed + 5f} speed.");

        Assert.Greater(safeSpeed, 0f, "Player clipped immediately — check colliders or Rigidbody mode.");
    }
}
