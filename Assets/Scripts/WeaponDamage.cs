using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [Tooltip("Cantidad de daño que hará la espalda")]
    public int damage; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            collision.gameObject.GetComponent<HealthManager>().DamageCharacter(damage); 
        }
    }





}
