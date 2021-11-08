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

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("ForestBoss"))
        {
            Destroy(this);
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Chapter 7 Cutscene"))
        {
            Destroy(this);
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Tutorial1"))
        {
            Destroy(this);
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Tutorial2"))
        {
            Destroy(this);
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("EntFor1"))
        {
            Destroy(this);
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Chapter 6"))
        {
            Destroy(this);
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Chapter 7"))
        {
            Destroy(this);
        }
    }
}
