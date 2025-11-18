using UnityEngine;
using System.Collections; // Needed for IEnumerator

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float interval = 0.5f;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private int MaxNumEnemies = 3;
    [SerializeField] private bool oneshot = false;

    public float spawnRadius = 10f;
    private int numberEnemies = 0;

    private void Update()
    {
        if (numberEnemies < MaxNumEnemies && !oneshot)
        {
            StartCoroutine(spawnEnemy(interval, _enemy, MaxNumEnemies));
        }
    }

    void Start()
    {
        if (!oneshot)
        {
            StartCoroutine(spawnEnemy(interval, _enemy, MaxNumEnemies));
        }
    }

    public void decrementEnemyCount()
    {
        numberEnemies--;
    }

    private IEnumerator spawnEnemy(float interval, GameObject InputEnemy, int MaxNumEnemies)
    {
        if (numberEnemies < MaxNumEnemies)
        {
            numberEnemies++;
            yield return new WaitForSeconds(interval);
            Vector3 spawnPos = GetRandomPointOnGround();
            GameObject newEnemy = Instantiate(InputEnemy, spawnPos, Quaternion.identity);
        }
    }

    Vector3 GetRandomPointOnGround()
    {
        Vector2 circle = Random.insideUnitCircle * spawnRadius;

        return new Vector3(
            transform.position.x + circle.x,
            transform.position.y,       // Always spawn at ground height
            transform.position.z + circle.y
        );
    }
    
    /*Vector3 GetRandomPointInSphere()
    {
        Vector3 randomPoint = Random.insideUnitSphere * spawnRadius;
        // Offset by this spawner's position
        return transform.position + randomPoint;
    }*/

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }

    public void SpawnEnemyBoss(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            if(numberEnemies < MaxNumEnemies)
            {
                StartCoroutine(spawnEnemy(interval, _enemy, MaxNumEnemies));
            }
        }
    }
}