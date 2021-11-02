using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemyGFX : MonoBehaviour
{
    public AIPath aiPath;

    private void Start()
    {
        Physics.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>(), GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (aiPath.desiredVelocity.x >= 0.01f && this.CompareTag("GoblinEnemy"))
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
            this.GetComponent<Animator>().SetBool("isWalking", true);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f && this.CompareTag("GoblinEnemy"))
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
            this.GetComponent<Animator>().SetBool("isWalking", true);
        }
        else
        {
            this.GetComponent<Animator>().SetBool("isWalking", false);
        }
    }
}
