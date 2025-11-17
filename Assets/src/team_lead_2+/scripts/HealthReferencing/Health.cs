using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [Header("Health Settings")] [SerializeField]
    private float maxHealth = 100f;

    private float currentHealth;

    [Header("Events")] [SerializeField] private UnityEvent onDeath;
    [SerializeField] private UnityEvent<float> onDamage;

    private bool isDead = false;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        Debug.Log($"{gameObject.name} taking {amount} damage");
        if (currentHealth <= 0f) return;

        currentHealth = Mathf.Max(currentHealth - amount, 0f);
        onDamage?.Invoke(amount);

        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            onDeath.Invoke();
        }
    }

    public void Heal(float amount, bool respawning = false)
    {
        if (currentHealth <= 0f && !respawning) return;
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
    }

    // --- Getters (safe access) ---
    public float GetCurrentHealth() => currentHealth;
    public float GetMaxHealth() => maxHealth;
    public float GetHealthRatio() => currentHealth / maxHealth;

    // --- Event subscription ---
    public void AddOnDeathListener(UnityAction action) => onDeath.AddListener(action);
    public void AddOnDamageListener(UnityAction<float> action) => onDamage.AddListener(action);
}