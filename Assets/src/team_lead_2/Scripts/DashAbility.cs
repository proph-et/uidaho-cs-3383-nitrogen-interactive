using System;
using System.Collections;
using UnityEngine;

public class DashAbility : Ability
{
    private float dashSpeed;
    private float dashDuration;

    public DashAbility(float speed, float duration)
    {
        dashSpeed = speed;
        dashDuration = duration;
    }

    public override void Activate(GameObject user)
    {
        Debug.Log($"{user.name} activated Dash.");

        PlayerController controller = user.GetComponent<PlayerController>();
        if (controller == null)
        {
            Debug.LogWarning("DashAbility: PlayerController not found on user.");
            return;
        }

        controller.StartCoroutine(controller.Dash());
    }

}
