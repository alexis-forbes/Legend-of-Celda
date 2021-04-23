using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class InventoryButton : MonoBehaviour
{
    public enum ItemType { WEAPON = 0, ITEM = 1, ARMOR = 2, RING = 3, SPECIAL_ITEMS = 4}; 
    public int itemIdx; //itemindex
    public ItemType type; 

    //now button has the info of the object associated to him


public void ActivateButton()
    {
        switch(type)
        {
            case ItemType.WEAPON:
                FindObjectOfType<WeaponManager>().ChangeWeapon(itemIdx); //equip
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
        ShowDescription(); 



    }


   

    public void ShowDescription()
    {
        string desc = ""; 
        switch (type)
        {
            case ItemType.WEAPON:
                desc = FindObjectOfType<WeaponManager>().GetWeaponAt(itemIdx).weaponName;
                break;
            case ItemType.ITEM:
                desc = "Consumible item";
                break;
            case ItemType.ARMOR:
                desc = FindObjectOfType<WeaponManager>().GetArmorAt(itemIdx).name;
                break;
            case ItemType.RING:
                desc = FindObjectOfType<WeaponManager>().GetRingAt(itemIdx).name;
                break;
            case ItemType.SPECIAL_ITEMS:
                QuestItem item = FindObjectOfType<ItemsManager>().GetItemAt(itemIdx);
                desc = item.itemName;
                break;
        }

        FindObjectOfType<UIManager>().inventoryText.text = desc; 
    }


    public void ClearDescription()
    {
        FindObjectOfType<UIManager>().inventoryText.text = ""; 
    }







}
