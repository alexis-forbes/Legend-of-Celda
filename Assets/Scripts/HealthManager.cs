using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;

    [SerializeField]
    private int currentHealth;

    public int Health
    {
        get
        {
            return currentHealth; 
        }
        
    }


    public bool flashActive; //var to know if enemy is flashing
    public float flashLength;
    private float flashCounter;

    private SpriteRenderer _characterRenderer; //we will tint sprite or make it invisible. Its a reference
                                               //component of the character thats why it has "_" at the begining


    public int expWhenDefeated;








    // Start is called before the first frame update
    void Start()
    {
        _characterRenderer = GetComponent<SpriteRenderer>(); //initializing the spriterenderer
        UpdateMaxHealth(maxHealth);





    }


    public void DamageCharacter(int damage)
    { //destroy character if damaged and health <=0

        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
        if (gameObject.tag.Equals("Enemy"))
        {
            GameObject.Find("Player").GetComponent<CharacterStats>().AddExperience(expWhenDefeated);
            //if the object destroyed is the enemy
            //get player and get component CharacterStats
            //call get experience with the amount of experience to add when enemy defeated
        }

        if (flashLength > 0)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<PlayerController>().canMove = false;
         
            flashActive = true;
            flashCounter = flashLength; //start the flashcounter
        }

    }
    public void UpdateMaxHealth(int newMaxHealth)
    {
        maxHealth = newMaxHealth;
        currentHealth = maxHealth;
    }


    void ToggleColor(bool visible)
    {
        _characterRenderer.color = new Color(_characterRenderer.color.r, _characterRenderer.color.g, _characterRenderer.color.b, (visible ? 1.0f : 0.0f)); //ternary operator of the bool visible parameter
        //keep the character's colors
    }




    // Update is called once per frame
    private void Update()
    {
        if (flashActive)
        {
            flashCounter -= Time.deltaTime;
            if(flashCounter > flashLength * 0.66f) //si aun no ha paso el 33% de la animacion, es que es el primer frame
            {
                ToggleColor(false); //invisible
            }
            else if (flashCounter > flashLength*0.33f) //ha pasado entre un 33 y un 66% total de la animacion
            {
                ToggleColor(true); //activamos personaje 
            }else if (flashCounter > 0) //si ha pasado entre un 66 y un 99% de la animacion
            {
                ToggleColor(false); //personaje no visible y parpadeando
            }
            else // sin tiempo de animacion
            {
                ToggleColor(true); //personaje visible
                flashActive = false; //fuera flashing
                GetComponent<BoxCollider2D>().enabled = true;
                GetComponent<PlayerController>().canMove = true;

            }
        }






    }


   

}