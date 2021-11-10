using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class permstatstr : MonoBehaviour
{
    public Text value;
    public static int permstr = 5;
    public int strstat=permstr;
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
        value.text = permstr.ToString();
    }
    public void permincrement()
    {
        if (strstat == permstr && availablepoints.stat > 0)
            strstat += 1;
        if (availablepoints.stat > 0)
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

    public int get()
    {
        return permstr;
    }
}

