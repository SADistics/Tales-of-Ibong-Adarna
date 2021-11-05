using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnManager : MonoBehaviour
{
    public Transform spawns;
    public GameObject[] enemyPrefab;
    public Transform[] waypoints;
    public EnemyCount enemyCount;

    System.Random rand;

    int randEnemyPref;
    void Start()
    {
        rand = new System.Random();
        randEnemyPref = rand.Next(enemyPrefab.Length);
        randEnemyPref = rand.Next(enemyPrefab.Length);
        
        spawns = this.gameObject.transform;
        SpawnNewEnemy();
        enemyCount = GameObject.Find("EnemyManager").GetComponent<EnemyCount>();
        enemyCount.enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemyCount.enemyCountText.text = enemyCount.enemyCount.ToString();
    }

    void SpawnNewEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab[randEnemyPref], spawns.transform.position, Quaternion.identity);
        enemy.GetComponent<Pathfinding.AIDestinationSetter>().moveSpots = new Transform[waypoints.Length];
        for (int j = 0; j < waypoints.Length; j++)
        {
            enemy.GetComponent<Pathfinding.AIDestinationSetter>().moveSpots[j] = waypoints[j];
            randEnemyPref = rand.Next(enemyPrefab.Length);
        }
    }
}
