using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AttackState : State
{
    //Class
    public ChaseState chaseState;
    public AIPath aiPath;
    public Animator enemyAnim;

    //DelayTime
    private float waitTime;
    public float startWaitTime;
    public bool isAttacked;

    //Knockback
    public float thrust;
    public Rigidbody player;
    public float knockTime;

    private void Start()
    {
        waitTime = startWaitTime;
    }

    public override State RunCurrentState()
    {
        if (chaseState.isinAttackRange)
        {
            aiPath.canMove = false;
            if (!isAttacked)
            {
                //enemyAnim.SetTrigger("EnemyAttack");
                enemyAnim.SetBool("isAttacked", true);
                enemyAnim.SetBool("isWalking", false);
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
                    isAttacked = false;
                    enemyAnim.SetBool("isAttacked", false);
                    enemyAnim.SetBool("isWalking", true);
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
