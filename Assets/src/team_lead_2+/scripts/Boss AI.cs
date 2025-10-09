using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform player;
    [SerializeField] private LayerMask whatIsGround, whatIsPlayer;

    //to turn boss on and off
    private Boss boss;
    private bool active = false;


    //states 
    [SerializeField] private float sightRange;
    private bool playerInSightRange;

    public void Initialize(Boss bossRef)
    {
        boss = bossRef;
    }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if (boss == null) { return; }

        //check if the player is in sight
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (playerInSightRange) ChasePlayer();
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
}
