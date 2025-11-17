using UnityEngine;
using UnityEngine.AI;

public class BossMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float baseSpeed = 3.5f;

    private float speedMultiplier = 1f;

    private Transform player;
    private NavMeshAgent agent;
    private Animator animator;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();

        var playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;

        agent.speed = baseSpeed;
    }

    public void MoveTowardsPlayer()
    {
        if (player == null || agent == null)
            return;

        agent.isStopped = false;

        agent.SetDestination(player.position);

        // Switch Animator to Walking
        animator.SetBool("isMoving", true);
    }

    public void StopMoving()
    {
        if (agent != null)
        {
            agent.isStopped = true;
            agent.velocity = Vector3.zero;
        }

        // Switch Animator to Idle
        if (animator != null)
            animator.SetBool("isMoving", false);
    }

    public void SetSpeedMultiplier(float value)
    {
        speedMultiplier = value;
        agent.speed = baseSpeed * speedMultiplier;
        animator.SetFloat("SpeedMultiplier", speedMultiplier);
    }
}

