using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats
{
    [SerializeField]
    private int baseStats;

    public int GetStats()
    {
        return baseStats;
    }
}
