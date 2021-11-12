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

    public float GetEnemyStrength() => Strength;

    public float GetEnemyAgility() => Agility;

    public float GetEnemyDefense() => Defense;

    public float GetHealth() => Health;

    public string Gettype() => type;

    public int GetEXP() => exp;

    void Awake()
    {
        if(this.GetComponent<EnemyStats>().type != "Boss")
        {
            Level = GameObject.FindGameObjectWithTag("Player").GetComponent<LevelSystem>().GetLVL();
            Strength = Strength + (Strength * (Level * 0.55f));
            Agility = Agility + (Agility * (Level * 0.55f));
            Defense = Defense + (Defense * (Level * 0.55f));
            Health = Health + (Health * (Level * 0.55f));
        }
    }
}
