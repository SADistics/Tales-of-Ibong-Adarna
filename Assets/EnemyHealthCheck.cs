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
    private int totalHealth;

    private void Start()
    {
        enemyAnim = enemyMain.GetComponentInChildren<Animator>();
        enemyStats = enemyMain.GetComponentInChildren<EnemyStats>();
        totalHealth = enemyStats.GetHealth();
    }
    void Update()
    {
        hpBar.text = "HP: " + enemyStats.GetHealth() + "/" + totalHealth;
        if (enemyStats.GetHealth() == 0)
        {
            enemyAnim.GetComponent<Transform>().position = new Vector3(enemyAnim.GetComponent<Transform>().position.x, enemyAnim.GetComponent<Transform>().position.y - 0.5f, enemyAnim.GetComponent<Transform>().position.z);
            enemyMain.GetComponent<AIPath>().canMove = false;
            enemyMain.GetComponent<StateManager>().enabled = false;
            /*enemyMain.GetComponentInChildren<Rigidbody>().detectCollisions = false;
            enemyMain.GetComponentInChildren<Rigidbody>().useGravity = false;*/
            StartCoroutine(DeathCo());
        }
    }

    private IEnumerator DeathCo()
    {
        enemyAnim.SetBool("isDead", true);
        yield return new WaitForSeconds(10);
        GameObject.Destroy(enemyMain);
    }
}
