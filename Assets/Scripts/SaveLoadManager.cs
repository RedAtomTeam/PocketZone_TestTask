using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using System.IO;

public class SaveLoadManager : MonoBehaviour
{
    private string filePath;

    private void Awake()
    {
        filePath = Application.persistentDataPath + "/savedGame.json";
    }

    public void SaveGame(PlayerData playerData, EnemyData[] enemiesData)
    {
        GameData gameData = new GameData(playerData, enemiesData);
        string json = JsonUtility.ToJson(gameData, true);
        File.WriteAllText(filePath, json);
    }

    public void LoadGame(out PlayerData playerData, out EnemyData[] enemiesData)
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            GameData gameData = JsonUtility.FromJson<GameData>(json);
            playerData = gameData.playerData;
            enemiesData = gameData.enemyData;
        }
        else
        {
            playerData = null;
            enemiesData = null;
        }
    }
}

[System.Serializable]
public class PlayerData
{
    public Vector3 playerPosition;
    public int health;
    public List<Item> inventoryItems;
    public Weapon equippedWeapon;

    public PlayerData(Vector3 position, int health, List<Item> items, Weapon weapon)
    {
        playerPosition = position;
        this.health = health;
        inventoryItems = items;
        equippedWeapon = weapon;
    }
}

[System.Serializable]
public class EnemyData
{
    public Vector3 enemyPosition;
    public int health;

    public EnemyData(Vector3 position, int health)
    {
        enemyPosition = position;
        this.health = health;
    }
}

[System.Serializable]
public class InventoryItem
{
    public string itemName;

    public InventoryItem(string name)
    {
        itemName = name;
    }
}

[System.Serializable]
public class GameData
{
    public PlayerData playerData;
    public EnemyData[] enemyData;

    public GameData(PlayerData player, EnemyData[] enemies)
    {
        playerData = player;
        enemyData = enemies;
    }
}