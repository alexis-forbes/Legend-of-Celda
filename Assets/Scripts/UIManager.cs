using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class UIManager : MonoBehaviour
{
    public Slider playerHealthBar;
    public Text playerHealthText;
    public Text playerLevelText;
    public Slider playerExpBar;
    public Image playerAvatar;

    public HealthManager playerHealthManager;
    public CharacterStats playerStats;
    private WeaponManager weaponManager; 


    private void Start()
    {
        weaponManager = FindObjectOfType<WeaponManager>(); 
        inventoryPanel.SetActive(false);
        menuPanel.SetActive(false); 

    }









    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.I))
        {
            Toggleinventory(); 
        }

        playerHealthBar.maxValue = playerHealthManager.maxHealth; //max bar value = max health of player health manager
        playerHealthBar.value = playerHealthManager.Health;


        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("HP: ").Append(playerHealthManager.Health).Append(" / ").Append(playerHealthManager.maxHealth);


        playerHealthText.text = stringBuilder.ToString();


        //renderising player bars: health, exp
        playerLevelText.text = "Nivel: " + playerStats.level;


        if(playerStats.level >= playerStats.expToLevelUp.Length) 
        {
            playerExpBar.enabled = false;  //deactivate exp bar if bar if full with max exp
            return; //avoid next lines execution
        }

        playerExpBar.maxValue = playerStats.expToLevelUp[playerStats.level]; //max value of experience bar has to coincide with the max exp value to get to the maxvalue attending to the actual level
        playerExpBar.minValue = playerStats.expToLevelUp[playerStats.level-1]; //min value of experience bar has to coincide with the min exp value to get to the min value attending to the actual level -1
        playerExpBar.value = playerStats.exp; //actual value = actual exp of the player

    }

    public GameObject inventoryPanel, menuPanel;
    public Button inventoryButton;
   

    public void Toggleinventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeInHierarchy); //if its visible make it invisible and VS
        menuPanel.SetActive(!menuPanel.activeInHierarchy); //if menuPanel is visible make it invisible and VS
        if (inventoryPanel.activeInHierarchy)
        {
            foreach(Transform t in inventoryPanel.transform) //Each time we open, what was selected gets destroyed
            {
                Destroy (t.gameObject); 
            }
            FillInventory(); 
        }
    }

    public void FillInventory()
    {
        List<GameObject> weapons = weaponManager.GetAllWeapons(); //recover all weapons
        int i = 0; 
        foreach (GameObject w in weapons)
        {
            Button tempB = Instantiate(inventoryButton, inventoryPanel.transform);
            tempB.GetComponent<InventoryButton>().type = InventoryButton.ItemType.WEAPON;
            tempB.GetComponent<InventoryButton>().itemIdx = i; 
            tempB.onClick.AddListener(() => tempB.GetComponent<InventoryButton>().ActivateButton());   //adds a delegate to the button responding with the manager changing weapon in determine position
            //translate weapon image to the button image
            tempB.image.sprite = w.GetComponent<SpriteRenderer>().sprite;
            i++; 
        }

    }


    public void ShowOnly(int type) //show only certain types of objects in inventorybutton
    {
        foreach(Transform t in inventoryPanel.transform)
        {
            t.gameObject.SetActive((int)t.GetComponent<InventoryButton>().type == type); //compare if button type is the type i want to display
        }
    }


    public void ShowAll() //show all elements in inventory
    {
        foreach(Transform t in inventoryPanel.transform) //retreive all children
        {
            t.gameObject.SetActive(true); 
        }
    }


    public void ChangeAvatarImage(Sprite sprite)
    {
        playerAvatar.sprite = sprite; 
    }

    public void HealthChanged()
    {

    }

    public void LevelChanged()
    {

    }

    public void ExpChanged()
    {

    }

}
