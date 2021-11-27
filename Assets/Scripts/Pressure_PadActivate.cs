using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressure_PadActivate : MonoBehaviour
{
    public bool isActivated = false;
    public bool done = false;
    public Animator blockAnim;
    public ExitTriggerPuzzle exitTrigger;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Movable"))
        {
            isActivated = true;
            this.GetComponent<Renderer>().material.color = Color.blue;
            blockAnim.SetBool("isActivated", true);
            if (!done)
            {
                exitTrigger.puzzleCount--;
                exitTrigger.puzzlecurrCount++;
                done = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Movable"))
        {
            this.GetComponent<Renderer>().material.color = Color.red;
            isActivated = false;
            blockAnim.SetBool("isActivated", false);
            if (done)
            {
                exitTrigger.puzzleCount++;
                exitTrigger.puzzlecurrCount--;
                done = false;
            }
        }
    }
}
