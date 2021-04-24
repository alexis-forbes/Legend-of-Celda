using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 


public class MoneyManager : MonoBehaviour
{
    public int currentMoney;
    public Text moneyText;


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Money")) //if playerPrefs finds saved money, there has been a previous session
        {
            currentMoney = PlayerPrefs.GetInt("Money"); //recover the money on earlier session
        }
        else
        {
            currentMoney = 0; //no money in the start of session
            PlayerPrefs.SetInt("Money", 0); //start saving the money
        }

        moneyText.text = currentMoney.ToString(); //paint in screen the current money


    }

   
    public void AddMoney(int moneyCollected)
    {
        currentMoney += moneyCollected;
        moneyText.text = currentMoney.ToString();

        //playerPrefs to save parameters --> each time get coin it saves in this file
        PlayerPrefs.SetInt("Money", currentMoney); //key = money and save value currentMoney
    }








}
