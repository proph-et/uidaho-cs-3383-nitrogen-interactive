# Pause Menu  
★★★★★ (4921 reviews)  
Author: *Your Name*  

**$0.99**  
**Version:** 1.1  

---

## Description  
This prefab provides a complete Pause Menu system for Unity. It includes pause/resume functionality, an options submenu, and built-in scene navigation. The system uses Unity’s `Time.timeScale` to freeze and resume gameplay and is designed for easy expansion.

---

## Components

### **PauseMenu Script**
Controls core pause behavior:

- Toggles pause with **Escape**  
- Shows/hides the Pause Menu UI  
- Freezes/unfreezes game time  
- Loads the Main Menu scene  
- Uses a simple State Pattern (Playing ↔ Paused)

Attach this script to the Pause Menu parent object.  
Assign `PauseMenuCanvas` and any additional UI elements in the Inspector.

---

### **PauseMenuCanvas (Canvas)**  
The main pause UI screen.

- Includes **Resume**, **Options**, **Main Menu**, and **Quit** buttons  
- Automatically enabled/disabled by the PauseMenu script  
- Fully customizable to fit your game's UI theme  

---

### **OptionsMenuCanvas (Canvas)**  
A secondary UI panel for adjustable settings or future features.

Includes:

- A **Back** button  
- Extra space for adding new options (audio sliders, keybinds, video settings, etc.)  

This canvas is activated/deactivated through the MenuManager to keep UI navigation organized and expandable.

---

### **MenuManager (GameObject)**  
A central controller object responsible for coordinating:

- Pause Menu Canvas  
- Options Menu Canvas  
- Any additional menu screens you add later

This object holds the scripts that handle transitions and menu navigation to keep logic clean and separated from gameplay scripts.

---

### **Unity Buttons (Commands)**  
Each UI button calls a command-like function:

- **Resume** → `Play()`  
- **Pause** (optional) → `Stop()`  
- **Options** → Show `OptionsMenuCanvas`  
- **Back** → Return to `PauseMenuCanvas`  
- **Main Menu** → `MainMenuButton()`  

The Command Pattern keeps UI elements simple by letting scripts handle the logic.

---

## Setup Instructions

1. Drag the **Pause Menu Prefab** into your scene.  
2. Assign both `PauseMenuCanvas` and `OptionsMenuCanvas` to the PauseMenu and MenuManager scripts.  
3. Connect button OnClick events to:
   - `Play()`  
   - `Stop()`  
   - `MainMenuButton()`  
   - MenuManager navigation functions  
4. Ensure `PauseMenuCanvas` is disabled by default.  
5. Test in Play Mode:
   - Press **Escape** to pause  
   - Open and close the Options Menu  
   - Resume the game and confirm it behaves normally  

---

## Requirements  
Unity **6000.2.6f2** or later.

---
