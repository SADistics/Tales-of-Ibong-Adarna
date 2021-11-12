using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicScript : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }

    /*void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("ForestBoss"))
        {
            if (GameObject.Find("BossMusic"))
            {
                Destroy(this);
                Destroy(GameObject.Find("BossMusic"));
            }
            
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Chapter 7 Cutscene"))
        {
            Destroy(this);
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Tutorial1"))
        {
            if (GameObject.Find("Music"))
            {
                Destroy(this);
                Destroy(GameObject.Find("Music"));
            }
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Tutorial2"))
        {
            if (GameObject.Find("Music"))
            {
                Destroy(this);
                Destroy(GameObject.Find("Music"));
            }
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("EntFor1"))
        {
            if (GameObject.Find("Music"))
            {
                Destroy(this);
                Destroy(GameObject.Find("Music"));
            }
        }
        /*if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Chapter 6"))
        {
            if (GameObject.Find("ForestMusic"))
            {
                Destroy(this);
                Destroy(GameObject.Find("ForestMusic"));
            }
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Chapter 7"))
        {
            Destroy(this);
            Destroy(GameObject.Find("Music"));
        }
    }*/
}
