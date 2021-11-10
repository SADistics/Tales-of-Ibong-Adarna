using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Stats Health;
    public static Image HealthBarImage;
    public bool isDead;
    public float curHP;
    private float maxHP;
    Animator animator;
    public bool isSpotted;

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
        maxHP = Health.GetStats();
        curHP = maxHP;
        animator = GetComponent<Animator>();
        isDead = false;
    }

    private void Update()
    {
        if (!isDead)
            HealthCheck();
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
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
    }
}
