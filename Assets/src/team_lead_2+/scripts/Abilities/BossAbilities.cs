using System;
using UnityEngine;

public class BossAbilities : MonoBehaviour 
{
    public MoveAbility Move { get; private set; }
    public SwordAttackAbility Attack { get; private set; }

    // later add more Abilities right here

    private BossLevel boss;

    public void Init(BossLevel owner)
    {
        boss = owner;

        Move = new MoveAbility();
        Attack = new SwordAttackAbility();
        // Later add here the creation of the abilities:
    }
}
