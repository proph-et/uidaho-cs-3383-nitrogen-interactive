# AttackAbility.cs – Player Melee Attack Ability

## Overview
`AttackAbility` is a concrete implementation of the `Ability` base class.  
It controls all gameplay logic related to the player’s melee attack, including:

- Triggering attack animations  
- Detecting enemies in front of the player  
- Applying damage using a SphereCast  
- Enforcing attack cooldown timing  
- Preventing attack spamming  

This class encapsulates all combat logic, keeping the PlayerController clean and modular.

---

## Purpose
The goal of `AttackAbility` is to decouple attack behavior from PlayerController and allow attacks to function as a standalone ability module.

It also demonstrates polymorphism:

```csharp
Ability attack = new AttackAbility(...);
attack.Activate(gameObject);  
