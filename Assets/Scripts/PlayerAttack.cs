using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    #region Stats
    public float Strength;
    public float Luck;
    private Animator anim;
    #endregion

    #region EnemyAttrib
    private Rigidbody enemy;
    private bool isinRange;
    private GameObject enem;
    private EnemyStats enemStats;
    #endregion

    #region WeaponCheck
    public bool isBow;
    public bool isBronze, isSilver, isBlood;
    public GameObject currWeap;
    #endregion

    #region Knockback
    public float thrust;
    public float damage;
    #endregion

    #region SkillCheck
    bool skill1Ready, skill1Attack;
    bool skill2Ready, skill2Attack;
    public Image skillImage1;
    public Image skillImage2;
    private float currentCoolDown, currentCoolDown2;
    public float skillCoolDown, skillCoolDown2;
    #endregion

    #region Attack Delay
    private bool isAttack;
    #endregion

    #region Animators
    public Animator weaponAnim;
    #endregion

    #region Quick Time Event
    public QTESys QTR;
    #endregion

    #region AudioSFX
    public AudioClip[] audioClips;
    AudioSource audioSource;
    #endregion

    #region Debuff
    public bool isBlinded;
    #endregion

    float random;

    void Start()
    {
        skillCoolDown = 5f;
        skillCoolDown2 = 10f;
        isAttack = false;
        anim = GetComponent<Animator>();
        weaponAnim = GameObject.Find("WeaponA").GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        skill1Ready = true; skill2Ready = true;
        if (isBow)
        {
            thrust = 5;
            skillImage1 = GameObject.Find("Archer1").GetComponent<Image>();
            skillImage2 = GameObject.Find("Archer2").GetComponent<Image>();
            GameObject.Find("Warrior1").SetActive(false);
            GameObject.Find("Warrior2").SetActive(false);
        }
        else
        {
            thrust = 5;
            skillImage1 = GameObject.Find("Warrior1").GetComponent<Image>();
            skillImage2 = GameObject.Find("Warrior2").GetComponent<Image>();
            GameObject.Find("Archer1").SetActive(false);
            GameObject.Find("Archer2").SetActive(false);
        }
        QTR = GameObject.Find("QTESys").GetComponent<QTESys>();
        #region Check Weapon Quality
        /*if (isSilver)
        {
            currWeap = GameObject.Find("WeaponA");
            currWeap.SetActive(false);
            GameObject.Find("WeaponB").SetActive(false);
            GameObject.Find("WeaponC").SetActive(false);
        }else if (isBronze)
        {
            currWeap = GameObject.Find("WeaponB");
            currWeap.SetActive(false);
            GameObject.Find("WeaponA").SetActive(false);
            GameObject.Find("WeaponC").SetActive(false);
        }else if (isBlood)
        {
            currWeap = GameObject.Find("WeaponC");
            currWeap.SetActive(false);
            GameObject.Find("WeaponA").SetActive(false);
            GameObject.Find("WeaponB").SetActive(false);
        }*/
        #endregion
    }

    void Update()
    {
        Strength = GetComponentInChildren<permstatstr>().get();
        Luck = GetComponentInChildren<permstatluck>().get();
        if (Input.GetButtonDown("Fire1")&&!isAttack)
        {
            StartCoroutine(AttackCo()); //Animation
            if (isinRange)
            {
                if (enemy != null)
                {
                    if(!isBow)
                        audioSource.PlayOneShot(audioClips[1]);
                    StartCoroutine(KnockCo(enemy));
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //Skill 1
            if (skill1Ready)
            {
                StartCoroutine(Skill1At());
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Skill 2
            if (skill2Ready)
            {
                StartCoroutine(Skill2At());
                audioSource.PlayOneShot(audioClips[0]);
                if (enemy != null)
                {
                    if (!isBow)
                        audioSource.PlayOneShot(audioClips[1]);
                    StartCoroutine(SkillKnockCo(enemy));
                }
            }
        }
        if (QTR.correctKey == 1 && !isAttack)
        {
            StartCoroutine(AttackCo2());
            audioSource.PlayOneShot(audioClips[0]);
            if (isinRange)
            {
                if (enemy != null)
                {
                    if (!isBow)
                        audioSource.PlayOneShot(audioClips[1]);
                    StartCoroutine(KnockCo(enemy));
                }
            }
        }

        if (enem == null && !GetComponent<PlayerHealth>().isDead)
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }

        if (!skill1Ready)
        {
            if (currentCoolDown < skillCoolDown)
            {
                currentCoolDown += Time.deltaTime;
                skillImage1.fillAmount = currentCoolDown / skillCoolDown;
            }
            else
            {
                skill1Ready = true;
            }
        }
        if (!skill2Ready)
        {
            if (currentCoolDown2 < skillCoolDown2)
            {
                currentCoolDown2 += Time.deltaTime;
                skillImage2.fillAmount = currentCoolDown2 / skillCoolDown2;
            }
            else
            {
                skill2Ready = true;
            }
        }
    }
    public void adddamage(float x)
    {
        Luck += x;
    }

    #region IEnumerators
    public IEnumerator AttackCo()
    {
        isAttack = true;
        anim.SetBool("attacking", true);
        weaponAnim.SetTrigger("Attack");
        yield return null;
        audioSource.PlayOneShot(audioClips[0]);
        anim.SetBool("attacking", false);
        if (enemy != null && !isBlinded)
        {
            random = UnityEngine.Random.Range(1, 99);
            if(random < Luck && enemStats.GetHealth() > 0)
            {
                enemStats.Health -=((Strength+thrust)*1.5f);
            }
            if (enemStats.GetHealth() > 0)
            {
                damage = damage + ((Strength + thrust) - enemStats.GetEnemyDefense());
                if (damage >= 0)
                {
                    enemStats.Health -= damage;
                }
                else
                {
                    enemStats.Health -= 1;
                }
            }                
            else
            {
                enemStats.Health -= 0;
            }
        }
        yield return new WaitForSeconds(1);
        isAttack = false;
    }
    public IEnumerator AttackCo2()
    {
        isAttack = true;
        anim.SetBool("attacking", true);
        weaponAnim.SetTrigger("Attack");
        yield return null;
        anim.SetBool("attacking", false);
        if (enemy != null)
        {
            if (enemStats.GetHealth() > 0)
                enemStats.Health -= ((Strength + thrust + 50) - enemStats.GetEnemyDefense());
            else
            {
                enemStats.Health -= 0;
            }
        }
        yield return new WaitForSeconds(1);
        isAttack = false;
    }
    private IEnumerator KnockCo(Rigidbody enemy)
    {
        Vector3 forceDirection = enemy.transform.position - transform.position;
        Vector3 force = forceDirection.normalized * thrust;
        enemy.velocity = force;
        yield return new WaitForSeconds(3f);
        enemy.velocity = new Vector3();
    }
    private IEnumerator Skill1At()
    {
        currentCoolDown = 0;
        GetComponent<PlayerMovement>().speed += 5;
        yield return null;
        skill1Ready = false;
        /*if (enemy != null)
        {
            if (enemStats.GetHealth() > 0)
            {
                enemStats.Health -= ((Strength + 10) - enemStats.GetEnemyDefense());
            }
            else
            {
                enemStats.Health -= 0;
            }
        }*/
        yield return new WaitForSeconds(2f);
        GetComponent<PlayerMovement>().speed -= 5;
    }
    private IEnumerator Skill2At()
    {
        currentCoolDown2 = 0;
        anim.SetBool("skill2AT", true);
        weaponAnim.SetTrigger("skill2AT");
        yield return null;
        anim.SetBool("skill2AT", false);
        skill2Ready = false;
        if (enemy != null && !isBlinded)
        {
            if (enemStats.GetHealth() > 0)
            {
                enemStats.Health -= ((Strength + 15) - enemStats.GetEnemyDefense());
            }
            else
            {
                enemStats.Health -= 0;
            }
        }
        yield return new WaitForSeconds(.33f);
    }
    private IEnumerator SkillKnockCo(Rigidbody enemy)
    {
        Vector3 forceDirection = enemy.transform.localPosition - transform.position;
        Vector3 force = forceDirection.normalized * (thrust + 10);
        enemy.velocity = force;
        yield return new WaitForSeconds(3f);
    }
    #endregion

    #region Triggers
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
    private void OnTriggerStay(Collider other)
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
    #endregion
}
