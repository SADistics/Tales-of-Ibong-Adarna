using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;
using UnityEngine.UI;

public class EnemyHealthCheck : MonoBehaviour
{
    public GameObject enemyMain;

    private EnemyStats enemyStats;
    private Animator enemyAnim;
    public TextMesh hpBar;
    private float totalHealth;

    EnemySpawnManager esm;
    public EnemyCount enemyCount;
    public LevelSystem levelSystem;

    private void Start()
    {
        enemyAnim = enemyMain.GetComponentInChildren<Animator>();
        enemyStats = enemyMain.GetComponentInChildren<EnemyStats>();
        totalHealth = enemyStats.GetHealth();
        enemyCount = GameObject.Find("EnemyManager").GetComponent<EnemyCount>();
        levelSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<LevelSystem>();
    }
    void Update()
    {
        hpBar.text = "HP: " + enemyStats.GetHealth() + "/" + totalHealth;
        if (enemyStats.GetHealth() <= 0)
        {
            hpBar.text = "HP: " + 0 + "/" + totalHealth;
            enemyMain.GetComponent<AIPath>().canMove = false;
            enemyMain.GetComponent<StateManager>().enabled = false;
            StartCoroutine(DeathCo());
        }
    }

    private IEnumerator DeathCo()
    {
        enemyAnim.SetBool("isDead", true);
        yield return new WaitForSeconds(2);
        if (SideQuestChecker())
        {
            levelSystem.AddExperience(enemyStats.exp);
            GameObject.Destroy(enemyMain);
            enemyCount.DecreaseEnemy();
        }
        else
        {
            levelSystem.AddExperience(enemyStats.exp);
            GameObject.Destroy(enemyMain);
            enemyCount.DecreaseEnemy();
        }
        /* #region DEBUG
         levelSystem.AddExperience(enemyStats.exp);
         GameObject.Destroy(enemyMain);
         enemyCount.DecreaseEnemy();
         #endregion*/
    }

    private static bool SideQuestChecker()
    {
        if (GameObject.Find("SideQuestHolder").GetComponent<RandomSideQuest>().SlimeQuest)
        {
            GameObject.FindGameObjectWithTag("Side").GetComponent<QuestProgress>().Count += 1;
            return true;
        }
        else if (GameObject.Find("SideQuestHolder").GetComponent<RandomSideQuest>().GoblinQuest)
        {
            GameObject.FindGameObjectWithTag("Side").GetComponent<QuestProgress>().Count += 1;
            return true;
        }
        else if (GameObject.Find("SideQuestHolder").GetComponent<RandomSideQuest>().ZombieQuest)
        {
            GameObject.FindGameObjectWithTag("Side").GetComponent<QuestProgress>().Count += 1;
            return true;
        }
        else if (GameObject.Find("SideQuestHolder").GetComponent<RandomSideQuest>().GhostQuest)
        {
            GameObject.FindGameObjectWithTag("Side").GetComponent<QuestProgress>().Count += 1;
            return true;
        }
        else
        {
            return false;
        }
    }
}
