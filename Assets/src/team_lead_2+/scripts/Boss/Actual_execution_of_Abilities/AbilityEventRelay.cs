using UnityEngine;

public class AbilityEventRelay : MonoBehaviour
{
    public BossCombat combat;

    private void Awake()
    {
        combat = GetComponentInParent<BossCombat>();
    }

    public void DoSwordAttack()
    {
        combat?.DoSwordAttack();
    }
}