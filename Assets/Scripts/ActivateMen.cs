using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMen : MonoBehaviour
{
    public GameObject Menu;
    public bool yes = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Menu.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Menu.SetActive(false);
        }

    }
}
