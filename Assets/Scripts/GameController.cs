using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private SaveLoadManager saveLoadManager;
    [SerializeField] private PlayerController player; 
    [SerializeField] private InventorySystem playerInventory;
    [SerializeField] private WeaponSystem playerWeapon;
    [SerializeField] private List<Enemy> enemies; 
    [SerializeField] private GameObject enemyPref; 

    private void Start()
    {
        saveLoadManager = GetComponent<SaveLoadManager>();
        LoadGame();
    }

    public void SaveGame()
    {
        Vector3 playerPosition = player.transform.position;
        int playerHealth = player.healthPoints;
        List<Item> inventoryItems = playerInventory.GetItems(); 
        Weapon? equippedWeapon = playerWeapon.targetWeapon; 

        PlayerData playerData = new PlayerData(playerPosition, playerHealth, inventoryItems, equippedWeapon);

        EnemyData[] enemyDataArray = new EnemyData[enemies.Count];

        foreach (var e in FindObjectsOfType(typeof(Enemy)))
        {
            if (e.GetComponent<Enemy>())
            {
                enemies.Add(e.GetComponent<Enemy>());
            }
        }

        for (int i = 0; i < enemies.Count; i++)
        {
            enemyDataArray[i] = new EnemyData(enemies[i].transform.position, enemies[i].healthPoints);
        }

        saveLoadManager.SaveGame(playerData, enemyDataArray);
    }

    private void LoadGame()
    {
        saveLoadManager.LoadGame(out PlayerData playerData, out EnemyData[] enemiesData);
        if (playerData != null)
        {
            player.transform.position = playerData.playerPosition;
            player.healthPoints = playerData.health;

            foreach (Item item in playerData.inventoryItems)
            {
                playerInventory.AddItem(item); 
            }

            playerWeapon.SetWeapon(playerData.equippedWeapon);

            if (enemiesData != null)
            {
                foreach (var enemy in enemiesData) 
                {
                    GameObject enemyObj = Instantiate(enemyPref);

                    enemyObj.transform.position = enemy.enemyPosition;  
                    enemyObj.GetComponent<Enemy>().healthPoints = enemy.health;
                }
            }
        }
        else
        {
            FindAnyObjectByType<EnemySpawner>().FirstSpawn();
        }
    }
}
