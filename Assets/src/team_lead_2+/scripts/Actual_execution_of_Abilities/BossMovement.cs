using UnityEngine;
using UnityEngine.AI;

public class BossMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float baseSpeed = 3.5f;

    private float speedMultiplier = 1f;

    private Transform player;
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

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
    }

    public void StopMoving()
    {
        if (agent != null)
            agent.isStopped = true;
    }

    public void SetSpeedMultiplier(float value)
    {
        speedMultiplier = value;
        agent.speed = baseSpeed * speedMultiplier;
    }
}

