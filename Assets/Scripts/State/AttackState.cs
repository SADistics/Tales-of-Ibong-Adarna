using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AttackState : State
{
    public override State RunCurrentState()
    {
        Debug.Log("I Attacked");
        return this;
    }
}
