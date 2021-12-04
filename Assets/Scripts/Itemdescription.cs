using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Itemdescription : MonoBehaviour
{
    public Text value;
    public string item;
    public string item2;
    public string item3;
    public string item4;
    public string item5;
    public string item6;
    public string item7;
    public string item8;
    public string item9;
    public string item10;
    public string item11;
    // Start is called before the first frame update
    void Start()
    {
        value = GetComponent<Text>();
        item = "increases the players health by a small value";
        item2 = "increases the players health by a good value";
        item3 = "increases the players health to a maximum";
        item4  = "increases the players health to a maximum and give player strength and speed";
        item5 = "increases the players defense by a small value";
        item6 = "increases the players defense by a good value";
        item7 = "increases the players luck by a small value";
        item8 = "increases the players attack by a small value";
        item9 = "increases the players speed by a small value";
        item10 = "increases the players health by 1";
        item11 = "increases the players attack by good value";

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
    public void Itxt2()
    {
        value.text = item2;
    }
    public void Itxt3()
    {
        value.text = item3;
    }
    public void Itxt4()
    {
        value.text = item4;
    }
    public void Itxt5()
    {
        value.text = item5;
    }
    public void Itxt6()
    {
        value.text = item6;
    }
    public void Itxt7()
    {
        value.text = item7;
    }
    public void Itxt8()
    {
        value.text = item8;
    }
    public void Itxt9()
    {
        value.text = item9;
    }
    public void Itxt10()
    {
        value.text = item10;
    }
    public void Itxt11()
    {
        value.text = item11;
    }
}
