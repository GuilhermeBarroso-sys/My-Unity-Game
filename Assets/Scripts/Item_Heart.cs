using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Heart : MonoBehaviour
{
    public float heartValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(collision.gameObject.GetComponent<Player>().health < 100)
            {
                collision.gameObject.GetComponent<Player>().IncreaseLife(heartValue);
                
                Destroy(gameObject);
            }
            
        }
    }
}
