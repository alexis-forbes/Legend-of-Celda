using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    /*[Tooltip("Tiempo que tarda el jugador en poder revivir")]
    public float timeToRevivePlayer;
    private float timeRevivalCounter;
    private bool playerReviving;
    */

    /*
    public int damage; 

    private GameObject thePlayer; //referenciamos el objeto a revivir dentro de la colision

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player")) //if collision against Player exists
        {
            collision.gameObject.GetComponent<HealthManager>().DamageCharacter(damage); 
        }
    }




    // Update is called once per frame
    void Update()
    {

        if (playerReviving) //if player is reviving
        {
            timeRevivalCounter -= Time.deltaTime; //discount time of revival
            if(timeRevivalCounter < 0){ //se acaba la cuenta atras
                playerReviving = false; // when its negative, it is no longer reviving
                thePlayer.SetActive(true); //we activate Player
            }
        }





    }
    */
}
