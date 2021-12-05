using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skilldescription : MonoBehaviour
{

    public Text value;
    public string DS = "Focusing your energy in your blade, release a single motion slash that deals significant damage. ";
    public string WW = "Harness the power of the wind making each step you take lighter. Makes you walk faster ";
    public string RF = "Increase focus and make your shots faster";
    public string RS = "Use the knowledge of a Ranger to traverse quickly";

    // Start is called before the first frame update
    void Start()
    {
        value = GetComponent<Text>();

    }

    // Update is called once per frame
    public void DStxt()
    {
        value.text = DS;
    }
    public void WWtxt()
    {
        value.text = WW;
    }
    public void RFtxt()
    {
        value.text = RF;
    }
    public void RStxt()
    {
        value.text = RS;
    }
}