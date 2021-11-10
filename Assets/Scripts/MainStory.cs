using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainStory : MonoBehaviour
{
    bool noEnemy;
    void Start()
    {
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Tutorial1"))
        {
            this.gameObject.SetActive(true);
        }
        else if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Tutorial2"))
        {
            this.gameObject.SetActive(true);
        }    
        else if (SceneManager.GetActiveScene()== SceneManager.GetSceneByName("Stage_Town_1"))
        {
            this.gameObject.SetActive(true);
        }
        else
            this.gameObject.SetActive(false);
    }

    void Update()
    {
        SceneChanger();
    }

    public void SceneChanger()
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
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Chapter 5.1"))
                SceneManager.LoadScene("Stage_Town_1", LoadSceneMode.Single);
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Chapter 6"))
                SceneManager.LoadScene(4, LoadSceneMode.Single);
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Chapter 7 Cutscene"))
                SceneManager.LoadScene("Chapter 7 End", LoadSceneMode.Single);
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Chapter 7 End"))
                SceneManager.LoadScene("Chapter 8", LoadSceneMode.Single);
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Chapter 8"))
                SceneManager.LoadScene("Chapter 9", LoadSceneMode.Single);
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Chapter 9"))
                SceneManager.LoadScene("Titlescreen", LoadSceneMode.Single);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Tutorial1"))
                SceneManager.LoadScene("Chapter 4", LoadSceneMode.Single);
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Tutorial2"))
            {
                SceneManager.LoadScene("Chapter 5.1", LoadSceneMode.Single);
            }             
        }
    }
}
