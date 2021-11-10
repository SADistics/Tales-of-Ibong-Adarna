using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class permstatdex : MonoBehaviour
{
    public Text value;
    public static int permdex = 5;
    public int dexstat=permdex;
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
        value.text = permdex.ToString();
    }
    public void permincrement()
    {
        if (dexstat == permdex && availablepoints.stat > 0)
            dexstat += 1;
        if (availablepoints.stat > 0)
            dexstat++;
    }

    public void permdecrement()
    {
        if (dexstat != 1 && dexstat != permdex)
            dexstat--;

    }
    public void apply()
    {
        permdex = dexstat;
    }
    public int get()
    {
        return permdex;
    }
}
