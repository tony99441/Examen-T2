using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escalera : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private NinjaConfigurations controller;

    public BoxCollider2D PlataformaSuelo;
    

    public bool OnLadder = false;
    public float ClimbSpeed;
    public float exitHop = 3f;
    
    public  
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        controller = GetComponent<NinjaConfigurations>();
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Escalera"))
        {
            if (Input.GetAxisRaw("vertical")!=0)
            {
                rb.velocity = new Vector2(rb.velocity.x,Input.GetAxisRaw("Vertical")*ClimbSpeed);
                rb.gravityScale = 0;
                OnLadder = true;
                PlataformaSuelo.enabled = false;
            }else if (Input.GetAxisRaw("Vertical") == 0)
            {
                rb.velocity =new Vector2(rb.velocity.x,0);
                
            }
        }
    }
}
