using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ChaseState : State
{
    public AttackState attackState;
    public bool isinAttackRange;

    public override State RunCurrentState()
    {
        if (isinAttackRange)
        {
            return attackState;
        }
        else
        {
            return this;
        }
    }
}
