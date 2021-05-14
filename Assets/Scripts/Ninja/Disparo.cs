using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disparo : MonoBehaviour
{
    public float velocidad = 10f;
    private Rigidbody2D rb;

    public GameObject player;
    private Transform playerTransform;
    
    
   
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject,3f);
        player = GameObject.FindGameObjectWithTag("ninja");
        playerTransform = player.transform;
        if (playerTransform.localScale.x>0)
        {
            rb.velocity = new Vector2(velocidad, rb.velocity.y);
            transform.localScale = new Vector3(0.11501f,0.125388f,1);
        }
        else
        {
            rb.velocity = new Vector2(-velocidad, rb.velocity.y);
            transform.localScale = new Vector3(-0.11501f,0.125388f,1);
        }

    }
    

    // Update is called once per frame
    void Update()
    {
        

    }

}
