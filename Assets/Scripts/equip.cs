using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class equip : MonoBehaviour
{
    public bool isequiped;
    public int weapondamage;
    private int success;
    public static int weapondmg;
    public Image img;
    public static bool equiped;
    public GameObject altsword1;
    public GameObject altsword2;
    public GameObject altsword3;
    public GameObject altbow;


    public GameObject thissword;

    private equip sword1;
    private equip sword2;
    private equip sword3;
    private equip bow;


    // Start is called before the first frame update
    void Start()
    {
        weapondamage += weapondmg;
        isequiped = equiped;
        sword1 = altsword1.GetComponent<equip>();
        sword2 = altsword2.GetComponent<equip>();
        sword3 = altsword3.GetComponent<equip>();
        bow = altbow.GetComponent<equip>();



    }

    // Update is called once per frame
    void Update()
    {
        if (isequiped == true)
            img.enabled = true;
        else
            img.enabled = false; 
    }

    public void requip()
    {
        sword1.isequiped = false;
        sword2.isequiped = false;
        sword3.isequiped = false;
        bow.isequiped = false;

        isequiped = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>().damage = weapondamage;
    }

    public void upgradeweapon()
    {
        weapondamage += 5;
        weapondmg = weapondamage;
    }
}
