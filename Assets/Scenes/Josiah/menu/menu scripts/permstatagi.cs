using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class permstatagi : MonoBehaviour
{
    public Text value;
    public static int permagi = 5;
    public int agistat=permagi;
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
        value.text = permagi.ToString();
    }
    public void permincrement()
    {
        if (agistat == permagi && availablepoints.stat > 0)
            agistat += 1;
        if (availablepoints.stat > 0)
            agistat++;
    }

    public void permdecrement()
    {
        if (agistat != 1 && agistat != permagi)
            agistat--;

    }
    public void apply()
    {
        permagi = agistat;
    }

    public int get()
    {
        return permagi;
    }
}
