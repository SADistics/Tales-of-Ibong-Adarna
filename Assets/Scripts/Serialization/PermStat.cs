using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermStat : MonoBehaviour
{
    public int agi;
    public int def;
    public int dex;
    public int inte;
    public int luck;
    public int str;

    public void Update()
    {
        agi = GetComponent<permstatagi>().get();
        def = GetComponent<permstatdef>().get();
        dex = GetComponent<permstatdex>().get();
        inte = GetComponent<permstatint>().get();
        luck = GetComponent<permstatluck>().get();
        str = GetComponent<permstatstr>().get();
    }
}
