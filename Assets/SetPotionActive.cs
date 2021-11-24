using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPotionActive : MonoBehaviour
{
    public GameObject potion;

    public void SetP()
    {
        potion.SetActive(true);
    }
}
