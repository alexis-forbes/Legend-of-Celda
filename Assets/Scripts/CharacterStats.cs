using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public const int MAX_STAT_VAL = 100;
    public const int MAX_HEALTH = 9999;

    public int level;
    public int exp;
    public int[] expToLevelUp;

    [Tooltip("Character's life levels")]
    public int[] hpLevels;
    [Tooltip("Strength added to the weapons")]
    public int[] strengthLevels;
    [Tooltip("Defense dividing enemy's damage")]
    public int[] defenseLevels;
    [Tooltip("Attack velocity")]
    public int[] speedLevels;
    [Tooltip("Probability of enemy failing")]
    public int[] luckLevels;
    [Tooltip("Probability of character failing")]
    public int[] accuracyLevels; 

    //cada estado tendra que ayudar a otro script

    private HealthManager healthManager;
    private PlayerController playerController; 


    // Start is called before the first frame update
    void Start()
    {
        healthManager = GetComponent<HealthManager>();
        playerController = GetComponent<PlayerController>();

        healthManager.UpdateMaxHealth(hpLevels[level]); //updates enemy and character's hp levels depending on the level

        if (gameObject.tag.Equals("Enemy"))
        {
            EnemyController controller = GetComponent<EnemyController>();
            controller.speed += speedLevels[level] / CharacterStats.MAX_HEALTH; 
        }
    }



    public void AddExperience(int exp) //method addexperience with parameter of exp
    {
        this.exp += exp; //this variable = exp in the parameter
                        //first we add total exp points
                        //then we find out if its the last level or not
        if (level >= expToLevelUp.Length) //security --> if there are no more level to upgrade, destroy this script
        {
            return;
        }
        if (exp >= expToLevelUp[level]) //si tengo mas de la exp necesaria para subir de nivel 
        {
            level++; //subimos de nivel
            //after +level, healthmanager has to update
            healthManager.UpdateMaxHealth(hpLevels[level]);
            playerController.attackTime -= speedLevels[level]/MAX_STAT_VAL; //cada incremento de 1 unidad de velocidad se traduce en una centesima menos de tiempo de ataque 
        }
    }
}
