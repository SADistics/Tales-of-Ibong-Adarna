using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractDialogue : MonoBehaviour
{
    public string playerName = "Don Juan";

    public DialogueManager diagUI;

    public VIDE_Assign inTrigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }

    private void TryInteract()
    {
        if (inTrigger)
        {
            diagUI.Interact(inTrigger);
            return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<VIDE_Assign>() != null)
        {
            inTrigger = other.GetComponent<VIDE_Assign>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        inTrigger = null;
    }
}
