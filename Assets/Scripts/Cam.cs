using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Cam : MonoBehaviour
{
    private Transform player;
    public float smooth;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;    
    }

    
    void LateUpdate()
    {
      
            Vector3 following = new Vector3(player.position.x, transform.position.y, transform.position.z);
        if (player.position.x > -2.14 && player.position.x < 46.99)
        {
            transform.position = Vector3.Lerp(transform.position, following, smooth * Time.deltaTime);
        }
       
    }
}
