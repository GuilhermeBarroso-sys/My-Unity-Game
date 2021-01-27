using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    private Rigidbody2D rig;
    public float speed;
    public float damage = 20f;
    public bool isRight;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 1.8f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isRight)
        {
            rig.velocity = Vector2.right * speed;
        }
        else
        {
            rig.velocity = Vector2.left * speed;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<PatrolGuy>().Damage(damage);
            Destroy(gameObject);
            
        }
    }
}
