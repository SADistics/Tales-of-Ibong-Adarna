using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractDialogue : MonoBehaviour
{
    public string playerName = "Don Juan";

    public DialogueManager diagUI;

    public VIDE_Assign inTrigger;

    private Text interactionPromptText;
    private GameObject interactionPrompt;

    // Start is called before the first frame update
    void Start()
    {
        interactionPrompt = GameObject.Find("InteractionPrompt");
        if (interactionPrompt != null)
        {
            interactionPrompt.SetActive(false);
        }
        interactionPromptText = GameObject.Find("InteractionPromptText").GetComponent<Text>();
        interactionPromptText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
            interactionPrompt.SetActive(false);
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
        interactionPrompt.SetActive(true);
        if (other.GetComponent<VIDE_Assign>() != null)
        {
            inTrigger = other.GetComponent<VIDE_Assign>();
            interactionPromptText.text = "Press 'E' to interact with "+inTrigger.alias;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        inTrigger = null;
        interactionPrompt.SetActive(false);
        interactionPromptText.text = "";
    }
}
