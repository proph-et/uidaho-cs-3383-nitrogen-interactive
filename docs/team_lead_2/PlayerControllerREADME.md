# PlayerCharacter Prefab – README

## 1. Overview
The **PlayerCharacter** prefab represents the main controllable character in the game.  
It includes the Mixamo character model, its animation rig, and all required Unity components and scripts needed for:

- Movement  
- Dash ability  
- Attack ability  
- Health/damage  
- Animation handling  
- Physics and collision  

This documentation explains the structure of the prefab, the purpose of each component, and how other team members can safely modify or extend the player.

---

## 2. Purpose of This Prefab
This prefab serves as the **single source of truth** for the player’s in-game behavior.

It contains:

- The visual character model (Mixamo rig)  
- The Animator and animation states  
- PlayerController script  
- Health script  
- Rigidbody and colliders  
- Ability initialization (DashAbility, AttackAbility)  

Any scene that needs a player should use *this prefab*, not a copy.

---


## 3. Required Components

### PlayerController.cs
Handles:
- movement  
- tilt input  
- ability activation  
- respawn logic  
- animation triggers  
- invincibility toggling  

### Rigidbody
Required for:
- dash force  
- collision  
- gravity  

Recommended settings:
- Use Gravity = true  
- Freeze Rotation X/Z = true  

### CapsuleCollider
Defines the physical shape for hit detection.

### Animator
Uses parameters:
- `isRunning`  
- `isAttacking`  
- `isDashing`  

### Health.cs
Handles:
- hit points  
- taking damage  
- death → respawn logic  

---

## 4. Abilities Used by This Prefab

### DashAbility
- applies dash force  
- triggers i-frames  
- plays dash animation  
- uses internal cooldown  

### AttackAbility
- triggers attack animation  
- performs hit detection  
- applies damage  
- uses internal cooldown  

Both abilities inherit from:

```csharp
public abstract class Ability
{
    public virtual void Activate(GameObject user) { }
}

