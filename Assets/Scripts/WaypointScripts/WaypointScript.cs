using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class WaypointScript : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("GoblinEnemy"))
        {
            other.GetComponent<AIDestinationSetter>().OutOfRange();
            other.GetComponent<AIDestinationSetter>().SetDest(true);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("GoblinEnemy"))
        {
            other.GetComponent<AIDestinationSetter>().SetDest(false);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("GoblinEnemy"))
        {
            other.GetComponent<AIDestinationSetter>().SetDest(false);
        }
    }
}
