using UnityEngine;
using System.Collections; // Needed for IEnumerator

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float interval = 0.5f;
    [SerializeField] private GameObject _enemyprefab;
    [SerializeField] private int MaxNumEnemies = 3;
    [SerializeField] private bool oneshot = false;

    public float spawnRadius = 10f;
    private int numberEnemies = 0;

    private Enemy _enemy;

    private void Update()
    {
        if (numberEnemies != MaxNumEnemies && !oneshot)
        {
            StartCoroutine(spawnEnemy(interval, _enemy, MaxNumEnemies));
        }
    }

    void Start()
    {
        _enemy = new Enemy(_enemyprefab);

        if (!oneshot) 
        {
            StartCoroutine(spawnEnemy(interval, _enemy, MaxNumEnemies));
        }
    }

    public void decrementEnemys()
    {
        numberEnemies--;
    }
 
    private IEnumerator spawnEnemy(float interval, Enemy InputEnemy, int MaxNumEnemies)
    {
        yield return new WaitForSeconds(interval);
        Vector3 spawnPos = GetRandomPointInSphere();
        GameObject newEnemy = Instantiate(InputEnemy.prefab, spawnPos, Quaternion.identity);

        //chat
        Enemy newEnemyReference = newEnemy.GetComponent<Enemy>();
        newEnemyReference.SetEnemySpawner(this);

        numberEnemies++;
        //Debug.Log("Enemy: "+ numberEnemies);
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

    public void SpawnEnemyBoss(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            StartCoroutine(spawnEnemy(interval, _enemy, MaxNumEnemies));
        }
    }
}
