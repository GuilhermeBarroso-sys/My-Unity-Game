using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text healthText;
    public Text coinText;
    public int totalCoin;
    public int coin;
    public static GameController instance;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        
    }

    void Start()
    {
        totalCoin = PlayerPrefs.GetInt("score");
        Debug.Log(PlayerPrefs.GetInt("score"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void UpdateLives(float value)
    {

        healthText.text = "x " + value.ToString();
    }
    public void UpdateCoins(int value)
    {
        coin += value;
        coinText.text = "x " + coin.ToString();
        PlayerPrefs.SetInt("score", coin+totalCoin);

        
    }
}
