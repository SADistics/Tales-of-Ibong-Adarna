using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class permstatint : MonoBehaviour
{
    public Text value;
    public int intstat;
    public int permint;
    // Start is called before the first frame update
    void Start()
    {
        value = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        value.text = intstat.ToString();
    }
    public void permincrement()
    {
        intstat++;
    }

    public void permdecrement()
    {
        if (intstat != 1 && intstat != permint)
            intstat--;

    }
    public void apply()
    {
        permint = intstat;
    }
}

