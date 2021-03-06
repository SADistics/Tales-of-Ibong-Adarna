using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PlayerHealth : MonoBehaviour
{
    public float Health;
    public static Image HealthBarImage;
    public bool isDead;
    public float curHP;
    public float maxHP;
    Animator animator;
    public bool isSpotted;
    public bool isPoisoned;

    public void SetHealthBarValue(float value)
    {
        HealthBarImage.fillAmount = value/maxHP;
        if (HealthBarImage.fillAmount < 0.2f)
        {
            SetHealthBarColor(Color.red);
        }
        else if (HealthBarImage.fillAmount < 0.4f)
        {
            SetHealthBarColor(Color.yellow);
        }
        else
        {
            SetHealthBarColor(Color.green);
        }
    }

    public void SetHealthBarColor(Color healthColor)
    {
        HealthBarImage.color = healthColor;
    }

    public static float GetHealthBarValue()
    {
        return HealthBarImage.fillAmount;
    }

    void Start()
    {
        HealthBarImage = GameObject.Find("HealthBarFiller").GetComponent<Image>();
        SetHealthBarValue(1);
        maxHP = Health+100;
        curHP = maxHP;
        animator = GetComponent<Animator>();
        isDead = false;
    }

    private void Update()
    {
        Health = GameObject.Find("PlayerStats").GetComponent<permstatdef>().get();
        if (!isDead)
            HealthCheck();
        if (isPoisoned)
        {
            curHP -= 0.1f;
            SetHealthBarValue(curHP);
        }
    }

    private void HealthCheck()
    {
        if (GetHealthBarValue() == 0f)
        {
            animator.SetBool("isDead", true);
            isDead = true;
            GetComponent<CapsuleCollider>().height = 0.2f;
            GetComponent<Transform>().position = new Vector3(
                GetComponent<Transform>().position.x,
                GetComponent<Transform>().position.y - 0.4f,
                GetComponent<Transform>().position.z
                );
            StartCoroutine(GameOverHead());
            
        }
    }

    private IEnumerator GameOverHead()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }
}
