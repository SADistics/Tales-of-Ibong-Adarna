using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTrigger : MonoBehaviour
{
    EnemySpawnManager esm;
    public EnemyCount ec;
    public AvailableStatPoints avStats;

    void Awake()
    {
        ec = GameObject.Find("EnemyManager").GetComponent<EnemyCount>();
        avStats = GameObject.FindGameObjectWithTag("Stat").GetComponent<AvailableStatPoints>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && ec.enemyCount == 0) //if enemy count is 0
        {
            LoadLevel();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && ec.enemyCount == 0) //if enemy count is 0
        {
            LoadLevel();
        }
    }

    private void LoadLevel()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Stage_Town_1")|| SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Stage_Town_Respawn"))
        {
            SceneManager.LoadScene("EntFor1", LoadSceneMode.Single);
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("EntFor1"))
            SceneManager.LoadScene("EntFor2");

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("EntFor2"))
            SceneManager.LoadScene("Chapter 6", LoadSceneMode.Single);

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Forest1"))
            SceneManager.LoadScene("ForestPuzzle");

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Forest2"))
        {
            SceneManager.LoadScene("ForestBoss", LoadSceneMode.Single);
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("ForestBoss"))
            SceneManager.LoadScene("Chapter 7 Cutscene", LoadSceneMode.Single);

    }
}
