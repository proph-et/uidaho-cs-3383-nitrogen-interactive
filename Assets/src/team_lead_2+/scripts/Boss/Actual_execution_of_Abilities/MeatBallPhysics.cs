using Mono.Cecil;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class MeatBallPhysics : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float followHeight = 3f;
    [SerializeField] private float followSpeed = 5f;
    [SerializeField] private float fallSpeed = 10f;
    [SerializeField] private float damage = 20f;
    [SerializeField] private int amountToSpawn = 3;

    private Transform target;
    private bool isFalling = false;

    private EnemySpawner enemySpawner;


    private void Awake()
    {
        enemySpawner = FindAnyObjectByType<EnemySpawner>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            target = player.transform;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (!isFalling)
        {
            TrackTarget();
        }
        else
            FallDownward();
    }



    private void TrackTarget()
    {
        if (target == null) { return; }

        Vector3 disiredPos = target.position + Vector3.up * followHeight;
        transform.position = Vector3.Lerp(transform.position, disiredPos, Time.deltaTime * followSpeed);

        float dist = Vector3.Distance(transform.position, disiredPos);

        if(dist < 0.1f)
        {
            DropDown();
        }

    }

    private void FallDownward()
    {
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
    }

    public void DropDown()
    {
        isFalling = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Health hp = other.GetComponent<Health>();
            if (hp != null)
            {
                hp.TakeDamage(damage);
            }
            //spawn enemys if ready
            HandleEnemyspawn();
            Destroy(gameObject);
        }

        if(other.gameObject.layer == LayerMask.NameToLayer("whatIsGround"))
        {
            HandleEnemyspawn();
            Destroy(gameObject);
            //spawn enemys if ready
        }
    }

    private void HandleEnemyspawn()
    {
        if(enemySpawner != null)
        {
            Vector3 spawnPos = transform.position;
            spawnPos.y = 0;

            enemySpawner.transform.position = spawnPos;

            enemySpawner.SpawnEnemyBoss(amountToSpawn);
        }
    }
}
