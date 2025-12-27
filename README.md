# Game-Programming-Prototype-2025

## Main Concept
You are a spaceship that is atttacking enemy fighters. Your objective is to eliminate as many enemies as possible to get the highest score. If you fail, you can restart. Upon killing enough enemies, the level will transition to a new camera position.

## Player
The player is controlled using the "WASD" keys that function using GetAxisRaw(). Depending on the camera position the player will move on different axis, such as X & Y when the camera is Side-On and X & Z when Top-Down. Using the "E" key, the player can fire a bullet that travels in a straight line to the right. There is an invisible box around the player so that they can only move within the boundaries of the screen and close to the middle of the screen. If the player is hit by an enemy bullet, they will lose a life. If they lose all 3 of their lives, the player will be destroyed and a "Restart" button will appear.

## Enemies
The enemies spawner on a random interval timer and there spawn position is based on where the moving spawner on the right hand side of the screen is. They will move in a straight line to the left until they hit an invisible wall and stop. The enemies will be firing bullets on a random interval aswell, and these too will travel in a straight line. If an enemy is hit by the players bullets, the enemy and bullet will be destroyed and the players score will go up by 10.

## Camera
The camera starts of in the Side-On position, with the player on the left and enemies on the right. Once 5 enemies have been killed, the camera will switch to a Top-Down view, where the player will be positioned on the bottom and eneimes on the top of the screen. After another 5 enemies it will revert back to Side-On and continue switching in this pattern until the player loses. The camera moves inside of a coroutine that uses Slerp and LinearDamp to set the position and rotation of the camera itself, along with the position of the player to be in the center of the new viewpoint.

## Design
There is no end goal for the player other than trying to achieve a high score. The game only ends when the player loses all of their lives. When the level transitions to the other viewpoint, the enemies that were on screen get destroyed so that they dont clutter the screen. It also stops the player getting confused as to what enemies they can hit, as the change in perspectives makes some enemies unhittable. 
