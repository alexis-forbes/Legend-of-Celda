using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private List<GameObject> weapons;
    public int activeWeapon;

    public List<GameObject> GetAllWeapons()
    {
        return weapons; 
    }


    // Start is called before the first frame update
    void Start()
    {
        weapons = new List<GameObject>();
        foreach(Transform weapon in transform) //for each children of the GameObject weapon in transform
        {
            weapons.Add(weapon.gameObject); //creating a loop in transform we obtain the children of the GameObject specified
        }

        /* for(int i = 0; i< weapons.Count; i++) //if the [i] of the loop coincides with  ActiveWeapon, it has to be active, if not innactive
         {
             weapons[i].SetActive(i == activeWeapon); 
         }

         */




    }

    public void ChangeWeapon(int newWeapon)
    {
        weapons[activeWeapon].SetActive(false); //the weapon in position activeWeapon is deactivated in order to change weapon
        weapons[newWeapon].SetActive(true); //the new weapon selected in the position newWeapon is activated
        activeWeapon = newWeapon; //now the active weapon is the newWeapon selected

        FindObjectOfType<UIManager>().ChangeAvatarImage(weapons[activeWeapon].GetComponent<SpriteRenderer>().sprite); 
    }
}
