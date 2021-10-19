using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class WaypointScript : MonoBehaviour
{
    public AIDestinationSetter aiDest;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("GoblinEnemy"))
        {
            aiDest.OutOfRange();
            aiDest.SetDest(true);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("GoblinEnemy"))
        {
            aiDest.SetDest(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("GoblinEnemy"))
        {
            aiDest.SetDest(false);
        }
    }
}
