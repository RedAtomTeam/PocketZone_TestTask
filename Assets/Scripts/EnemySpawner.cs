using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefs;

    [SerializeField] float areaYmax;
    [SerializeField] float areaYmin;
    [SerializeField] float areaXmax;
    [SerializeField] float areaXmin;

    [SerializeField] int enemyCountAtStart;

    public void FirstSpawn()
    {
        for (int i = 0; i < enemyCountAtStart; i++)
        {
            SpawnEnemy(enemyPrefs);
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        var enemyObj = Instantiate(enemy);
        enemyObj.transform.position = new Vector2(
            UnityEngine.Random.Range(areaXmin, areaXmax),
            UnityEngine.Random.Range(areaYmin, areaYmax)
            );
    }
}
