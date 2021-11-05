using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class permstatagi : MonoBehaviour
{
    public Text value;
    public int agistat;
    public int permagi;
    // Start is called before the first frame update
    void Start()
    {
        value = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        value.text = agistat.ToString();
    }
    public void permincrement()
    {
        agistat++;
    }

    public void permdecrement()
    {
        if (agistat != 1 && agistat != permagi)
            agistat--;

    }
    public void apply()
    {
        permagi = agistat;
    }
}
