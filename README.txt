# Scaredy Cat

Scaredy Cat is a side-scrolling animated Unity 3D game. The Player controls a ghost and attempts to capture a cat (the Target). In order to catch the cat, the Player needs to speed up by consuming stars, and catch up to it while avoiding getting hurt by monsters and stopped by bridges, or falling into rivers.

## Unity Version

2022.3.22f1

## Files Specifications
### BackgroundScroller.cs 
This script scrolls the game's background in the left direction, creating a sense of motion for the Player and Target.

### Enemy.cs
This script is designed to manage the status of the cat, increment the game level should the Player captures the Target, and speeds up the game in the next level.

### FloorBed.cs and PathGenerator.cs
This script contains the ground's movement mechanics.

### GroundMonster.cs
This script designs the life cycle of Ground Monsters. It uses Animator.animator, StartCoroutine and Collider.CompareTag methods to make the Ground Monster react to the Player and specific elements of the game world.

### LevelManager.cs and ScoreManager.cs
These scripts generate the Level and Score counter texts dynamically.

### LoadMenuScene.cs and LoadPlayScene.cs
These scripts enable the Player to move across game scenes when they press a certain key.

### MonsterSpawner.cs and PowerUpSpawners.cs
These scripts enable the spawning of Ground Monsters and Power Ups randomly within the certain boundaries.

### Star.cs
This script designs the life cycle of Star as a power up that the Player can consume to speed up.

## Design Decisions

I used Unity because I wanted to have more creative control over the game's visual design. The free assets downloaded from Unity Asset Store (referenced below) come with animation, which I've adjusted to suit the game's flow.

## Next Steps
• Add a 'Pause the Game' feature
• Add a 'Life Damage' and 'Life Supply' feature to the Player
• Increase the variety of challenges that's in the Player's way to capturing the Target
• Add a High Scoreboard

### Assets
Music: UDIO
Cat: https://assetstore.unity.com/packages/3d/characters/animals/lowpoly-toon-cat-lite-66083
Ghost: https://assetstore.unity.com/packages/3d/characters/creatures/ghost-character-free-267003
Monsters: 
• https://assetstore.unity.com/packages/3d/characters/creatures/rpg-monster-partners-pbr-polyart-168251
• https://assetstore.unity.com/packages/3d/characters/creatures/rpg-monster-duo-pbr-polyart-157762
• https://assetstore.unity.com/packages/3d/characters/creatures/rpg-monster-buddy-pbr-polyart-253961
Power Ups: https://assetstore.unity.com/packages/3d/proto-pack-50444
Game Environment: https://assetstore.unity.com/packages/2d/environments/free-platform-game-assets-85838
