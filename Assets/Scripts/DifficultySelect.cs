using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySelect : MonoBehaviour
{
    public static int diffSelect;
    public int diff;

    void Start()
    {
        diff = diffSelect;
    }

    public void SetEasy()
    {
        setDiff(1);
        SaveLoad.NewSave();
        SceneManager.LoadScene("Chapter 1", LoadSceneMode.Single);
    }

    public void SetNormal()
    {
        setDiff(2);
        SaveLoad.NewSave();
        SceneManager.LoadScene("Chapter 1", LoadSceneMode.Single);
    }

    public void SetHard()
    {
        setDiff(3);
        SaveLoad.NewSave();
        SceneManager.LoadScene("Chapter 1", LoadSceneMode.Single);
    }

    public void ReturnToMain()
    {
        if (GameObject.Find("BGM") != null)
        {
            Destroy(GameObject.Find("BGM"));
            SceneManager.LoadScene("TitleScreen", LoadSceneMode.Single);
        }else
            SceneManager.LoadScene("TitleScreen", LoadSceneMode.Single);
    }

    public int GetDiff()
    {
        return diffSelect;
    }

    public int saveDiff()
    {
        Debug.Log(diffSelect);
        return diffSelect;
    }

    public void setDiff(int val)
    {
        Debug.Log(val);
        diffSelect = val;
    }
}
