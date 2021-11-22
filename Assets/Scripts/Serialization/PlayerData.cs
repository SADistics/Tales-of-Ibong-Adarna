using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;
    public int[] playerStats;
    public int availableSP;
    public int availableSkillP;
    public int difficulty;

    public PlayerData(LevelSystem playerLevel, PermStat playerStat, AvailableStatPoints ASP, skillavailablepoints SAP, DifficultySelect ds)
    {
        level = playerLevel.GetLVL();

        playerStats = new int[6];
        playerStats[0] = playerStat.agi;
        playerStats[1] = playerStat.def;
        playerStats[2] = playerStat.dex;
        playerStats[3] = playerStat.inte;
        playerStats[4] = playerStat.luck;
        playerStats[5] = playerStat.str;

        availableSP = ASP.Get();
        availableSkillP = SAP.Get();

        difficulty = ds.saveDiff();
    }
}
