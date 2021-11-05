using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class plusandminus : MonoBehaviour
{
    public Text value;
    public int stat;
    public GameObject points;
    private AvailableStatPoints availablepoints;
    void Start()
    {
       
        value = GetComponent<Text>();
        availablepoints = points.GetComponent<AvailableStatPoints>();
    }
    void Update()
    {
        value.text = stat.ToString();

    }
    public void increment()
    {
        if (stat == 0)
            stat += 1;
        if (availablepoints.astat > 0)
        {
            stat++;
        }
     }

    public void decrement()
    {

        if (stat != 0)
            stat--;
        
        
    }
    public void apply()
    {
        stat = 0;
    }
    
}
