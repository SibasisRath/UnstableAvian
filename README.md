# UnstableAvian
Mat 2 game jam project <br>
Game jam theme: Do No Harm

<p>
Story:<br>
There is a bird in a jungle. It has a unique power which is, it can create explosion arround itself. But there is an issue. It has not learnt how to control the size or timing of the explosion. So whenever it feels like it is going to explode. It starts flying. While flying it has 3 purpose. First to avoid trees, second collect a special type of food which helps to do high jumps in air and third to jump befor explosion.
</p>

<p>
Describing features:

<p>
Player setup: <br>
  Player control: Up, down, left and right arrow keys or wasd keys for movement. Space for jump.
  Camera will follow player from behind. (player will not move foreward. it is actually the track will come to the player.)

  ![Screenshot (11)](https://github.com/SibasisRath/UnstableAvian/assets/57254317/1923d83d-f557-4ecf-b979-891a9071fb09)

</p>

<p>
Player Explosion: <br>
  There are three types of explosion. Small, medium, big. Each have different range.
  Now explosion will happen at a gap (It could be randomize). Now Here is the design of the explosion system.
  
  Small explosion has a range if the forest environment is in that range it will cause some destruction.
  Medium Explosion has 2 range one is inner range and outter range. if environment in present in inner range it will cause more damage and of it is at the outter range it will cause less damage.
  Same with the big explosion. If the player is able to jump higher enough and the forest environment is out range of explosions no damage will cause. 

  Before explosion there will be a waring of what type of explosion will happen and a countdown will be given.
  Player jump ability will be activated after the waring and the jump ability will be activated during that time.
  How high the player can jump depends on how many air boost fruit it has consumed.

  ![Screenshot (12)](https://github.com/SibasisRath/UnstableAvian/assets/57254317/c2ae149c-77d4-4940-9d2c-6be26e624148)

</p>

<p>
Environment:<br>
  Because the player is not moving forward so just below the player the environment game object is present.
  Behind the player there is a destroy zone.
  Tracks are also part of the environment.
  So at the begining there will be some default track. After one of those track reahched to destroy zone the track will be destroyed and it will send a trigger to generate new track.
  All the track has a script that helps them to move towards the player.

  Theme based track system is done. Here I have taken 2 different types of track theme. More theme based tracks can be added and it will iterate and genarate those in the game.

</p>

<p>
Looby: <br>
  Lobby is present. It is basically a combination of main menu, difficulty level selector.
  There are 3 different types of difficulty level. Easy, Normal, Hard.
  Easy mode will be unlocked by default.
  If you are playing it for the first time then you need to complete the easy level to go to normal and then hard level.

</p>

<p>
Score System:<br>
  Here the score system is time and difficulty mode based.
  It means the longer you play the more score you will get and it will be multiply by a score multiplyer which varies for different dificulty mode.
  It will be stopped during pause.

</p>
<p>
Lives and deaths:<br>
  Player has 3 lives, after which the game will be over.
  After each death the player collider will be turned off for a bit of time.
</p>
<p>
AirBoost:<br>
  In the game I have add a kind of fruit that helps to perform higher jumps in air.
  This is require for the player to consume as much as posible to jump high during the explosions.

</p>
<p>
Forest Destruction management:<br>
  The bird is flying in forest and if it explodes then it will destroy the forest.
  So there is a limit to which destruction can be done. If the limit is crossed then game over.
  To avoid destruction player need to collect air fruits and press jump key in the waring time.
</p>
<p>
Game Play UI:<br>
  The game can be paused, resume, over, restart.
</p>
<p>
Polish:<br>
  The game has been play tested and tuned.
</p>
</p>



https://github.com/SibasisRath/UnstableAvian/assets/57254317/113ff461-2afb-4fef-9bf5-23df34a9a316


