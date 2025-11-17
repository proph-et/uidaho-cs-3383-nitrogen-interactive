# Sauce_lava Prefab - ReadMe

## 1. Overview
The Sauce_lava prefab represents the Sauce or lava itself in the scene which there are 14 in total where if the player steps into it takes damage.
It is a picture of sauce which i used for the copyright argument and it includes some sripts and Unity components, it is needed for:

- damaging the player
- elevating your map
- map design 

This document will explain the structure and porpose of each component of the prefab

---

## 2. Purpose of This Prefab
This prefab is there to add Saucepits into the scene/map of any amount that deal damage to the player if he walks into the pit.

It contains:
  - Box Collider
  - Particle System
  - Light
  - SauceRoll script
  - SauceDamage script

It is not nessesary in every Scene/Map but you can add it to you map for a passive obstacle to deal damage or make the player walk into other traps that are not visible.

---

## 3.Required Components

### Box Collider
it defines the physical interation with the player when did he enter the pit how long did he stay

### Particle System
The paticle System adds some tiny dots of orange particle that elevate the look of the Sauce/lava pit when walking by

### Light
The Light adds some ambient to the scene what would lava be without glowing dangerously

### SauceRoll script
it Handles the infinite looping of the Sauce image around the tile, since lava that is just static would look kinde boring for the eye.
   -as input it takes the Rollspeed in which the image should loop

### SauceDamage script
The Sauce Damage script handles the actual dangerous part it applies the damage to the player if he enters the Sauce pit.
   - as input it takes the damage per second variable where you can set how much damage the player should take each sec..

## 4.Setup Instroctions
Make a pit somewhere in your sence where there is a bit lower then the ground surface and then into that hole drag the Sauce_lava prefab into the Scene and place it rigth into the pit. then configure the two scripts set how much damage the player should take from it per second and how fast your Sauce shoul flow/roll. if you want you also can adjust the box collider if your pit is very deep or the player should already take damage if he gets close to it.

## 5. Requirements 
Unity 6000.2.6f2

## 6. image author https://pngimg.com/image/85963