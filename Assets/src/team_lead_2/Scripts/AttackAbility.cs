using System.Collections;
using UnityEngine;

public class AttackAbility : Ability
{
    private float attackDamage;
    private float attackRange;
    private float attackDuration;
    private float attackCooldown;
    private bool canAttack = true;
    private PlayerController controller;
    private Animator animator;


   public AttackAbility(PlayerController controller, float damage, float range, float duration, float cooldown)
    {

        this.controller = controller;
        attackDamage = damage;
        attackRange = range;
        attackDuration = duration;
        attackCooldown = cooldown;

        animator = controller.GetComponentInChildren<Animator>();
    }

    public override void Activate(GameObject user)
    {
        if (!canAttack) return;
        controller.StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        canAttack = false;

        if(animator != null)
        {
            animator.SetTrigger("isAttacking");
        }

        Vector3 attackDirection = controller.transform.forward;
        Debug.Log($"Attacking in Direction: { attackDirection}");

        RaycastHit[] hits = Physics.SphereCastAll(controller.transform.position +
        controller.transform.forward,
        0.5f,
        controller.transform.forward, attackRange);

        if (hits.Length > 0)
        {
            foreach (var hit in hits)
            {
                if (hit.transform == controller.transform) continue;
                if (hit.transform.TryGetComponent(out Health targetHealth))
                {
                    targetHealth.TakeDamage(attackDamage);
                    Debug.Log($"{hit.transform.name} took {attackDamage} damage. Remaming Health: {targetHealth.GetCurrentHealth()}");
                }
                else
                {
                    Debug.Log($"{hit.transform.name} has no Health component.");
                }
            }
        }
        else
        {
            Debug.Log("No targets hit.");
        }
        
        yield return new WaitForSeconds(attackDuration);

        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
