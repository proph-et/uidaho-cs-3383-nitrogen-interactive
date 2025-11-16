using UnityEngine;
using UnityEngine.AI;


public class RangedEnemy : BaseEnemy
{
    private GameObject projectilePrefab;

    public RangedEnemy(Transform context, NavMeshAgent agent, Transform player,
        LayerMask ground, LayerMask playerMask, GameObject projectile, float walkRange = 10f)
        : base(context, agent, player, ground, playerMask, walkRange)
    {
        projectilePrefab = projectile;
    }

    protected override void Attack()
    {
        agent.SetDestination(contextTransform.position);
        contextTransform.LookAt(player);

        if (!alreadyAttacked)
        {
            Vector3 direction = (player.position - contextTransform.position).normalized;

            Rigidbody rb = Object.Instantiate(
                projectilePrefab,
                contextTransform.position + direction * 1f + Vector3.up * 1f,
                Quaternion.LookRotation(direction)
            ).GetComponent<Rigidbody>();

            rb.AddForce(direction * 10f, ForceMode.Impulse);

            alreadyAttacked = true;
        }
    }
}