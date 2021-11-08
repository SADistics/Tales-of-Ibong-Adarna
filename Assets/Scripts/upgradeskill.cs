using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class upgradeskill : MonoBehaviour
{

    public Text val;
    public int slvl;
    public static int lvl;
    public GameObject points;
    private skillavailablepoints AV;
    // Start is called before the first frame update
    void Start()
    {
        val = GetComponent<Text>();
        AV = points.GetComponent<skillavailablepoints>();
    }

    // Update is called once per frame
    void Update()
    {
        lvl = slvl;
        val.text = lvl.ToString();
    }

    public void upgradeskilllvl()
    {
        if (AV.sstat > 0)
        {
            slvl++;
            AV.sstat--;
        }
    }
}
