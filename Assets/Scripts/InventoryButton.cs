using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class InventoryButton : MonoBehaviour
{
    public enum ItemType { WEAPON = 0, ITEM = 1, ARMOR = 2, RING = 3}; 
    public int itemIdx; //itemindex
    public ItemType type; 

    //now button has the info of the object associated to him


public void ActivateButton()
    {
        switch(type)
        {
            case ItemType.WEAPON:
                FindObjectOfType<WeaponManager>().ChangeWeapon(itemIdx); 
                break;
            case ItemType.ITEM:
                Debug.Log("En futuros DLCS....");
                break;
            case ItemType.ARMOR:
                Debug.Log("En futuros DLCS...");
                break;
            case ItemType.RING:
                Debug.Log("Por solo 9,99€...");
                break; 
        }



    }
}
