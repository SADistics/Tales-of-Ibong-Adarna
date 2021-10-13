using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class IdleState : State
{
    public ChaseState chaseState;
    public bool ISeePlayer;
    public AIDestinationSetter aiDest;

    public override State RunCurrentState()
    {
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
            ISeePlayer = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            aiDest.OutOfRange();
            ISeePlayer = false;
        }
    }
}
