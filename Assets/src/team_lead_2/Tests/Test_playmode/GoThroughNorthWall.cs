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
        // Load your scene additively so the Test Runner stays alive
        if (SceneManager.GetActiveScene().name != "SampleScene")
            yield return SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Additive);

        yield return new WaitForSeconds(0.5f);

        player = GameObject.FindWithTag("Player");
        Assert.IsNotNull(player, "Player not found. Make sure it's tagged 'Player'.");

        rb = player.GetComponent<Rigidbody>();
        Assert.IsNotNull(rb, "Player must have a Rigidbody.");
    }

    [UnityTearDown]
    public IEnumerator UnloadScene()
    {
        yield return SceneManager.UnloadSceneAsync("SampleScene");
    }

    [UnityTest]
    public IEnumerator Player_ShouldStopAtNorthWall()
    {
        // Reset player state
        rb.linearVelocity = Vector3.zero;
        player.transform.position = Vector3.zero;
        yield return new WaitForFixedUpdate();

        // Push the player northward (positive Z direction)
        rb.linearVelocity = Vector3.forward * 10f;

        // Let it move for a short duration
        float elapsed = 0f;
        while (elapsed < 2f)
        {
            yield return new WaitForFixedUpdate();
            elapsed += Time.fixedDeltaTime;
        }

        // Check final position — should be close to the wall but not beyond it
        float zPos = player.transform.position.z;
        Debug.Log($"Player final Z position: {zPos:F2}");

        // Adjust this threshold to match your actual wall Z position
        Assert.LessOrEqual(zPos, 6.0f, "Player clipped through the north wall!");
        Assert.Greater(zPos, 4.0f, "Player stopped too far from the north wall (check collider spacing).");

        Debug.Log("Player stopped correctly at the north wall.");
    }
}
