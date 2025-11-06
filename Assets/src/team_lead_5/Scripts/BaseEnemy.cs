using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BaseEnemy
{
    // --- Core stats ---
    public float health;
    public float sightRange;
    public float attackRange;
    public float timeBetweenAttacks;

    // --- State ---
    protected bool alreadyAttacked;
    protected bool walkPointSet;
    protected Vector3 walkPoint;

    // --- Environment & references ---
    protected NavMeshAgent agent;
    protected Transform player;
    protected Transform contextTransform;
    protected LayerMask whatIsGround, whatIsPlayer;
    protected float walkPointRange;

    // --- Loot ---
    public List<LootItem> lootTable = new List<LootItem>();

    // --- Constructor ---
    public BaseEnemy(Transform context, NavMeshAgent agent, Transform player, 
                     LayerMask ground, LayerMask playerMask, float walkRange = 10f)
    {
        this.contextTransform = context;
        this.agent = agent;
        this.player = player;
        this.whatIsGround = ground;
        this.whatIsPlayer = playerMask;
        this.walkPointRange = walkRange;
    }

    // --- Public AI driver ---
    public virtual void UpdateAI() 
    {
        bool playerInSight = Physics.CheckSphere(contextTransform.position, sightRange, whatIsPlayer);
        bool playerInAttack = Physics.CheckSphere(contextTransform.position, attackRange, whatIsPlayer);

        if (!playerInSight && !playerInAttack)
            Patrol();
        else if (playerInSight && !playerInAttack)
            Chase();
        else if (playerInAttack && playerInSight)
            Attack();
    }

    // --- Core behaviors (virtual) ---
    protected virtual void Patrol() 
    {
        if (!walkPointSet)
            SearchWalkPoint();
        else
            agent.SetDestination(walkPoint);

        if (Vector3.Distance(contextTransform.position, walkPoint) < 1f)
            walkPointSet = false;
    }

    protected virtual void SearchWalkPoint() 
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(
            contextTransform.position.x + randomX,
            contextTransform.position.y,
            contextTransform.position.z + randomZ
        );

        if (Physics.Raycast(walkPoint, -contextTransform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    protected virtual void Chase()
    {
        agent.SetDestination(player.position);
    }

    protected virtual void Attack() 
    {
        // Default: no implementation (meant to be overridden)
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
            OnDeath();
    }

    protected virtual void OnDeath()
    {
        Object.Destroy(contextTransform.gameObject, 0.5f);
    }

    public virtual void ResetAttack()
    {
        alreadyAttacked = false;
    }
}