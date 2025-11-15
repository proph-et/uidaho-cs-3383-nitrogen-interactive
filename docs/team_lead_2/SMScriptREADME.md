# SMScript.cs – Sound & Music Handler

## Overview
`SMScript` is the audio manager for the game.  
It handles:
- Background music  
- One-shot sound effects (dash, enemy defeat, pickups, etc.)  
- Centralized audio control so other scripts do not need their own AudioSources  

This script should be attached to a single GameObject in the scene (e.g., "AudioManager").

---

## How It Works

### 1. AudioSources Created in Awake()
Two AudioSources are automatically added:
- `bgSource` → loops background music  
- `sfxSource` → plays sound effects via `PlayOneShot()`  

This keeps the Inspector clean and avoids manual setup.

### 2. Background Music
The background track is started in `Start()`:

```csharp
bgSource.clip = background_clip;
bgSource.Play();
