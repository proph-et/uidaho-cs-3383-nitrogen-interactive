using UnityEngine;

public class BossAbilities : MonoBehaviour
{
    [Header("Abilities")]
    public AttackAbility attack;

    private void Awake()
    {
        if (attack == null) attack = GetComponentInChildren<AttackAbility>();
    }
}