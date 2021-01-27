using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Coin : MonoBehaviour
{
    
    public int coinAmount;
   
   
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameController.instance.UpdateCoins(coinAmount);
            Destroy(gameObject);
        }
    }
}
