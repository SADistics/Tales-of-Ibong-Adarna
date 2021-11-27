using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadSys : MonoBehaviour
{
    public LevelSystem playerLevel;
    public PermStat playerStat;
    public AvailableStatPoints ASP;
    public skillavailablepoints SAP;
    public DifficultySelect ds;
    public static int saveCounter;

    private void Start()
    {
        playerLevel = GetComponent<LevelSystem>();
        playerStat = GetComponentInChildren<PermStat>();
        if (SaveLoad.loadGame)
        {
            LoadGame();
            SaveLoad.loadGame = false;
        }

        if (SaveLoad.newGame)
        {
            NewGame();
            SaveLoad.newGame = false;
        }

        ASP = GameObject.Find("Avialable statpoints#").GetComponent<AvailableStatPoints>();
        SAP = GameObject.Find("skillavailablepoints").GetComponent<skillavailablepoints>();
    }

    public void SavePlayer()
    {
        SaveLoad.Save(playerLevel, playerStat, ASP, SAP, ds);
    }

    public void LoadGame()
    {
        PlayerData data = SaveLoad.Load();

        GetComponent<LevelSystem>().setperm(data.level);
        GetComponentInChildren<permstatagi>().setperm(data.playerStats[0]);
        GetComponentInChildren<permstatdef>().setperm(data.playerStats[1]);
        GetComponentInChildren<permstatdex>().setperm(data.playerStats[2]);
        GetComponentInChildren<permstatint>().setperm(data.playerStats[3]);
        GetComponentInChildren<permstatluck>().setperm(data.playerStats[4]);
        GetComponentInChildren<permstatstr>().setperm(data.playerStats[5]);
        GetComponent<SaveLoadSys>().ds.setDiff(data.difficulty);

        ASP.Restore(data.availableSP);
        SAP.sstat = data.availableSkillP;
    }

    public void NewGame()
    {
        GetComponent<LevelSystem>().setperm(1);
        GetComponentInChildren<permstatagi>().setperm(5);
        GetComponentInChildren<permstatdef>().setperm(5);
        GetComponentInChildren<permstatdex>().setperm(5);
        GetComponentInChildren<permstatint>().setperm(5);
        GetComponentInChildren<permstatluck>().setperm(5);
        GetComponentInChildren<permstatstr>().setperm(5);
    }
}
