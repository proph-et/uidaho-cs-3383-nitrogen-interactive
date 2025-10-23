using UnityEngine;
using System.Collections; // Needed for IEnumerator

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float interval = 0.5f;
    [SerializeField] private GameObject Enemy;
    private int numberEnemies = 0;
   void Start()
    {
        StartCoroutine(spawnEnemy(interval, Enemy));
    }
 
    private IEnumerator spawnEnemy(float interval, GameObject Enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(Enemy, new Vector3(0, 0, 0), Quaternion.identity);
        numberEnemies++;
        Debug.Log("Enemy: "+ numberEnemies);
        StartCoroutine(spawnEnemy(interval, Enemy));
    }
}
