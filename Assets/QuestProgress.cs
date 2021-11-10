using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestProgress : MonoBehaviour
{
    public static int permCount;
    public int Count = permCount;
    public bool isTrue;
    public GameObject sqPrompt;

    private void Awake()
    {
        sqPrompt = GameObject.FindGameObjectWithTag("SidePrompt");
        DontDestroyOnLoad(transform.gameObject);
        DontDestroyOnLoad(sqPrompt);
        sqPrompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        questCheck();
    }

    private void questCheck()
    {
        if (Count == 5 && GetComponent<RandomSideQuest>().SlimeQuest)
        {
            isTrue = true;
            GetComponent<RandomSideQuest>().SlimeQuest = false;
            sqPrompt.SetActive(true);
            StartCoroutine(VanishCO());
        }
    }

    private IEnumerator VanishCO()
    {
        yield return new WaitForSeconds(3f);
        sqPrompt.SetActive(false);
    }
}
