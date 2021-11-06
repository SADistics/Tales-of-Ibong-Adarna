using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainStory : MonoBehaviour
{
    void Awake()
    {
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        if (this.enabled)
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Chapter 1"))
                SceneManager.LoadScene("Chapter 2", LoadSceneMode.Single);              
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Chapter 2"))
                SceneManager.LoadScene("Chapter 3", LoadSceneMode.Single);
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Chapter 3"))
                SceneManager.LoadScene("Tutorial1", LoadSceneMode.Single);
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Chapter 4"))
                SceneManager.LoadScene("Tutorial2", LoadSceneMode.Single);
        }
    }
}
