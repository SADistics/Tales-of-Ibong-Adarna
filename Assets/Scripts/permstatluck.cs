using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class permstatluck : MonoBehaviour
{
    public Text value;
    public int luckstat;
    public int permluck;
    // Start is called before the first frame update
    void Start()
    {
        value = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        value.text = luckstat.ToString();
    }
    public void permincrement()
    {
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
