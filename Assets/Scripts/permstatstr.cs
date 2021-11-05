using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class permstatstr : MonoBehaviour
{
    public Text value;
    public int strstat;
    public int permstr;
    // Start is called before the first frame update
    void Start()
    {
        value = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        value.text = strstat.ToString();
    }
    public void permincrement()
    {
        strstat++;
    }

    public void permdecrement()
    {
        if (strstat != 1 && strstat != permstr)
            strstat--;

    }

    public void apply()
    {
        permstr = strstat;
    }
}

