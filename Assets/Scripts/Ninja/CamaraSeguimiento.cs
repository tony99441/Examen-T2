using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraSeguimiento : MonoBehaviour
{
    public GameObject player;
   // private Transform transform;
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        var x = player.transform.position.x + 5;
        var y = player.transform.position.y + 1;
        transform.position = new Vector3(x, y, transform.position.z); 
        
    }
}