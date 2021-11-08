using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvailableStatPoints : MonoBehaviour
{
   
    public Text val;
    public int astat;

    public static int avstat;
    public GameObject points;
    public GameObject points1;
    public GameObject points2;
    public GameObject points3;
    public GameObject points4;
    public GameObject points5;
    private plusandminus availablepoints;
    private plusandminus availablepoints1;
    private plusandminus availablepoints2;
    private plusandminus availablepoints3;
    private plusandminus availablepoints4;
    private plusandminus availablepoints5;
    void Start()
    {
        val = GetComponent<Text>();
        astat = 99;
        availablepoints = points.GetComponent<plusandminus>();
        availablepoints1 = points1.GetComponent<plusandminus>();
        availablepoints2 = points2.GetComponent<plusandminus>();
        availablepoints3 = points3.GetComponent<plusandminus>();
        availablepoints4 = points4.GetComponent<plusandminus>();
        availablepoints5 = points5.GetComponent<plusandminus>();
    }
    void Update()
    {
        avstat = astat;
        val.text = avstat.ToString();

    }
    public void adecrement()
    {
        if (astat != 0)
            astat--;
    }

    public void aincrements()
    {
        if (availablepoints.stat != 0)
        {
            astat++;
            

        }
    

       
    }
    public void aincrementi()
    {
        if (availablepoints1.stat != 0)
        {
            astat++;
        }
        
           
    }
    public void aincrementd()
    {
        if (availablepoints2.stat != 0)
        {
            astat++;
        }
       
    }
    public void aincrementdf()
    {
        if ( availablepoints3.stat != 0)
        {
            astat++;
        }
       
    }
    public void aincrementa()
    {
        if (availablepoints4.stat != 0)
        {
            astat++;
           
        }
        
    }
    public void aincrementl()
    {
        if (availablepoints5.stat != 0)
        {
            astat++;
        }
        
    }

 
    

}
