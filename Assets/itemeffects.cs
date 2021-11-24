using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemeffects : MonoBehaviour
{
    private PlayerHealth playerHealth;
    public Rigidbody player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
   public void HPPotion()
    {
        playerHealth.curHP = playerHealth.maxHP;
    }
}
