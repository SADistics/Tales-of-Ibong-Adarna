using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class permstatdex : MonoBehaviour
{
    public Text value;
    public int dexstat;
    public static int permdex = 1;
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
}
