using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int Strength;
    public int Agility;
    public int Defense;

    public int GetEnemyStrength() => Strength;

    public int GetEnemyAgility() => Agility;

    public int GetEnemyDefense() => Defense;
}
