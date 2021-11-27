using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectGrab : MonoBehaviour
{
    public Text interactionPrompt;
    public bool isDetect = false;
    public GameObject movable;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Movable"))
        {
            isDetect = true;
            interactionPrompt.text = "Press Space to grab the block.";
            movable = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Movable"))
        {
            isDetect = false;
            interactionPrompt.text = "";
            movable = null;
        }
    }

    void Update()
    {
        if (isDetect)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                movable.transform.parent = this.transform;
                interactionPrompt.text = "";
            }
            else
            {
                movable.transform.parent = null;
            }
        }
    }
}
