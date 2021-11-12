using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject credits;

    void Awake()
    {
        credits.GetComponent<Canvas>().enabled = false;
    }
    public void OnClickPlay()
    {
        SceneManager.LoadScene("Chapter 1", LoadSceneMode.Single);
    }

    public void OnClickCredits()
    {
        titleScreen.GetComponent<Canvas>().enabled = false;
        credits.GetComponent<Canvas>().enabled = true;
    }

    public void OnClickBack()
    {
        credits.GetComponent<Canvas>().enabled = false;
        titleScreen.GetComponent<Canvas>().enabled = true;
    }
}
