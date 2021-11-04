using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats
{
    [SerializeField]
    private float baseStats;

    public float GetStats()
    {
        return baseStats;
    }
}
