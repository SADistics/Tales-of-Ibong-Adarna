using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Testing : MonoBehaviour
{
    public TextElement value;
    public int stat;

    void Start()
    {
        value.text = GetComponent<TextField>().text;
    }

    void Update()
    {
        value.text = stat.ToString();
    }
    public void increment()
    {
        stat++;
    }

    public void decrement()
    {

        stat--;

    }

}

