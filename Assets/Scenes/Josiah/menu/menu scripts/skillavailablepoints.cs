using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class skillavailablepoints : MonoBehaviour
{
    public Text val;
    public int sstat;
    public static int asstat;
    // Start is called before the first frame update
    void Start()
    {
        sstat = 5;
        val = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        asstat = sstat;
        val.text = asstat.ToString();
    }

   
}
