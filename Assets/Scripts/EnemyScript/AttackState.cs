using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class AttackState : State
{
    //Class
    public ChaseState chaseState;
    public AIPath aiPath;
    public Animator enemyAnim;
    public EnemyStats enemyStats;

    //DelayTime
    private float waitTime;
    public float startWaitTime;
    public bool isAttacked;

    //Knockback
    public float thrust;
    public Rigidbody player;
    private PlayerGuard playerGuard;
    private PlayerHealth playerHealth;
    private GameObject playerObject;
    public float knockTime;

    private void Start()
    {
        waitTime = startWaitTime;
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            playerObject = GameObject.FindGameObjectWithTag("Player");
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
            playerGuard = player.GetComponent<PlayerGuard>();
            playerHealth = player.GetComponent<PlayerHealth>();
        }
    }

    public override State RunCurrentState()
    {
        if (chaseState.isinAttackRange)
        {
            aiPath.canMove = false;
            if (!isAttacked && !playerHealth.isDead)
            {
                enemyAnim.SetBool("isAttacked", true);
                enemyAnim.SetBool("isWalking", false);
                if(playerGuard.onGuard && !playerGuard.onHit)
                {
                    playerGuard.onHit = true;
                }
                else if (playerGuard.onHit && playerGuard.onGuard)
                {
                    playerHealth.curHP = (playerHealth.curHP + playerGuard.Defense.GetStats()) - enemyStats.GetEnemyStrength();
                    playerHealth.SetHealthBarValue(playerHealth.curHP);
                    playerObject.GetComponent<Animator>().SetTrigger("onHit");
                }
                else
                {
                    playerHealth.curHP = (playerHealth.curHP + playerGuard.Defense.GetStats()) - enemyStats.GetEnemyStrength();
                    playerHealth.SetHealthBarValue(playerHealth.curHP);
                    playerObject.GetComponent<Animator>().SetTrigger("onHit");
                }
                Vector3 difference = player.transform.position - transform.position;
                difference = difference.normalized * thrust;
                player.AddForce(difference, ForceMode.Impulse);
                StartCoroutine(KnockCo(player));
                isAttacked = true;
                return this;
            }
            else
            {
                player.isKinematic = false;
                if (waitTime <= 0 && isAttacked)
                {
                    waitTime = startWaitTime;
                    enemyAnim.SetBool("isAttacked", false);
                    enemyAnim.SetBool("isWalking", true);
                    isAttacked = false;
                    return this;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                    return this;
                }
            }
        }
        else
        {
            player.isKinematic = false;
            if (waitTime <= 0 && isAttacked)
            {
                aiPath.canMove = true;
                isAttacked = false;
                waitTime = startWaitTime;
                enemyAnim.SetBool("isAttacked", false);
                
                return chaseState;
            }
            else
            {
                waitTime -= Time.deltaTime;
                enemyAnim.SetBool("isWalking", false);
                return this;
            }
        }
    }


    private IEnumerator KnockCo(Rigidbody player)
    {
        if(player != null)
        {
            yield return new WaitForSeconds(knockTime);
            player.velocity = Vector3.zero;
            player.isKinematic = true;
        }
    }
}
