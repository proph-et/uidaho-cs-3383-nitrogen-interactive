using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class PlayerBoundaryWestTest
{
    private GameObject player;
    private Rigidbody rb;

    [UnitySetUp]
    public IEnumerator LoadSceneAndFindPlayer()
    {
        // Load the same scene additively so the Test Runner isn't destroyed
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
    public IEnumerator Player_ShouldStopAtWestWall()
    {
        // Reset player state
        rb.linearVelocity = Vector3.zero;
        player.transform.position = Vector3.zero;
        yield return new WaitForFixedUpdate();

        // Push player left (negative X direction)
        rb.linearVelocity = Vector3.left * 10f;
        float elapsed = 0f;

        // Run long enough to reach the wall
        while (elapsed < 3.0f)
        {
            yield return new WaitForFixedUpdate();
            elapsed += Time.fixedDeltaTime;
        }

        float xPos = player.transform.position.x;
        Debug.Log($"Player final X position: {xPos:F2}");

        // Automatically detect the wall's position
        var wall = GameObject.Find("WestWall");
        Assert.IsNotNull(wall, "WestWall not found. Make sure it's named 'WestWall' in the scene.");
        float wallX = wall.transform.position.x;

        // Expected bounds: near wallX, with a small tolerance
        Assert.GreaterOrEqual(xPos, wallX - 5.0f, "Player clipped through the west wall!");
        Assert.LessOrEqual(xPos, wallX + 4.0f, "Player stopped too far from the west wall (check collider spacing).");

        Debug.Log("Player stopped correctly at the west wall.");
    }
}
