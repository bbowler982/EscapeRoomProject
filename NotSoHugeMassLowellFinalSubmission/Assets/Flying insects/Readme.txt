If you want to move around in the scene, you will need to add an FPS controller.  You can you use the one included in the standard assets.
In the Unity editor, go to Assets < Import Package < Characters, and import all the assets.
In the project window, go to Assets < Standard Assets < Characters < FirstPersonCharacter < Prefabs , and coose the FPSController and add it to the scenea at 0,0,0.
If you want to add a texture to the terrain, you import the Environment assets (Assets < Import Package < Environment), click on 'terrain' in the heirarchy,
click the paint texture icon in the inspector, click 'edit textures', then 'add texture', and choose a texture from the list.

Scripts
The package includes a spawner script and a flight script.  
Create an empty game object, and place it where you want the insects to spawn.
Add the 'Spawner' script to the game object, and drag and drop the chosen insect prefab into the 'Insects prefab' slot.
By default, 5 instances are spawned - you can change this within the script.
To increase or decrease the insects' range, change the 'insectRange' value in the 'Spawner' script.
Add a value to the Max Height slot (this will determine the maximum height the insects can reach).
The prefabs already have the 'Flight' script attached (if you are using other models, they will need the 'Flight' script) - play around with the various values until you are satisfied.
