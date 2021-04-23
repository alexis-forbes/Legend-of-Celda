using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [Tooltip("Cantidad de daño que hará la espalda")]
    public int damage;


    public string weaponName; 


    public GameObject bloodAnim;
    public GameObject canvasDamage; 
    private GameObject hitPoint;

    private CharacterStats stats;






    private void Start()
    {
        hitPoint = transform.Find("HitPoint").gameObject;
        stats = GameObject.Find("Player").GetComponent<CharacterStats>(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            CharacterStats enemyStats = collision.gameObject.GetComponent<CharacterStats>();

            float plaFac = (1 + stats.strengthLevels[stats.level] / CharacterStats.MAX_STAT_VAL); 
            float eneFac = (1 - enemyStats.defenseLevels[enemyStats.level] / CharacterStats.MAX_STAT_VAL); 

            int totalDamage = (int)(damage * eneFac * plaFac); //hacemos daño con el arma + nivel del jugador
            if(Random.Range(0, CharacterStats.MAX_STAT_VAL) > stats.accuracyLevels[stats.level]) //if accuracy is higher than the range, then there is a miss it in lower in time
            {
                if (Random.Range(0, CharacterStats.MAX_STAT_VAL) < enemyStats.luckLevels[enemyStats.level])
                {
                    totalDamage = 0; //luck of enemy and maincharacter, the enemy will stop the critical damage
                }
                else
                {
                totalDamage *= 5; //critical damage because of my luck
                }
            }

            if(bloodAnim != null && hitPoint !=null)
            { 
                Destroy(Instantiate(bloodAnim, hitPoint.transform.position, hitPoint.transform.rotation), 0.5f); //destroy particles after 0.5f
            }


            var clone = (GameObject)Instantiate(canvasDamage, hitPoint.transform.position, Quaternion.Euler(Vector3.zero)); //text displays in hitpoint
            //quaterion.euler for rotation. Always vertical, this avoids rotation
            //vector3.zero for identity

            clone.GetComponent<DamageNumber>().damagePoints = damage; //acces component damagenumber to change the number of damage points depending on weapon damage

            collision.gameObject.GetComponent<HealthManager>().DamageCharacter(damage); 
        }
    }

   


}
