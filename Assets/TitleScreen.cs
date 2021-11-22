using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject credits;
    public GameObject warning;
    public static bool isLoad;
    public bool isLoadedvar;

    void Awake()
    {
        credits.GetComponent<Canvas>().enabled = false;
        isLoad = isLoadedvar;
    }
    public void OnClickPlay()
    {
        SceneManager.LoadScene("DifficultySelect", LoadSceneMode.Single);
    }

    public void OnClickCredits()
    {
        titleScreen.GetComponent<Canvas>().enabled = false;
        credits.GetComponent<Canvas>().enabled = true;
    }

    public void OnClickLoad()
    {
        if (SaveLoad.CheckSave())
        {
            isLoadedvar = true;
            isLoad = isLoadedvar;
            SaveLoad.Load();
            SceneManager.LoadScene("Stage_Town_Respawn", LoadSceneMode.Single);
        }
        else
        {
            warning.GetComponent<Text>().enabled = true;
            StartCoroutine(WarningDelay());
        }
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }

    IEnumerator WarningDelay()
    {
        yield return new WaitForSeconds(2f);
        warning.GetComponent<Text>().enabled = false;
    }

    public void OnClickBack()
    {
        credits.GetComponent<Canvas>().enabled = false;
        titleScreen.GetComponent<Canvas>().enabled = true;
    }

    public bool isLoaded()
    {
        Debug.Log(isLoad);
        return isLoad;
    }

    public void setIsLoad(bool newVal)
    {
        isLoadedvar = newVal;
        isLoad = isLoadedvar;
    }
}
