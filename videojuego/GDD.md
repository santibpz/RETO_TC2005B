# **Wild Frontier: The Rescue**

## _Game Design Document_

---

##### **Copyright notice / author information / boring legal stuff nobody likes**

##

## _Index_

---

1. [Index](#index)
2. [Game Design](#game-design)
   1. [Summary](#summary)
   2. [Gameplay](#gameplay)
   3. [Mindset](#mindset)
3. [Technical](#technical)
   1. [Screens](#screens)
   2. [Controls](#controls)
   3. [Mechanics](#mechanics)
4. [Level Design](#level-design)
   1. [Themes](#themes)
      1. Ambience
      2. Objects
         1. Ambient
         2. Interactive
      3. Challenges
   2. [Game Flow](#game-flow)
5. [Development](#development)
   1. [Abstract Classes](#abstract-classes--components)
   2. [Derived Classes](#derived-classes--component-compositions)
6. [Graphics](#graphics)
   1. [Style Attributes](#style-attributes)
   2. [Graphics Needed](#graphics-needed)
7. [Sounds/Music](#soundsmusic)
   1. [Style Attributes](#style-attributes-1)
   2. [Sounds Needed](#sounds-needed)
   3. [Music Needed](#music-needed)
8. [Schedule](#schedule)

## _Game Design_

---

### **Summary**

The game follows the story of a hunter-gatherer named Kael, who lives in a small tribe of nomads in the pre-civilization world. In this world, tribes are identified with an animal and kael´s tribe is recognized as the wolf tribe. Kael's tribe is in dispute with other tribes over the grasslands in prehistoric Europe and his life takes a dramatic turn when his young son is kidnapped by the leader of the Bear tribe in revenge for the disagreement of a treaty among tribes.

Determined to rescue his son, Kael sets out on a perilous journey through the forbidden forest, the Sarcos Lake and the settlement of the Bear tribe, where he must fight against the Bear tribesmen along with his tribe´s emblematic animal, the wolf, who will help him determine the path to follow in order to find his son. As Kael goes through this journey, he ensures the protection of the wolf long enough for it to determine which way to go. To fight off enemies, Kael gathers resources from the environment to craft his own weapons.

Kael finally reaches the settlement of the Bear tribe, where he engages in a fierce battle with the most menacing tribesmen and the leader of the tribe. Using all of his skills and weapons to overcome the powerful tribe, Kael will try to rescue his son.

Wild Frontier: The Rescue will be a 2D action Role Playing Game with real-time combat system. It will be based on pixel art videogames with a top down view. Players can expect a thrilling and immersive RPG experience with a focus on action. As the designers of this game, we want the innovation of this product to lie in providing the player with a feeling of responsibility towards the companion of the player (the wolf) throughout the game. This is embedded as much as possible into the game to the degree where the player needs to apply the best strategy to ensure the protection of the wolf in order to move on to the next levels.

### **Gameplay**

The game is set in a pre-civilization world and the player takes on the role of the main character Kael as he goes through different levels where he has to scavenge for resources such as materials for crafting weapons to kill the enemies and depend on his tribe´s animal, the wolf, to track his son down.

The player starts the game in the forbidden forest where he can explore the world and learn to craft his first weapons by interacting with the environment. The main character has an initial tool, the hand axe, which can be used to chop down trees or work the stone rocks to craft different weapons. The weapons that can be crafted are bows and arrows, slings, atlatls, spears, clubs, stone knives and blades and each of them require different resources/materials that the player needs to collect from the environment.

The weapons have different stats that describe a characteristic about the weapon, such as the amount of damage the weapon inflicts when it hits an enemy (damage), the speed with which the weapon can execute an attack (speed) and the resistance of the weapon against wear and tear (durability).

The goal of the game is to rescue the son from the leader of the Bear Tribe. In order to do this, the player must decide to craft the best weapons to fight off enemies and protect the wolf long enough for it to determine which way his son was taken. The player is able to run, jump, attack in different ways depending on the weapon being used and use a special ability which will allow the player to select between 2 choices; either choose to use the wolf to cause significant damage to the enemies or choose to restore a percentage of his health bar. This special ability will be represented as a bar in the game that will be filling up as the player kills enemies. Once the bar is full, he can make the appropriate choice.

The player will start with a full health bar and whenever the player takes damage from an enemy attack, an amount of the health will be deducted depending on the strength of the enemy attack.
Throughout the game, the player can customize the main character by deciding the weapons which will be used at a certain moment to attack enemies. The player is able to craft the weapons mentioned above but it is only allowed to carry 2 weapons at once. Therefore, the player can select only 2 weapons from the inventory, and can change his current weapons when Kael gets to one of several checkpoints present throughout the map. Everytime the player gets out of the checkpoint, all defeated enemies in previous levels will revive, this in case the player wants to get back to those levels.

In the beginning of the game, the player starts off with a fairly weak and poorly equipped character. As the player goes through the different levels, he can accumulate experience points (XP), by killing enemies, that he can use to increase the stats of the weapons that he crafts. The experience points enable the player to level up and be stronger during battle in each level.

As the player progresses through the game, he will encounter more challenging enemies, requiring him to use different strategies and weapons to defeat them. Enemies are of three types and have different resistance and vulnerability levels to the main character´s weapons. Grims are short range attacking enemies that move fast and are resistant to clubs and stone blades but vulnerable to thrown arrows. On the other hand, Shielders are armored enemies that move slow but are resistant to short range attacking weapons such as stone knives and blades, but vulnerable to spears, clubs and arrows. Finally, Marauders are long range attacking enemies that throw arrows at the enemy. This enemy is resistant to arrows and slings and vulnerable to the wolf attack combo.

### **Mindset**

As the game designers of this game we would want to provoke a sense of adventure and excitement in the player. The game is set in a pre-civilization world with different types of enemies that require different strategies and weapons to defeat. This encourages the player to explore the environment, scavenge for resources, and craft weapons to progress through the game.

At the same time, the limited carry capacity of weapons and cooldown effect on weapon selection (inventory) is made to provoke a sense of urgency and tension in the player, requiring them to carefully plan their weapon choices and use them strategically against different enemies. This can also make the player feel vulnerable at times, as they may encounter enemies for which they are not well-prepared.

However, the presence of the wolf companion and the ability to choose between the powerful "wolf attack" or healing can also make the player feel empowered and in control, especially as they progress through the game and become more skilled at using the different weapons that the craft.

Overall, we would want to create a balance between adventure and tension in the player, while also allowing the player to feel a sense of progression as they go through the levels and advance towards the goal of rescuing the son.

## _Technical_

---

### **Screens**

1. Title Screen
   1. Options
2. Level Select
3. Game
   1. Inventory
   2. Assessment / Next Level
4. End Credits

_(example)_

### **Controls**

How will the player interact with the game? Will they be able to choose the controls? What kind of in-game events are they going to be able to trigger, and how? (e.g. pressing buttons, opening doors, etc.)

### **Mechanics**

Are there any interesting mechanics? If so, how are you going to accomplish them? Physics, algorithms, etc.

## _Level Design_

---

_(Note : These sections can safely be skipped if they&#39;re not relevant, or you&#39;d rather go about it another way. For most games, at least one of them should be useful. But I&#39;ll understand if you don&#39;t want to use them. It&#39;ll only hurt my feelings a little bit.)_

### **Themes**

1. Forest
   1. Mood
      1. Dark, calm, foreboding
   2. Objects
      1. _Ambient_
         1. Fireflies
         2. Beams of moonlight
         3. Tall grass
      2. _Interactive_
         1. Wolves
         2. Goblins
         3. Rocks
2. Castle
   1. Mood
      1. Dangerous, tense, active
   2. Objects
      1. _Ambient_
         1. Rodents
         2. Torches
         3. Suits of armor
      2. _Interactive_
         1. Guards
         2. Giant rats
         3. Chests

_(example)_

### **Game Flow**

1. Player starts in forest
2. Pond to the left, must move right
3. To the right is a hill, player jumps to traverse it (&quot;jump&quot; taught)
4. Player encounters castle - door&#39;s shut and locked
5. There&#39;s a window within jump height, and a rock on the ground
6. Player picks up rock and throws at glass (&quot;throw&quot; taught)
7. … etc.

_(example)_

## _Development_

---

### **Abstract Classes / Components**

1. BasePhysics
   1. BasePlayer
   2. BaseEnemy
   3. BaseObject
2. BaseObstacle
3. BaseInteractable

_(example)_

### **Derived Classes / Component Compositions**

1. BasePlayer
   1. PlayerMain
   2. PlayerUnlockable
2. BaseEnemy
   1. EnemyWolf
   2. EnemyGoblin
   3. EnemyGuard (may drop key)
   4. EnemyGiantRat
   5. EnemyPrisoner
3. BaseObject
   1. ObjectRock (pick-up-able, throwable)
   2. ObjectChest (pick-up-able, throwable, spits gold coins with key)
   3. ObjectGoldCoin (cha-ching!)
   4. ObjectKey (pick-up-able, throwable)
4. BaseObstacle
   1. ObstacleWindow (destroyed with rock)
   2. ObstacleWall
   3. ObstacleGate (watches to see if certain buttons are pressed)
5. BaseInteractable
   1. InteractableButton

_(example)_

## _Graphics_

---

### **Style Attributes**

What kinds of colors will you be using? Do you have a limited palette to work with? A post-processed HSV map/image? Consistency is key for immersion.

What kind of graphic style are you going for? Cartoony? Pixel-y? Cute? How, specifically? Solid, thick outlines with flat hues? Non-black outlines with limited tints/shades? Emphasize smooth curvatures over sharp angles? Describe a set of general rules depicting your style here.

Well-designed feedback, both good (e.g. leveling up) and bad (e.g. being hit), are great for teaching the player how to play through trial and error, instead of scripting a lengthy tutorial. What kind of visual feedback are you going to use to let the player know they&#39;re interacting with something? That they \*can\* interact with something?

### **Graphics Needed**

1. Characters
   1. Human-like
      1. Goblin (idle, walking, throwing)
      2. Guard (idle, walking, stabbing)
      3. Prisoner (walking, running)
   2. Other
      1. Wolf (idle, walking, running)
      2. Giant Rat (idle, scurrying)
2. Blocks
   1. Dirt
   2. Dirt/Grass
   3. Stone Block
   4. Stone Bricks
   5. Tiled Floor
   6. Weathered Stone Block
   7. Weathered Stone Bricks
3. Ambient
   1. Tall Grass
   2. Rodent (idle, scurrying)
   3. Torch
   4. Armored Suit
   5. Chains (matching Weathered Stone Bricks)
   6. Blood stains (matching Weathered Stone Bricks)
4. Other
   1. Chest
   2. Door (matching Stone Bricks)
   3. Gate
   4. Button (matching Weathered Stone Bricks)

_(example)_

## _Sounds/Music_

---

### **Style Attributes**

Again, consistency is key. Define that consistency here. What kind of instruments do you want to use in your music? Any particular tempo, key? Influences, genre? Mood?

Stylistically, what kind of sound effects are you looking for? Do you want to exaggerate actions with lengthy, cartoony sounds (e.g. mario&#39;s jump), or use just enough to let the player know something happened (e.g. mega man&#39;s landing)? Going for realism? You can use the music style as a bit of a reference too.

Remember, auditory feedback should stand out from the music and other sound effects so the player hears it well. Volume, panning, and frequency/pitch are all important aspects to consider in both music _and_ sounds - so plan accordingly!

### **Sounds Needed**

1. Effects
   1. Soft Footsteps (walk)
   2. Sharper Footsteps (run)
   3. Enemy hit
   4. Player hit
   5. Strong hit
   6. Ax blow to tree(cut down trees)
   7. Beak sound(chopped rock)
   8. Bow shot sound
   9. "Glup" sound of healing
   10. Unlock sound
   11. Upgrade sound
2. Feedback
   1. Error (The player cannot build due to lack of materials)
   2. Construction sound (The player builds the weapon)
   3. Game over sound (died)
reference sounds:

### **Music Needed**

1. Slow-paced, serene-racking &quot;forest&quot; track
2. Nerve-racking &quot;cave&quot; track 
3. Exciting &quot;Battle&quot; track
4. Quick, exciting &quot;Low health Battle&quot; track
5. Tribal Theme &quot;Menu&quot; track
6. Sad &quot;Game over screen&quot; track
7. &quot;Boss&quot; track
8. Happy &quot;ending credits&quot; track

reference music: https://drive.google.com/drive/u/1/folders/1fUL38Bz-ihXMLKg2w7TnoDE3HXy9D8o_

## _Schedule_

---

_(define the main activities and the expected dates when they should be finished. This is only a reference, and can change as the project is developed)_

1. develop base classes
   1. base entity
      1. base player
      2. base enemy
      3. base block
2. base app state
   1. game world
   2. menu world
3. develop player and basic block classes
   1. physics / collisions
4. find some smooth controls/physics
5. develop other derived classes
   1. blocks
      1. moving
      2. falling
      3. breaking
      4. cloud
   2. enemies
      1. soldier
      2. rat
      3. etc.
6. design levels
   1. introduce motion/jumping
   2. introduce throwing
   3. mind the pacing, let the player play between lessons
7. design sounds
8. design music

_(example)_
