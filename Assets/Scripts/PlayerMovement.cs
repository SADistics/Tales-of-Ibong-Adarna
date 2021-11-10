using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VIDE_Data;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    public GameObject weap;
    [SerializeField]public float speed;
    public Stats Agility;

    float xMove,xPos,zMove, distToGround;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        speed = Agility.GetStats();
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    void Update()
    {
        if (!VD.isActive && !GetComponent<PlayerHealth>().isDead)
        {
            Movement();
            rb.velocity = new Vector3(xMove, rb.velocity.y, zMove);
        }
    }

    private void Movement()
    {
        //Horizontal
        if (Input.GetKey(KeyCode.A))
        {
            xMove = 1*-speed;
            anim.SetFloat("Xpos", -1);
            anim.SetBool("IsMove", true);
            weap.GetComponent<Animator>().SetBool("isLeft",true);
            xPos = -1f;
            GetComponent<SpriteRenderer>().flipX = true;
            weap.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            xMove = 0;
            anim.SetBool("IsMove", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            xMove = 1*speed;
            anim.SetFloat("Xpos", 1);
            anim.SetBool("IsMove", true);
            weap.GetComponent<Animator>().SetBool("isLeft", false);
            xPos = 1f;
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            xMove = 0;
            anim.SetBool("IsMove", false);
        }

        //Vertical
        if (Input.GetKey(KeyCode.S))
        {
            zMove = 1*-speed;
            anim.SetFloat("Xpos", -1);
            anim.SetBool("IsMove", true);
            xPos = -1f;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            zMove = 0;
            anim.SetBool("IsMove", false);
        }

        if (Input.GetKey(KeyCode.W))
        {
            zMove = 1*speed;
            anim.SetFloat("Xpos", 1);
            anim.SetBool("IsMove",true);
            xPos = 1f;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            zMove = 0;
            anim.SetBool("IsMove", false);
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
}
