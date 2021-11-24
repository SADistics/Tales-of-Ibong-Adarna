using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Itemdescription : MonoBehaviour
{
    public Text value;
    public string item;
    // Start is called before the first frame update
    void Start()
    {
        value = GetComponent<Text>();
        item = "increases the players health to maximum value";
    }

    // Update is called once per frame
    void Update()
    {
        value = GetComponent<Text>();
    }
    public void Itxt()
    {
        value.text = item;
    }
}
