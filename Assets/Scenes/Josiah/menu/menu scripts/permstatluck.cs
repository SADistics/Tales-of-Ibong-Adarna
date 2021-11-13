using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class permstatluck : MonoBehaviour
{
    public Text value;
    public static int permluck = 5;
    public int luckstat;
    public GameObject Points;
    private plusandminus availablepoints;
    // Start is called before the first frame update
    void Start()
    {
        luckstat = permluck;
        value = GetComponent<Text>();
        availablepoints = Points.GetComponent<plusandminus>();
    }

    // Update is called once per frame
    void Update()
    {
        value.text = permluck.ToString();
    }
    public void permincrement()
    {
        if (luckstat == permluck && availablepoints.stat > 0)
            luckstat += 1;
        if (availablepoints.stat > 0)
            luckstat++;
    }

    public void permdecrement()
    {
        if (luckstat != 1 && luckstat != permluck)
            luckstat--;

    }
    public void apply()
    {
        permluck = luckstat;
    }

    public int get()
    {
        return permluck;
    }
}
