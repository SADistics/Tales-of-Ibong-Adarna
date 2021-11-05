using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTrigger : MonoBehaviour
{
    private void Awake()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) //if enemy count is 0
        {
            LoadLevel();
        }
    }

    private void LoadLevel()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("EntFor1"))
            SceneManager.LoadScene("EntFor2");

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("EntFor2"))
            SceneManager.LoadScene("Forest1");

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Forest1"))
            SceneManager.LoadScene("Forest2");

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Forest2"))
            SceneManager.LoadScene("ForestBoss");

    }
}
