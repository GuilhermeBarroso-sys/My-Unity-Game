using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private bool isAtk;
    public bool jump;
    public bool doubleJump;
    public bool isDmg;
    public float health;
 
    public float speed;
    public float jumpForce;
    public int bulletsAmt;

    public GameObject arrow;
    public Transform firePoint;
    float movement;
    private Rigidbody2D rig;
    private Animator anim;
    
 
    void Start()
    {

        
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        GameController.instance.UpdateLives(health);
        
       

       



    }
    public Rigidbody2D getRig()
    {
        return rig;
    }

    private void FixedUpdate()
    {
        Move();
        
        
    }
    void Update()
    {   
        Atk();
        Jump();
        if (Input.GetKey(KeyCode.B))
        {
            Application.Quit();
        }
        GameOver();
        

    }
    
    
    void Atk()
    {
        StartCoroutine("Fire");
        
        
                
    }
    
    
  
  

    IEnumerator Fire()
    {
        movement = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (bulletsAmt > 0 )
            {
                
                isAtk = true;
                anim.SetInteger("Transition", 1);
                bulletsAmt--;
                GameObject Arrow = Instantiate(arrow, firePoint.position, firePoint.rotation);
                if (transform.rotation.y == 0)
                {
                    Arrow.GetComponent<Bow>().isRight = true;
                }
                if(transform.rotation.y ==  -180)
                {
                    Arrow.GetComponent<Bow>().isRight = false;
                }

                yield return new WaitForSeconds(0.2f);
                isAtk = false;
                anim.SetInteger("Transition", 0);
              

            }


        }
    }
        
    

    public void IncreaseLife(float value)
    {
        health += value;
        GameController.instance.UpdateLives(health);
        if (health > 100)
        {
            health = 100;
            GameController.instance.UpdateLives(health);

        }

            
        
        
        
    }
 
    void Move()
    {
        movement = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(movement * speed, rig.velocity.y);
        // --- * Run * ---
        if(movement > 0 && !jump && !isAtk)
        {
            
            transform.eulerAngles = new Vector3(0, 0, 0);
            anim.SetInteger("Transition", 3);
            



        }
        // --- * Run * ---
        else if (movement < 0 && !jump && !isAtk)
        {
            
            transform.eulerAngles = new Vector3(0, 180, 0);
            anim.SetInteger("Transition", 3);
            
        }
       
        // --- * Idle * ---
        if (movement == 0 && !jump && !isAtk && !isDmg)
        {
           
            anim.SetInteger("Transition", 0);
        }
       
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if (!jump)
            {
                jump = true;
                doubleJump = true;
                anim.SetInteger("Transition", 6);
                rig.AddForce(new Vector2(0, jumpForce * 1), ForceMode2D.Impulse);
            }

            else
            {
                if (doubleJump)
                    rig.AddForce(new Vector2(0, jumpForce * 1), ForceMode2D.Impulse);
                    doubleJump = false;

            }
                
            
            
        }
    }
    public void Impulse()
    {
        rig.AddForce(new Vector2(0, jumpForce * 3), ForceMode2D.Impulse);
    }
    public void Damage(int dmg)
    {
        health -= dmg;
        GameController.instance.UpdateLives(health);
        anim.SetTrigger("Hit");
        if (transform.rotation.y == 0)
        {
            transform.position += new Vector3(-0.5f, 0,0 );
            
        }
        if (transform.rotation.y == -180)
        {
            transform.position += new Vector3(0.5f, 0, 0);
        }


    }
    public void GameOver()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(1);
        }
            

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "OutMap")
        {
            health = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.layer != 7)
        {
            jump = false;
            
            

        }
        
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {

        

    }
}
