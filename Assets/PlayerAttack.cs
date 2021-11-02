using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    #region Stats
    public Stats Strength;
    private Animator anim;
    #endregion

    #region EnemyAttrib
    private Rigidbody enemy;
    private bool isinRange;
    private GameObject enem;
    private EnemyStats enemStats;
    #endregion

    #region WeaponCheck
    private bool isSword;
    #endregion

    #region Knockback
    public float thrust;
    #endregion
    void Start()
    {
        anim = GetComponent<Animator>();
        if (isSword)
        {
            thrust = 5;
        }
        else
        {
            thrust = 3;
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(AttackCo()); //Animation
            if (isinRange)
            {
                if (enemy != null)
                {
                    StartCoroutine(KnockCo(enemy));
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Skill 1
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //Skill 2
        }

        if (enem == null)
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("GoblinEnemy"))
        {
            enem = other.gameObject;
            enemy = other.GetComponentInChildren<Rigidbody>();
            enemStats = other.GetComponentInChildren<EnemyStats>();
            isinRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("GoblinEnemy"))
        {
            isinRange = false;
            enemy = null;
            enem = null;
        }        
    }

    private IEnumerator AttackCo()
    {
        anim.SetBool("attacking", true);
        yield return null;
        anim.SetBool("attacking", false);
        yield return new WaitForSeconds(2f);
        if (enemStats.GetHealth() > 0)
            enemStats.Health -= Strength.GetStats();
        else
        {
            enemStats.Health -= 0;
        }
    }

    private IEnumerator AttackCDT()
    {
        yield return new WaitForSeconds(6f);
    }

    private IEnumerator KnockCo(Rigidbody enemy)
    {
        Vector3 forceDirection = enemy.transform.position - transform.position;
        Vector3 force = forceDirection.normalized * thrust;
        enemy.velocity = force;
        yield return new WaitForSeconds(3f);

        enemy.velocity = new Vector3();
    }
}
