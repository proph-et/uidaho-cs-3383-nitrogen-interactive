# Ability.cs – Base Ability Class

## Overview
`Ability` is the abstract base class used to implement all player abilities in the game.  
It defines the common interface that all abilities must follow and provides a default implementation of the `Activate()` method.

Any new ability (dash, attack, heal, block, etc.) must inherit from `Ability`.

---

## Purpose
The goal of this class is to support **polymorphism** — allowing different ability types to be stored and called through a single interface.

Example:
```csharp
Ability a = new DashAbility(...);
a.Activate(gameObject);   // Calls DashAbility.Activate()

a = new AttackAbility(...);
a.Activate(gameObject);   // Calls AttackAbility.Activate()
