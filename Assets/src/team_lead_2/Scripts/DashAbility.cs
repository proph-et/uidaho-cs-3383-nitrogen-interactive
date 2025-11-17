using System;
using System.Collections;
using UnityEngine;

public class DashAbility : Ability
{    
    private float dashSpeed;
    private float dashDuration;
    private float dashCooldown;
    private bool canDash = true;
    private PlayerController controller;
    private Rigidbody rb;
    private Animator animator;


    public DashAbility(PlayerController controller, float speed, float duration, float cooldown)
    {
        this.controller = controller;
        dashSpeed = speed;
        dashDuration = duration;
        dashCooldown = cooldown;

        rb = controller.GetComponent<Rigidbody>();
        animator = controller.GetComponentInChildren<Animator>();
    }

    public override void Activate(GameObject user)
    {
        Debug.Log($"{user.name} activated the Dash ability.");
        if (!canDash) return;
        controller.StartCoroutine(DashRoutine());
    }

    private IEnumerator DashRoutine()
    {
        canDash = false;
        controller.SetInvincible(true);

        if(animator != null)
        {
            animator.SetTrigger("isDashing");
        }

        Vector3 dashDirection = controller.transform.forward;
        rb.linearVelocity = Vector3.zero;

        rb.AddForce(dashDirection * dashSpeed, ForceMode.VelocityChange);

        yield return new WaitForSeconds(0.18f);
        controller.SetInvincible(false);

        yield return new WaitForSeconds(dashDuration - 0.18f);
        rb.linearVelocity = Vector3.zero;

        if(animator != null)
        {
            animator.SetBool("isDashing", false);
        }

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

}
