using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NinjaConfigurations : MonoBehaviour
{
   
    public float velocidadCorrer = 10;
    private Animator animator;
    private Rigidbody2D rb;
    public float fuerzaSalto = 10f;
    public Text Puntaje;

    private Transform tr;

    public bool UsuandoEscalera=false;
    
    public GameObject escalera;

    private int vidas = 0; 
    private SpriteRenderer sr;
    private const int Animacion_Quieto = 0;
    private const int Animacion_Correr = 1;
    private const int Animacion_Saltar = 2;
    private const int Animacion_Disparar = 3;
    private const int Animacion_Deslizarce = 4;
    private const int Animacion_Escalar = 5;
    private const int Animacion_Planear = 6;

    private int EstadoSalto = 0;
    private bool EstadoGanar = false;
    private bool EstadoSaltoDoble = false;
    private bool Subiendo = false;
    private Collider2D cl;

    public bool EstadoMuerte = false;
    
 
    public Transform BalaTransform;
    public GameObject bala;

    private int score = 0; 
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        tr = GetComponent<Transform>();
        cl = GetComponent<Collider2D>();
   

    }

    // Update is called once per frame
    void Update()
    {
        int contadorsalto = 0;      
        
        // Puntaje inicial 
        Puntaje.text = "Puntaje: "+ score;
        

        if (EstadoMuerte == false)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                MovimientoDerecha();
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                MovimientoIzquierda();
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && !EstadoSaltoDoble && !Subiendo)
            {
                Saltar();
            }
            else if (Input.GetKeyDown(KeyCode.X) )
            {

                Disparar();

            } 
            else if (tr.position.y>3)
            {
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    rb.gravityScale = 1;
                    CambiarAnimacion(Animacion_Planear);
                }
               

            }else if (Subiendo ==true)
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {


                    rb.gravityScale = 0;
                    rb.velocity = new Vector2(0, 8);
                    CambiarAnimacion(Animacion_Escalar);
                }
                else
                {
                    rb.velocity = new Vector2(0, 0);
                }
                
            }

            else
            {
                EstarQuieto();
            }
        }
        
        
        
    }
    private void CambiarAnimacion(int animation)
    {
        animator.SetInteger("Estado", animation);
    }

    private void Disparar()
    {
        CambiarAnimacion(Animacion_Disparar);
        Instantiate(bala, BalaTransform.position, Quaternion.identity);
        
    }

    private void Saltar()
    {
        
            rb.velocity = Vector2.up * fuerzaSalto;
            CambiarAnimacion(Animacion_Saltar);
            EstadoSalto++;
            if (EstadoSalto == 2)
            {
                EstadoSaltoDoble = true;
            }
            if (Input.GetKeyDown(KeyCode.X) )
            {

                Disparar();

            } 
       
    }

    private void MovimientoIzquierda()
    {
        tr.localScale = new Vector3(-0.53f,0.516f,1);
        rb.velocity = new Vector2(-velocidadCorrer, rb.velocity.y);
        CambiarAnimacion(Animacion_Correr);
        if (Input.GetKey(KeyCode.C))
        {
         
            CambiarAnimacion(Animacion_Deslizarce);
            
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && !EstadoSaltoDoble)
        {
            Saltar();
        }
        if (Input.GetKeyDown(KeyCode.X) )
        {

            Disparar();

        } 
    }

    private void MovimientoDerecha()
    {
        tr.localScale = new Vector3(0.53f,0.516f,1);
        rb.velocity = new Vector2(velocidadCorrer, rb.velocity.y);
        CambiarAnimacion(Animacion_Correr);
        if (Input.GetKey(KeyCode.C))
        {
            CambiarAnimacion(Animacion_Deslizarce);

        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && !EstadoSaltoDoble)
        {
            Saltar();
        }
        if (Input.GetKeyDown(KeyCode.X) )
        {

            Disparar();

        } 
    }

    private void EstarQuieto()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        CambiarAnimacion(Animacion_Quieto);
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        
        
        if (collision.gameObject.tag == "Muerte")
        {
            vidas++; 
            if (vidas == 3)
            {
                
                EstadoMuerte = true;
                vidas = 0; 
            }
        }


        
 
        // Para la muerte de 2 metros
        if (collision.gameObject.layer == 9)
        {
            Debug.Log("Haz muerto :( ");
        }
        
        


        if (collision.gameObject.tag == "Escalera" )
        {
            escalera.GetComponent<BoxCollider2D>().isTrigger = true;
            Subiendo = true;
            
        }else

        if(collision.gameObject.tag == "Suelo")
        {
            EstadoSaltoDoble = false;
            EstadoSalto = 0;
            Subiendo = false;
            escalera.GetComponent<BoxCollider2D>().isTrigger = false;
            rb.gravityScale = 5;

        }


    }

    public void IncrementoPuntaje()
    {
        score += 10; 
    }


}

