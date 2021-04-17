using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [Tooltip("Cantidad de daño que hará la espalda")]
    public int damage;

    public GameObject bloodAnim;
    public GameObject canvasDamage; 
    private GameObject hitPoint;

    private void Start()
    {
        hitPoint = transform.Find("HitPoint").gameObject; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
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
