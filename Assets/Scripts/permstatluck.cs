using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class permstatluck : MonoBehaviour
{
    public Text value;
    public int luckstat;
    public static int permluck = 1;
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
        value.text = permluck.ToString();
    }
    public void permincrement()
    {
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
}
