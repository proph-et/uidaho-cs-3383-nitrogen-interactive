using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 50f;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void takeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log("took damage");

        if (currentHealth <=0)
        {
            Debug.Log("died");
            Destroy(gameObject);
        }
    }
    
}
