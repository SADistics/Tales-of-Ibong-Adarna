using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTESys : MonoBehaviour
{
    [SerializeField]
    public GameObject DisplayButtons;
    public GameObject Passbox;
    public GameObject QTEInterface;
    public int qteGen;
    public int waitingForKey;
    public int correctKey;
    public int CountingDown;
    public Image TimeFrame;
    public float timeTreshold;
    public bool QTRSTART;

    private void Start()
    {
        QTEInterface.SetActive(false);
    }

    public void Update()
    {
        if (QTRSTART)
        {
            if (waitingForKey == 0)
            {
                QTEInterface.SetActive(true);
                qteGen = Random.Range(1, 4);
                CountingDown = 1;
                StartCoroutine(Countdown());

                if (qteGen == 1)
                {
                    waitingForKey = 1;
                    DisplayButtons.GetComponent<Text>().text = "[G]";
                }
                if (qteGen == 2)
                {
                    waitingForKey = 2;
                    DisplayButtons.GetComponent<Text>().text = "[H]";
                }
                if (qteGen == 3)
                {
                    waitingForKey = 3;
                    DisplayButtons.GetComponent<Text>().text = "[T]";
                }
            }

            if (qteGen == 1)
            {
                if (Input.anyKeyDown)
                {
                    if (Input.GetKeyDown(KeyCode.G))
                    {
                        correctKey = 1;
                        StartCoroutine(KeyPressing());
                    }
                    else
                    {
                        correctKey = 2;
                        StartCoroutine(KeyPressing());
                    }
                }
            }

            if (qteGen == 2)
            {
                if (Input.anyKeyDown)
                {
                    if (Input.GetKeyDown(KeyCode.H))
                    {
                        correctKey = 1;
                        StartCoroutine(KeyPressing());
                    }
                    else
                    {
                        correctKey = 2;
                        StartCoroutine(KeyPressing());
                    }
                }
            }

            if (qteGen == 3)
            {
                if (Input.anyKeyDown)
                {
                    if (Input.GetKeyDown(KeyCode.T))
                    {
                        correctKey = 1;
                        StartCoroutine(KeyPressing());
                    }
                    else
                    {
                        correctKey = 2;
                        StartCoroutine(KeyPressing());
                    }
                }
            }

            if (TimeFrame.fillAmount == 1 && correctKey==0)
            {
                correctKey = 2;
                StartCoroutine(KeyPressing());
            }
        }
    }

    public IEnumerator Countdown()
    {
        while (timeTreshold < 1.5f)
        {
            timeTreshold += Time.deltaTime;
            TimeFrame.fillAmount = timeTreshold / 1.5f;
            yield return null;
        }
    }

    public IEnumerator KeyPressing()
    {
        qteGen = 4;
        if (correctKey == 1)
        {
            CountingDown = 2;
            Passbox.GetComponent<Text>().text = "Success!";
            yield return new WaitForSeconds(1.5f);
            Passbox.GetComponent<Text>().text = "";
            DisplayButtons.GetComponent<Text>().text = "";
            Time.timeScale = 1;
            QTEInterface.SetActive(false);
            yield return new WaitForSeconds(1.5f);
            correctKey = 0;
            waitingForKey = 0;
            CountingDown = 1;
            timeTreshold = 0;
            QTRSTART = false;
            TimeFrame.fillAmount = 0;
        }
        if (correctKey == 2)
        {
            CountingDown = 2;
            Passbox.GetComponent<Text>().text = "Failed...";
            yield return new WaitForSeconds(1.5f);
            correctKey = 0;
            Passbox.GetComponent<Text>().text = "";
            DisplayButtons.GetComponent<Text>().text = "";
            Time.timeScale = 1;
            QTEInterface.SetActive(false);
            yield return new WaitForSeconds(1.5f);
            waitingForKey = 0;
            CountingDown = 1;
            timeTreshold = 0;
            QTRSTART = false;
            TimeFrame.fillAmount = 0;
        }
    }
}
