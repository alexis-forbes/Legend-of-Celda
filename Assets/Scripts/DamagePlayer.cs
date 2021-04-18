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

    
    public int damage;
    public GameObject canvasDamage;

    private CharacterStats stats; 

    private GameObject thePlayer; //referenciamos el objeto a revivir dentro de la colision



    private void Start()
    {
        stats = GameObject.Find("Player").GetComponent<CharacterStats>(); 
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player")) //if collision against Player exists
        {
            int totalDamage = damage * (1- stats.defenseLevels[stats.level]/CharacterStats.MAX_STAT_VAL); //making account of defenseLevels
            totalDamage = Mathf.Clamp(totalDamage, 1, CharacterStats.MAX_HEALTH);

           
            if(Random.Range(0, CharacterStats.MAX_STAT_VAL) < stats.luckLevels[stats.level]) //if missProb is higher than the range then there is a miss
            {
                totalDamage = 0; 
            }
            /*
            if(totaldamage <0)
            {
                totaldamage = 0; 
            }
            */

            var clone = (GameObject)Instantiate(canvasDamage, collision.gameObject.transform.position, Quaternion.Euler(Vector3.zero)); //instantiate and display damage number
            clone.GetComponent<DamageNumber>().damagePoints = totalDamage; //ask component DamageNumber and indicate that damagePoints = damage the enemy does
            collision.gameObject.GetComponent<HealthManager>().DamageCharacter(totalDamage); // & take damage
        }
    }



    /*
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
