using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class IdleState : State
{
    public ChaseState chaseState;
    public bool ISeePlayer;
    public AIDestinationSetter aiDest;
    public AIPath aiPath;
    public Animator anim;

    //Patrol
    public EnemyStats enemyStats;

    public override State RunCurrentState()
    {
        if (aiPath.canMove)
        {
            anim.SetBool("isWalking", true);
        }
        else if(aiDest.aiDest)
        {
            anim.SetBool("isWalking", false);
        }

        if (ISeePlayer)
        {
            return chaseState;
        }
        else
        {
            return this;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            aiDest.GetPlayer(other.transform);
            aiDest.SetDest(true);
            ISeePlayer = true;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            aiDest.GetPlayer(other.transform);
            aiDest.SetDest(true);
            ISeePlayer = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            aiDest.OutOfRange();
            aiDest.SetDest(true);
            ISeePlayer = false;
        }
    }
}
