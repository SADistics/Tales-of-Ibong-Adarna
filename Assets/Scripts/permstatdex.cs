using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class permstatdex : MonoBehaviour
{
    public Text value;
    public int dexstat;
    public int permdex;
    // Start is called before the first frame update
    void Start()
    {
        value = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        value.text = dexstat.ToString();
    }
    public void permincrement()
    {
        dexstat++;
    }

    public void permdecrement()
    {
        if (dexstat != 1 && dexstat != permdex)
            dexstat--;

    }
    public void apply()
    {
        permdex = dexstat;
    }
}
