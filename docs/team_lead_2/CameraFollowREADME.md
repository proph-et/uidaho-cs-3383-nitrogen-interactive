# CameraFollow.cs – Smooth Camera Tracking System

## Overview
`CameraFollow` is a lightweight script responsible for smoothly following the player character.  
It uses Unity’s `Vector3.SmoothDamp()` function to produce smooth, natural camera motion without jitter or snapping.

This script should be attached to the **main camera**.

---

## Purpose
The goal of this component is to:

- Keep the camera centered on the player  
- Smoothly interpolate camera movement rather than locking directly to the player position  
- Maintain a consistent offset (distance + height)  
- Automatically detect the player at runtime  

This keeps camera behavior predictable and prevents motion sickness or abrupt shifts.

---

## How It Works

### 1. **Target Detection**
On Start, the script automatically searches for:

```csharp
GameObject.FindWithTag("Player")
