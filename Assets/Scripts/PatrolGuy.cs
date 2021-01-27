using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PatrolGuy : MonoBehaviour
{
    public float speed;
    public int damage = 20;
    private float timer;
    public float walkTime;
    private bool walkRight = true;
    public float health;
    public GameObject drop;
    private Rigidbody2D rig;
    private Animator anim;
 
    
 

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= walkTime)
        {
            walkRight = !walkRight;
            timer = 0f;


        }
        if(walkRight)
        {
            rig.velocity = Vector2.right * speed;
            transform.eulerAngles = new Vector2(0, 180);
        }
        else
        {
            rig.velocity = Vector2.left * speed;
            transform.eulerAngles = new Vector2(0, 0);
        }

        

    }
    public void Damage(float dmgObj)
    {
        health -= (dmgObj);
        anim.SetTrigger("Hit");
        
        if(health <= 0)
        {
            
            Destroy(this.gameObject);
            GameObject Drop = Instantiate(drop, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().Damage(damage);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerJumpKill")
        {

            Destroy(gameObject);
            Player player = FindObjectOfType<Player>();
            Rigidbody2D rig = player.getRig();
            rig.AddForce(new Vector2(0f, 20f), ForceMode2D.Impulse);


        }
    }
}
