using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VIDE_Data;

public class RandomSideQuest : MonoBehaviour
{
    #region Static Vars
    public static bool statSlimeQuest = false;
    public static bool statGoblinQuest = false;
    public static bool statZombieQuest = false;
    public static bool statGhostQuest = false;
    public static bool StatisSide = false;
    #endregion

    public bool SlimeQuest= statSlimeQuest;
    public bool GoblinQuest = statGoblinQuest;
    public bool ZombieQuest = statZombieQuest;
    public bool GhostQuest = statGhostQuest;
    private int QuestNumb;
    public bool isSide = StatisSide;

    public void GetSlimeQuest()
    {
        if (!isSide)
        {
            SlimeQuest = true;
            statSlimeQuest = true;
            isSide = true;
        }
    }

    public void GetGoblinQuest()
    {
        if (!isSide)
        {
            GoblinQuest = true;
            statGoblinQuest = GoblinQuest;
            isSide = true;
        }            
    }

    public void GetZombieQuest()
    {
        if (!isSide)
        {
            ZombieQuest = true;
            statZombieQuest = ZombieQuest;
            isSide = true;
        }
    }

    public void GetGhostQuest()
    {
        if (!isSide)
        {
            GhostQuest = true;
            statGhostQuest = GhostQuest;
            isSide = true;
        }
    }
}
