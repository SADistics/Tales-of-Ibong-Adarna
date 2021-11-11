using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateMen : MonoBehaviour
{
    public Canvas Menu;
    public bool yes = true;

    // Start is called before the first frame update
    void Start()
    {
        Menu = GameObject.Find("Player menu").GetComponent<Canvas>();
        Menu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Menu.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Menu.enabled = false;
        }

    }
}
