using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 180;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;
    private PlayerHealth playerHealth;
    private GameObject player;

    private void Start()
    {
        timerIsRunning = true;

        if (GameObject.FindGameObjectWithTag("Player"))
        {
            player= GameObject.FindGameObjectWithTag("Player");
            playerHealth = player.GetComponent<PlayerHealth>();
        }
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        }
        else
        {
            playerHealth.curHP = 0;
            playerHealth.SetHealthBarValue(playerHealth.curHP);
            timeRemaining = 0;
            timerIsRunning = false;
            DisplayTime(timeRemaining);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
