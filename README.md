# L2-Unity

<p>This project aim is to create a basic playable demo of Lineage2 on Unity.</p>

This [video](https://www.youtube.com/watch?v=IEHY37bJ7nk) inspired me to start on this project.

<p>Preview of the current state of the project:</p>

![Preview](https://cdn.discordapp.com/attachments/584218502148259901/1180162232814940280/image.png?ex=65eb28ba&is=65d8b3ba&hm=9fb347f90e0969ded501640e36d58353dd8046d107e54147c7e0abee926446aa&)

![Preview2](https://cdn.discordapp.com/attachments/584218502148259901/1212439526278959145/image.png?ex=65f1d74d&is=65df624d&hm=b2cb83a301f76a94b164b1361ada939144734a3dadcbb94160bb64739f307c4f&)


## What are the expected features?

For now the aim is to create a basic demo, therefore only basic features will be available:
- Client-side Pathfinding ✅
- Click to move and WASD movements ✅
- Camera collision ✅
- Basic UI
    - Status window ✅
    - Chat window ✅
    - Target window ✅
    - Nameplates ✅
    - Skillbar
- Basic combat ✅
- Basic RPG features 
    - HP Loss and regen 🛠️ (Players can fight but still can't regen)
    - Exp gain on kills
    - Leveling
- Small range of models
    - 1 to 2 races for players ✅ (FDarkElf, FDwarf)
	- A few armor sets for each race
	- A few of weapons each type 🛠️ (Only 1Hand sword for now)
    - All Monsters of Talking island ✅
    - All NPCs of Talking island ✅
- Server/Client features (server project [here](https://gitlab.com/shnok/unity-mmo-server))
    - Player position/rotation sync ✅
    - Animation sync ✅
    - Chat ✅
    - Server Ghosting/Grid system ✅
    - NPCs ✅
    - Monsters ✅
    - Monsters AI with Pathfinding ✅
- Import Lineage2's world
    - Talking island region ✅
        - StaticMeshes ✅
        - Brushes ✅
        - Terrain ✅
        - DecoLayer ✅
- Day/Night cycle ✅
- Game sounds (FMOD project [here](https://gitlab.com/shnok/l2-unity/-/tree/main/l2-unity-fmod/))
    - Ambient sounds ✅
    - Step sounds (based on surface) ✅
	- Music ✅
    - UI sounds ✅
    - NPC sounds ✅

## How to run?

<p>Open the "Game" scene and drag&drop the 1x_1x scenes into your scene.</p>

![Import](https://cdn.discordapp.com/attachments/584218502148259901/1180168459104034877/image.png?ex=65eb2e87&is=65d8b987&hm=a869d1c373c75b9ff52b93ccddaf91ccf853af21dd5e948cce3d53217f0ca124&)

If you don't want to setup the [server](https://gitlab.com/shnok/unity-mmo-server) and just want to run in an empty map. Select the <b>Game</b> GameObject in the <b>Game</b> scene and tick the <i>"offline mode"</i> checkbox.

![offline](https://cdn.discordapp.com/attachments/584218502148259901/1182499680056250418/image.png?ex=65ea6f25&is=65d7fa25&hm=a87480c4915cbf9c2723cc2b4c32f1c39c42e3e511bb0503db3ff4a6e031c998&)



## Contributing

Pull requests are very welcome. For major changes, please open an issue first
to discuss what you would like to change.
