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
    float chance;

    #region UndeadStats
    bool isSlowed;
    public bool isPoisoned;
    #endregion

    #region GoblinStats
    bool isConfused;
    #endregion

    #region GhostStats
    bool isWeaken;
    #endregion

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
                Debuff();

                if (playerGuard.onGuard && !playerGuard.onHit)
                {
                    playerGuard.onHit = true;
                }
                else if (playerGuard.onHit && playerGuard.onGuard)
                {
                    GetComponent<AudioSource>().Play();
                    playerHealth.curHP = (playerHealth.curHP + playerGuard.Defense) - enemyStats.GetEnemyStrength();
                    playerHealth.SetHealthBarValue(playerHealth.curHP);
                    playerObject.GetComponent<Animator>().SetTrigger("onHit");
                }
                else
                {
                    GetComponent<AudioSource>().Play();
                    playerHealth.curHP = (playerHealth.curHP + playerGuard.Defense) - enemyStats.GetEnemyStrength();
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

    private void Debuff()
    {
        if (enemyStats.type == "Undead" && !isSlowed && !playerHealth.isPoisoned)
        {
            chance = UnityEngine.Random.Range(1, 10);
            chance = chance / 10;
            //StartCoroutine(Poison());
            if (chance <= 0.60f && chance > 0.30f && !isSlowed)
            {
                isSlowed = true;
                StartCoroutine(Slowed());
            }
            else if (chance <= 0.30f && chance > 0.20f && !playerHealth.isPoisoned)
            {
                playerHealth.isPoisoned = true;
                StartCoroutine(Poison());
            }
        }
        if(enemyStats.type == "Goblin" && !isConfused)
        {
            chance = UnityEngine.Random.Range(1, 10);
            chance = chance / 10;
            //StartCoroutine(Confused());
            if (chance <= 0.20f)
            {
                isConfused = true;
                StartCoroutine(Confused());
            }
        }
        if(enemyStats.type == "Ghost" && !isWeaken && !playerObject.GetComponent<PlayerAttack>().isBlinded)
        {
            chance = UnityEngine.Random.Range(1, 10);
            chance = chance / 10;
            if (chance <= 0.60f && chance > 0.30f && !isWeaken)
            {
                isWeaken = true;
                StartCoroutine(Weaken());
            }
            else if (chance <= 0.30f && chance > 0.20f && !playerObject.GetComponent<PlayerAttack>().isBlinded)
            {
                playerObject.GetComponent<PlayerAttack>().isBlinded = true;
                StartCoroutine(Blind());
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

    private IEnumerator Slowed()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().color = Color.gray;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().speed -= 3;
        yield return new WaitForSeconds(5f);
        isSlowed = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().speed += 3;
        GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().color = Color.white;
    }

    private IEnumerator Confused()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().color = Color.yellow;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().multiplier = -1;
        yield return new WaitForSeconds(5f);
        isConfused = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().multiplier = 1;
        GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().color = Color.white;
    }

    private IEnumerator Weaken()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().color = Color.green;
        playerGuard.Defense -= 5;
        yield return new WaitForSeconds(5f);
        isWeaken = false;
        playerGuard.Defense += 5;
        playerObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    private IEnumerator Poison()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().color = new Color(77, 0, 92);
        yield return new WaitForSeconds(5f);
        playerHealth.isPoisoned = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().color = Color.white;
    }

    private IEnumerator Blind()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().color = Color.black;
        yield return new WaitForSeconds(5f);
        playerObject.GetComponent<PlayerAttack>().isBlinded= false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().color = Color.white;
    }
}
