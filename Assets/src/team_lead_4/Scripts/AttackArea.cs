using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 50;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Enemy enemy = collider.GetComponent<Enemy>();


        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }
    }
}
