using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public Transform spawns;
    public GameObject[] enemyPrefab;
    public Transform[] waypoints;
    int randEnemyPref;
    void Start()
    {
        spawns = this.gameObject.transform;
        SpawnNewEnemy();
    }

    void SpawnNewEnemy()
    {
        System.Random rand = new System.Random();
        randEnemyPref = rand.Next(enemyPrefab.Length);
        GameObject enemy = Instantiate(enemyPrefab[randEnemyPref], spawns.transform.position, Quaternion.identity);
        enemy.GetComponent<Pathfinding.AIDestinationSetter>().moveSpots = new Transform[waypoints.Length];
        for (int j = 0; j < waypoints.Length; j++)
        {
            enemy.GetComponent<Pathfinding.AIDestinationSetter>().moveSpots[j] = waypoints[j];
            randEnemyPref = rand.Next(enemyPrefab.Length);
        }
    }
}
