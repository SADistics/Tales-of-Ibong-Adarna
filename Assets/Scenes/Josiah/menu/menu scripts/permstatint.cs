using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class permstatint : MonoBehaviour
{
    public Text value;
    public static int permint = 5;
    public int intstat;
    public GameObject Points;
    private plusandminus availablepoints;
    // Start is called before the first frame update
    void Start()
    {
        intstat = permint;
        value = GetComponent<Text>();
        availablepoints = Points.GetComponent<plusandminus>();
    }

    // Update is called once per frame
    void Update()
    {
        value.text = permint.ToString();
    }
    public void permincrement()
    {
        if (intstat == permint && availablepoints.stat > 0)
            intstat += 1;
        if (availablepoints.stat > 0)
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

    public int get()
    {
        return permint;
    }

    public void setperm(int newVal)
    {
        permint = newVal;
    }
}

