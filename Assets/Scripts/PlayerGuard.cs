using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGuard : MonoBehaviour
{
    public float Defense;
    public bool onGuard;
    public bool onHit;

    private float currCD;
    private float maxCD;
    private Image shieldCD;
    private GameObject shieldCont;

    private GameObject guardPrompt;
    private Animator weap;
    private GameObject pm;
    AudioSource audioSource;
    public AudioClip audioClip;
    bool isPlayed;

    public QTESys QTR;
    private bool isQTE;
    float chance;
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
        QTR = GameObject.Find("QTESys").GetComponent<QTESys>();
        Defense = GetComponentInChildren<permstatdef>().defstat;
        audioSource = GetComponent<AudioSource>();
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
            if (!isQTE)
            {
                QTECheck();
            }
            if (!isPlayed)
            {
                audioSource.PlayOneShot(audioClip);
                isPlayed = true;
            }
                
            shieldCont.SetActive(true);
            if (currCD < maxCD)
            {
                currCD += Time.deltaTime;
                shieldCD.fillAmount = currCD / maxCD;
            }
            else
            {
                isPlayed = false;
                onHit = false;
                currCD = 0;
                shieldCont.SetActive(false);
            }
        }
        else if (!onHit)
        {
            isQTE = false;
        }
    }

    private void QTECheck()
    {
        chance = UnityEngine.Random.Range(1, 100);
        chance = (chance / 100);
        var text = chance.ToString();
        if (chance <= 0.20f)
        {
            QTR.QTRSTART = true;
            isQTE = true;
        }
        else
        {
            QTR.QTRSTART = false;
            isQTE = true;
        }
    }
}
