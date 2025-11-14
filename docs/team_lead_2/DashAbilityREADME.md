# DashAbility.cs – Player Dash Ability

## Overview
`DashAbility` is a concrete implementation of the `Ability` base class.  
It handles all gameplay logic related to the player's dash action, including:

- Applying movement force  
- Triggering dash animations  
- Enabling invincibility frames (i-frames)  
- Enforcing cooldowns  
- Managing dash duration  

It encapsulates all dash-related behavior so that the PlayerController stays clean and modular.

---

## Purpose
This class moves all dash-specific logic **out of PlayerController** and into its own ability module.  
This improves maintainability and supports **polymorphic ability handling**.

Example usage:

```csharp
dashAbility = new DashAbility(this, dashSpeed, dashDuration, dashCooldown);
dashAbility.Activate(gameObject);
