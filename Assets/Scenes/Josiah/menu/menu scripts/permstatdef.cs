using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class permstatdef : MonoBehaviour
{
    public Text value;
    public static int permdef = 5;
    public int defstat = permdef;
    public GameObject Points;
    private plusandminus availablepoints;
    // Start is called before the first frame update
    void Start()
    {
        value = GetComponent<Text>();
        availablepoints = Points.GetComponent<plusandminus>();
    }

    // Update is called once per frame
    void Update()
    {
        value.text = permdef.ToString();
    }
    public void permincrement()
    {
        if (defstat == permdef && availablepoints.stat > 0)
            defstat += 1;
        if (availablepoints.stat > 0)
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

    public int get()
    {
        return permdef;
    }
}
