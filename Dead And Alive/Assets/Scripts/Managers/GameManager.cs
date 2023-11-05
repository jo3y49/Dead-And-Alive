using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public PlayerBattle player;
    private GameData gameData;
    private PlayerData playerData = new();
    private WorldState worldState = new();

    public void SetGameData(GameData gameData)
    {
        this.gameData = gameData;
        playerData = gameData.playerData;
        worldState = gameData.worldState;
    }

    public void SetPlayerExperience(int experience)
    {
        playerData.experience = experience;
    }

    public void SetPlayerLevel(int level)
    {
        playerData.level = level;
    }

    public int GetPlayerLevel()
    {
        return playerData.level;
    }
        

    public void SetCurrentScene(int currentScene)
    {
        worldState.currentScene = currentScene;
    }

    public GameData GetGameData()
    {
        gameData = new GameData{playerData = playerData, worldState = worldState};
        return gameData;
    }

    public void SetPlayer(GameObject player)
    {
        this.player = player.GetComponent<PlayerBattle>();
        this.player.SetData(playerData.level, playerData.experience);
        this.player.ResetHealth();
    }

    private void Awake() {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}