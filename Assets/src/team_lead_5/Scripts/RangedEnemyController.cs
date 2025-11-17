using UnityEngine;
using UnityEngine.AI;

public class RangedEnemyController : MonoBehaviour
{
    private RangedEnemy enemyLogic;

    //setup
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public GameObject projectilePrefab;
    private Health healthCall;
    private bool isDead = false;


    //stats
    public float health = 50f;
    public float sightRange = 10f;
    public float attackRange = 5f;
    public float walkPointRange = 10f;
    public float timeBetweenAttacks = 2f;

    private EnemySpawner _spawner;


    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();

        enemyLogic = new RangedEnemy(
            transform, agent, player, whatIsGround, whatIsPlayer, projectilePrefab, walkPointRange
        );

        enemyLogic.health = health;
        enemyLogic.sightRange = sightRange;
        enemyLogic.attackRange = attackRange;
        enemyLogic.timeBetweenAttacks = timeBetweenAttacks;
        //healthCall.AddOnDeathListener(enemyLogic.OnDeath);
        _spawner = FindAnyObjectByType<EnemySpawner>();
    }

    private void Update()
    {
        enemyLogic.UpdateAI();

        if (IsInvoking(nameof(ResetAttack)) == false && enemyLogic != null)
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
    }

    private void ResetAttack()
    {
        enemyLogic.ResetAttack();
    }

    private void OnDrawGizmosSelected()
    {
        if (enemyLogic == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemyLogic.attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, enemyLogic.sightRange);
    }

    public void HandleEnemyDeath()
    {
        if (isDead) return;
        isDead = true;

        // Controller-specific logic
        Debug.Log("RangedEnemyController handling death");
        // Example: play animation, drop loot, notify UI
        _spawner.decrementEnemyCount();
        Destroy(gameObject);
    }
}