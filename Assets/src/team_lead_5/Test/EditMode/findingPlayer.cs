using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class findingPlayerTest
{
    [UnityTest]
    public IEnumerator findingPlayerWithEnumeratorPasses()
    {        // Create player
             var player = new GameObject("Player");
             player.tag = "Player";
             player.transform.position = Vector3.zero;
     
             // Create enemy
             var enemy = new GameObject("Enemy");
             var ai = enemy.AddComponent<Enemy>();
             ai.sightRange = 10f;
             enemy.transform.position = new Vector3(5f, 0, 0);
            
             // Wait one frame so components initialize
             yield return null;
     
             // Run detection logic
             ai.FindPlayerCheck();
             
             // Verify detection
             Assert.IsTrue(ai.FindPlayerCheck(), "Enemy should detect the player when within range.");
             
        yield return null;
    }
}
