using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    public static LevelSystem instance;

    public Text uiLevelText;
    public Text EXPText;
    public Image ExpBar;
    public ActivateMen activateMen;

    private int level = 0;
    private static int permLevel;
    private int experience;
    private int experienceToNextLevel;

    public AvailableStatPoints availableStat;

    public bool isSet;

    private void Start()
    {
        isSet = false;
        EXPText = GameObject.Find("EXPText").GetComponent<Text>();
        uiLevelText = GameObject.Find("LVLText").GetComponent<Text>();
        ExpBar = GameObject.Find("EXPFiller").GetComponent<Image>();
        availableStat = GameObject.FindGameObjectWithTag("Stat").GetComponent<AvailableStatPoints>();
        activateMen = GameObject.FindGameObjectWithTag("Pause").GetComponent<ActivateMen>();
        if (instance != null)
        {
            Debug.Log("More than one LevelSystem in scene!");
            return;
        }

        instance = this;

        if (permLevel == 0)
        {
            permLevel++;
        }

        SetLevel(permLevel);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.J))
            AddExperience(100);
        //ExpBar.fillAmount = experience / experienceToNextLevel;
    }

    public bool AddExperience(int experienceToAdd)
    {
        experience += experienceToAdd;

        if (experience >= experienceToNextLevel)
        {
            SetLevel(level + 1);
            availableStat.AStatAdd(3);
            return true;
        }

        UpdateVisual();
        return false;
    }

    public void SetLevel(int value)
    {
        this.level = value;
        permLevel = level;
        experience = experience - experienceToNextLevel;
        experienceToNextLevel = (int)(50f * (Mathf.Pow(level + 1, 2) - (5 * (level + 1)) + 8));
        if (isSet)
        {
            activateMen.Menu.GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
        }
        isSet = true;
        UpdateVisual();
    }

    public void UpdateVisual()
    {
        ExpBar.fillAmount = experience / experienceToNextLevel;
        EXPText.text = experience.ToString() + " / " + experienceToNextLevel.ToString();
        uiLevelText.text = permLevel.ToString();
    }

    public int GetLVL()
    {
        return permLevel;
    }

    public void setperm(int val)
    {
        permLevel = val;
    }

    public int GetEXP()
    {
        return experience;
    }
}
