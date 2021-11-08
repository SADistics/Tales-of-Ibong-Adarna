using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicDestroy : MonoBehaviour
{
    void Awake()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("ForestBoss"))
        {
            Destroy(GameObject.FindGameObjectWithTag("Music"));
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Chapter 7 Cutscene"))
        {
            Destroy(GameObject.Find("BossMusic"));
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Tutorial1"))
        {
            Destroy(GameObject.Find("Music"));
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Tutorial2"))
        {
            Destroy(GameObject.Find("Music"));
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("EntFor1"))
        {
            Destroy(GameObject.Find("Music"));
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("forest1"))
        {
            Destroy(GameObject.Find("Music"));
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Chapter 6"))
        {
            Destroy(GameObject.Find("ForestMusic"));
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Chapter 7"))
        {
            Destroy(this);
        }
    }
}
