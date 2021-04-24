using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(CircleCollider2D))]
public class Money : MonoBehaviour
{
    public int value; //money value

    private MoneyManager manager;


    // Start is called before the first frame update
    void Start()
    {

        manager = FindObjectOfType<MoneyManager>(); 


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player")) //if player triggered the coin call MoneyManager
        {
            manager.AddMoney(value);
            Destroy(gameObject); //destroy the coin so that can only be picked once
        }
    }



}

