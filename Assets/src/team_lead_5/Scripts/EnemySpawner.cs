using UnityEngine;
using System.Collections; // Needed for IEnumerator

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float interval = 0.5f;
    [SerializeField] private GameObject Enemy;
    [SerializeField] private int MaxNumEnemies = 3;
    public float spawnRadius = 10f;
    private int numberEnemies = 0;
   void Start()
    {
        StartCoroutine(spawnEnemy(interval, Enemy, MaxNumEnemies));
    }
 
    private IEnumerator spawnEnemy(float interval, GameObject Enemy, int MaxNumEnemies)
    {
        yield return new WaitForSeconds(interval);
        Vector3 spawnPos = GetRandomPointInSphere();
        GameObject newEnemy = Instantiate(Enemy, spawnPos, Quaternion.identity);
        numberEnemies++;
        //Debug.Log("Enemy: "+ numberEnemies);
        if (numberEnemies != MaxNumEnemies)
        {
            StartCoroutine(spawnEnemy(interval, Enemy, MaxNumEnemies));
        }
    }
    
    Vector3 GetRandomPointInSphere()
    {
        Vector3 randomPoint = Random.insideUnitSphere * spawnRadius;
        // Offset by this spawner's position
        return transform.position + randomPoint;
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
