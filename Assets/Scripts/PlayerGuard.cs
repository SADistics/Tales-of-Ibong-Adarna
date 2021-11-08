using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGuard : MonoBehaviour
{
    public Stats Defense;
    public bool onGuard;
    public bool onHit;

    private float currCD;
    private float maxCD;
    private Image shieldCD;
    private GameObject shieldCont;

    private GameObject guardPrompt;
    private Animator weap;
    private GameObject pm;
    void Start()
    {
        onGuard = false;
        maxCD = 8f;
        currCD = 0;
        shieldCont = GameObject.Find("shieldCDContainer");
        shieldCD = GameObject.Find("ShieldImage").GetComponent<Image>();
        shieldCont.SetActive(false);
        guardPrompt = GameObject.Find("GuardModePrompt");
        guardPrompt.SetActive(false);
        weap = GameObject.Find("WeaponA").GetComponent<Animator>();
        pm = GameObject.Find("DonJuan");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            onGuard = true;
            weap.SetBool("OnGuard", true);
            guardPrompt.SetActive(true);
        }
        else if (Input.GetMouseButtonUp(1))
        {
            onGuard = false;
            weap.SetBool("OnGuard", false);
            guardPrompt.SetActive(false);
        }

        if (onHit && onGuard || onHit && !onGuard)
        {
            shieldCont.SetActive(true);
            if (currCD < maxCD)
            {
                currCD += Time.deltaTime;
                shieldCD.fillAmount = currCD / maxCD;
            }
            else
            {
                onHit = false;
                currCD = 0;
                shieldCont.SetActive(false);
            }
        }
    }
}
