using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;

    [SerializeField]
    private int currentHealth;







    // Start is called before the first frame update
    void Start()
    {
        UpdateMaxHealth(maxHealth);





    }

    // Update is called once per frame
    void Update()
    {







    }


    public void DamageCharacter(int damage)
    { //destroy character if damaged and health <=0

        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void UpdateMaxHealth(int newMaxHealth)
    {
        maxHealth = newMaxHealth;
        currentHealth = maxHealth;
    }

}