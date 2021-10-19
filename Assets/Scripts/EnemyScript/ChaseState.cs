using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ChaseState : State
{
    public AttackState attackState;
    public IdleState idle;
    public bool isinAttackRange;
    public AIPath aiPath;
    public Animator anim;

    public override State RunCurrentState()
    {
        if (aiPath.canMove)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if (isinAttackRange)
        {
            return attackState;
        }
        else
        {
            return idle;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isinAttackRange = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isinAttackRange = false;
        }
    }
}
