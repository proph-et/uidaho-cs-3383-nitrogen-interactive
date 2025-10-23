using UnityEngine;
using System.Collections;

public class Sword : WeaponBase
{

    // public float swingDuration = 0.4f;
    // public Transform hitbox;

    // private bool isSwinging = false;

    // void Update()
    // {
    //     if (Input.GetMouseButtonDown(0) && canAttack && !isSwinging)
    //     {
    //         StartCoroutine(Swing());
    //     }
    // }

    // private IEnumerator Swing()
    // {
    //     isSwinging = true;
    //     Attack();
    //     yield return new WaitForSeconds(swingDuration);
    //     isSwinging = false;

    //     StartCoroutine(AttackCooldown());

    // }

    public override void Attack()
    {
        // hitbox.gameObject.SetActive(true);
        // Invoke("DisableHitbox", 0.2f); //enable briefly

        Debug.Log ("attacking...");
    }

    // private void DisableHitbox()
    // {
    //     hitbox.gameObject.SetActive(false);
    // }


}
