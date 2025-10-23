using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class AttackingPlayerTest
{

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator AttackingPlayerWithEnumeratorPasses()
    {        // Create player
             var player = new GameObject("Player");
             player.tag = "Player";
             player.transform.position = Vector3.zero;
     
             // Create enemy
             var enemy = new GameObject("Enemy");
             var ai = enemy.AddComponent<Enemy>();
             ai.attackRange = 5f;
             enemy.transform.position = new Vector3(5f, 0, 0);
            
             // Wait one frame so components initialize
             yield return null;
     
             // Run detection logic
             ai.AttackPlayerCheck();
             
     
             // Verify detection
             Assert.IsTrue(ai.AttackPlayerCheck(), "Enemy should attack the player when within range.");
             
             // Clean up
             //Object.Destroy(player);
            // Object.Destroy(enemy);
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
