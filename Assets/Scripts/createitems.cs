using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createitems : MonoBehaviour
{
    public GameObject myPrefab;
    public GameObject newbutt;
    public GameObject parent;
    public static bool HasPotion = false;
    // Start is called before the first frame update
    public void createitem()
    {
        if (HasPotion == false)
        {
            newbutt = Instantiate(myPrefab);
            HasPotion = true;
        }
       
    }
    public void adopt()
    {
        newbutt.transform.parent = parent.transform;
    }
       
}
