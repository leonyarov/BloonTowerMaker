# BloonTowerMaker alpha v0.1

## Startup
<a href="url"><img src="https://user-images.githubusercontent.com/31301575/156145828-97e0fcec-1392-4fd8-9651-c2cf62224b20.png" width="200px"></a>  
- ```Author``` name will be included in the metadata.
- ```Tower Name ``` The name of the file and genetated .dll. Should not contain any reserved c# keywords.
- ```Version``` Tower version that in the tower metadata.
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
_Editing the base path is slightly different from the other paths, but mostly the same_
***Required Fields in Path Property:***
- Base path
- - ```DisplayName, TopPathUpgrades,MiddlePathUpgrades,BottonPathUpgrades, Cost, Description, TowerSet, BaseTower```, Where ```TopPathUpgrades,MiddlePathUpgrades,BottonPathUpgrades, TowerSet, BaseTower``` will be automatically assigned.
- Upgrade Path
- -  ```DisplayName, Cost, Description, Path, Tier```, Where ```Path, Tier``` will be automatically assigned

> !Click the knowledge button for information about input per variable type!

#### Models
- You can read about some of the models [here](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/Making-a-Custom-Tower).
- ***Changing values in ```Damage, Attack, Weapon``` models will override all the values of all projectiles assigned***

#### Projectile Select
- Selecting a projectile from the list will override any projectile assigned to the tower from the previous paths.
- - Not selecting any projectile will keep them on the tower for the rest of the paths

### Textures, Icons and Portraits

# Projectile Editor Window