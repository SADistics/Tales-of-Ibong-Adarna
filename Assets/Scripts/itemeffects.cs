using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemeffects : MonoBehaviour
{
    private PlayerHealth playerHealth;
    public Rigidbody player;
    public bool isselect = false;
    public bool used = false;
    private bool healthpotactivated = false;
    private bool goodhealthpotactivated = false;
    private bool greathealthpotactivated = false;
    private bool mythicalpotacivated = false;
    private bool undurancepotactivated = false;
    private bool ironskinpotactivated = false;
    private bool luckpotactivated = false;
    private bool angerpotactivated = false;
    private bool wrathpotactivated = false;
    private bool kalamansiactivated = false;
    private bool speedactivated = false;

    private IEnumerator coroutine;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        playerHealth = player.GetComponent<PlayerHealth>();
        coroutine = ItemCD();
    }

    // Update is called once per frame
    public void HPPotion()
    {
        if (isselect && !used)
        {
            healthpotactivated = true;
            playerHealth.curHP += (playerHealth.maxHP - playerHealth.curHP) * .1f;
            StartCoroutine(coroutine);
        }
    }
    public void GoodHPPotion()
    {
        if (isselect && !used)
        {
            goodhealthpotactivated = true;
            playerHealth.curHP += (playerHealth.maxHP - playerHealth.curHP) * .5f;
            StartCoroutine(coroutine);
        }
    }
    public void GreaterHPPotion()
    {
        if (isselect && !used)
        {
            greathealthpotactivated = true;
            playerHealth.curHP += playerHealth.maxHP - playerHealth.curHP;
            StartCoroutine(coroutine);
            
        }
    }
    public void MythicalBrew()
    {
        if (isselect && !used)
        {
            mythicalpotacivated = true;
            playerHealth.curHP = playerHealth.maxHP;
            player.GetComponent<PlayerAttack>().damage += player.GetComponent<PlayerAttack>().damage * .1f;
            player.GetComponent<PlayerMovement>().speed += 5;
            StartCoroutine(coroutine);
          
        }
    }
    public void EndurancePotion()
    {
        if (isselect && !used)
        {
            undurancepotactivated = true;
            player.GetComponent<PlayerGuard>().Defense += player.GetComponent<PlayerGuard>().Defense * .1f;
            StartCoroutine(coroutine);
          
        }
    }
    public void IronSkinPotion()
    {
        if (isselect && !used)
        {
            ironskinpotactivated = true;
            player.GetComponent<PlayerGuard>().Defense += 8;
            StartCoroutine(coroutine);
            
        }
    }
    public void LuckPotion()
    {
        if (isselect && !used)
        {
            luckpotactivated = true;
            player.GetComponentInChildren<permstatluck>().setperm(player.GetComponentInChildren<permstatluck>().get() +5);
            StartCoroutine(coroutine);
            
        }

    }
    public void AngerPotion()
    {
        if (isselect && !used)
        {
            angerpotactivated = true;
            player.GetComponentInChildren<permstatluck>().setperm(player.GetComponentInChildren<permstatluck>().get() + 10);
            StartCoroutine(coroutine);
            
        }
    }
    public void SpeedPotion()
    {
        if (isselect && !used)
        {
            speedactivated = true;
            player.GetComponent<PlayerMovement>().speed += 5;
            StartCoroutine(coroutine);
            


        }
        
    }
    public void WrathPotion()
    {
        if (isselect && !used)
        {
            wrathpotactivated = true;
            player.GetComponent<PlayerAttack>().damage += player.GetComponent<PlayerAttack>().damage * .1f;
            StartCoroutine(coroutine);
           
        }
    }
    public void Kalamansi()
    {
        if (isselect && !used)
        {
            if (playerHealth.curHP != playerHealth.maxHP)
            {
                kalamansiactivated = true;
                playerHealth.curHP += 1;
                StartCoroutine(coroutine);
            }
        }
    }

    public IEnumerator ItemCD()
    {
        used = true;
        yield return new WaitForSeconds(.5f);
        if(speedactivated == true)
        {
            player.GetComponent<PlayerMovement>().speed -= 5;
            speedactivated = false;
        }
        if(healthpotactivated == true)
        {
            healthpotactivated = false;
        }
        if(goodhealthpotactivated == true)
        {
            goodhealthpotactivated = false;
        }
        if(greathealthpotactivated == true)
        {
            greathealthpotactivated = false;
        }    
        if(mythicalpotacivated == true)
        {
            player.GetComponent<PlayerAttack>().damage -= player.GetComponent<PlayerAttack>().damage * .1f;
            player.GetComponent<PlayerMovement>().Agility -= 5;
            mythicalpotacivated = false;
        }
        if(undurancepotactivated == true)
        {
            player.GetComponent<PlayerGuard>().Defense -= player.GetComponent<PlayerGuard>().Defense * .1f;
            undurancepotactivated = false;
        }
        if(ironskinpotactivated == true)
        {
            player.GetComponent<PlayerGuard>().Defense -= 8;
            ironskinpotactivated = false;
        }
        if(luckpotactivated == true)
        {
            player.GetComponentInChildren<permstatluck>().setperm(player.GetComponentInChildren<permstatluck>().get()-10);
            luckpotactivated = false;
        }
        if (angerpotactivated == true)
        {
            player.GetComponentInChildren<permstatluck>().setperm(player.GetComponentInChildren<permstatluck>().get() - 10);
            angerpotactivated = false;
        }
        if(wrathpotactivated == true)
        {
            player.GetComponent<PlayerAttack>().damage -= player.GetComponent<PlayerAttack>().damage * .1f;
            wrathpotactivated = false;

        }
        if(kalamansiactivated == true)
        {
            kalamansiactivated = false;
        }
        used = false;
    }
    public void select()
    {
        isselect = true;
    }
    public void diselect()
    {
        isselect = false;
    }

    
}

