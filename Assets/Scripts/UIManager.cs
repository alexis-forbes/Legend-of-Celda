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

    // Update is called once per frame
    void Update()
    {

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
}
