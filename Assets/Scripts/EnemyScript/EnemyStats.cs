using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float Strength;
    public float Agility;
    public float Defense;
    public float Health;
    public string type;

    public float GetEnemyStrength() => Strength;

    public float GetEnemyAgility() => Agility;

    public float GetEnemyDefense() => Defense;

    public float GetHealth() => Health;

    public string Gettype() => type;
}
