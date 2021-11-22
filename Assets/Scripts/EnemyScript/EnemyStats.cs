using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int Level;
    public float Strength;
    public float Agility;
    public float Defense;
    public float Health;
    public string type;
    public int exp;
    public DifficultySelect ds;
    public float sta;

    public float GetEnemyStrength() => Strength;

    public float GetEnemyAgility() => Agility;

    public float GetEnemyDefense() => Defense;

    public float GetHealth() => Health;

    public string Gettype() => type;

    public int GetEXP() => exp;

    void Awake()
    {
        ds = GameObject.FindGameObjectWithTag("Player").GetComponent<SaveLoadSys>().ds;

        Debug.Log(ds.GetDiff());

        if (ds.GetDiff() == 1)
        {
            sta = 0.11f;
        }
        if (ds.GetDiff() == 2)
        {
            sta = 0.22f;
        }
        if (ds.GetDiff() == 3)
        {
            sta = 0.55f;
        }

        if (this.GetComponent<EnemyStats>().type != "Boss")
        {
            Level = GameObject.FindGameObjectWithTag("Player").GetComponent<LevelSystem>().GetLVL();
            Strength = Strength + (Strength * (Level * sta));
            Agility = Agility + (Agility * (Level * sta));
            Defense = Defense + (Defense * (Level * sta));
            Health = Health + (Health * (Level * sta));
        }
    }
}
