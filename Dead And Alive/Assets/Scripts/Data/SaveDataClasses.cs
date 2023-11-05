using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class PlayerData
{
    public int level = 1;
    public int experience = 0;
}

[System.Serializable]
public class WorldState
{
    public int currentScene = 1;
}

[System.Serializable]
public class SettingsData
{
    
}

[System.Serializable]
public class GameData
{
    public PlayerData playerData = new();
    public WorldState worldState = new();
    public SettingsData settingsData = new();

    public GameData NewGame()
    {
        playerData = new();
        worldState = new();

        return this;
    }
}