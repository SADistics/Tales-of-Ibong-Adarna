using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class permstatdef : MonoBehaviour
{
    public Text value;
    public int defstat;
    public int permdef;
    // Start is called before the first frame update
    void Start()
    {
        value = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        value.text = defstat.ToString();
    }
    public void permincrement()
    {
        defstat++;
    }

    public void permdecrement()
    {
        if (defstat != 1 && defstat != permdef)
            defstat--;

    }
    public void apply()
    {
        permdef = defstat;
    }
}
