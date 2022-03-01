# BloonTowerMaker alpha v0.1
> Note: This is an alpha release so bugs may be present
<a href="url"><img src="https://user-images.githubusercontent.com/31301575/156167513-b932669a-c674-473e-bbe6-46a7df10ca37.png" align="right" width="200px"></a>  
# Startup
<a href="url"><img src="https://user-images.githubusercontent.com/31301575/156145828-97e0fcec-1392-4fd8-9651-c2cf62224b20.png" width="200px"></a>  
- ```Author``` name will be included in the metadata.
- ```Tower Name ``` The name of the file and genetated .dll. Should not contain any reserved c# keywords.
- ```Version``` Tower version in the tower metadata.
- ```Project Location``` - Specifiy where the project files should be.

# Main window
<a href="url"><img src="https://user-images.githubusercontent.com/31301575/156149188-b01651d8-2d2c-44e9-bb34-62274206d421.png" width="400px"></a>

### File
- ```New``` Open new Startup window
- ```Load``` Load project from folder
- ```Save``` Saves project settings (does nothing)
- ```Recent``` _not implemented_

### Paths
- ```Top, Middle, Botttom``` Enables the path upgrade up to the selected index and saves the value inside the base path settings.
### Path selection
- Click any path upgrade to start editing, see [Path Editor](https://github.com/millefoleon/BloonTowerMaker/new/master?readme=1#path-editor-window). ***Paragon path not supported yet***
### Projectile Editor
- See [Projectile Editor](https://github.com/millefoleon/BloonTowerMaker/new/master?readme=1#projectile-editor-window)
### Debug Textures
- Enabling this and generating the file will result in the *Upgrade Path* to extract the texture file for the specified *Path model* in path editor window upon mod launch.
- Extracted textures path: ```C:\Users\*username*\AppData\LocalLow\Ninja Kiwi\BloonsTD6```
### Generate
- Generate the .dll. Any compile errors will be prompted in a message.
### Other
- ```Base``` base in-game tower to copy
- ```Type``` Tower category

# Path Editor Window
<a href="url"><img src="https://user-images.githubusercontent.com/31301575/156157964-54a97898-e548-4b1e-a492-3ab1a100f1f7.png" width="400px"></a>   
>Editing the base path is slightly different from the other paths, but mostly the same  

***Required Fields in Path Property: (failing to assign these values will result in compilation error)***
- Base path
  - ```DisplayName, TopPathUpgrades,MiddlePathUpgrades,BottonPathUpgrades, Cost, Description, TowerSet, BaseTower```, where ```TopPathUpgrades,MiddlePathUpgrades,BottonPathUpgrades, TowerSet, BaseTower``` will be automatically assigned.
- Upgrade Path
  -  ```DisplayName, Cost, Description, Path, Tier```, where ```Path, Tier``` will be automatically assigned

> Click the knowledge button for information about input per variable type!

#### Models
- You can read about some of the models [here](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/Making-a-Custom-Tower).
- ***Changing values in ```Damage, Attack, Weapon``` models will override all the values of all projectiles assigned***

#### Projectile Select
- Selecting a projectile from the list will override any projectile assigned to the tower from the previous paths.
  - Not selecting any projectile will keep projectiles on the tower for the previous paths

### Textures, Icons and Portraits
> using large .png files might not apply correctly or not at all!
- Click the relevant image to assign a ```.png``` to it
- The image name will be saved in the relevant ```Path Property``` field
- Selected image will be copied to the project path, into the ```/resources``` folder
- Right Click to remove the image. _Note: It wont delete it from the ```/resources``` folder_

### Tower 3D model
- Select the tower and a path to assign the relevant 3D model to the upgrade path
  - For hero 3D models use 0,0,0 path
  - Any invalid path (like 5,3,0) might result in an error at mod run-time.
- Get the texture for the path using [Debug Textures](https://github.com/millefoleon/BloonTowerMaker/#debug-textures)

# Projectile Editor Window
<a href="url"><img src="https://user-images.githubusercontent.com/31301575/156161607-9007bb2a-b90e-4151-9d64-1e62a00cb011.png" width="400px"></a>  

### Projectile List
- Create new projectile using the `New` button
- Remove projectile using the `Delete` button
- Selected projectile will bring up its sprite and properties
- Rename a projectile by changing the value of `name` inside the `Projectile Model` table
  - _A name should be assigned automatically, if you dont see it, click on the projectile name inside the list to refresh the tables_)

### Projectile Sprite
- Sprite selection works much like [In the path editor](https://github.com/millefoleon/BloonTowerMaker#textures-icons-and-portraits)

### Models
- I cant guarantee you that every field will work for the projectile, but the `Damage` and `pierce` work fine. You are free to experiment

# Features not supported by the tool
- Behaviours and Filters (no camo detection, abilities or damage type)
- Damage by tag (no extra damage to ceramic or moabs)
- Rig bone removal (remove projectiles from monkeys hands)
- Custom 3D models
- 2D Tower textures
- 3D projectiles
> Note: All these features and more are planned for future releases

# Credits
### Special Credit to
- @gurrenm3 for the Mod Helper
- @doombubbles for the card monkey  
  You were a great inspiration for the project and it couldn't exist without you 

# A message to other developers
The project was made in two weeks in a time-off between semesters. I changed the code base 4 times in a rush to get the alpha version done until the semester begins -
all while trying to learn C#, Mod helper and analyzing mods of other people.
If you have any ideas on how to improve the project please DM me in discord `neol#6987`.
p.s I recently discovered that Mod helper supports json serialization for some objects. Should have read the documentation better ;-P
