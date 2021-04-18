using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int level;
    public int exp;
    public int[] expToLevelUp; 






    // Start is called before the first frame update
    void Start()
    {




        
    }

    // Update is called once per frame
    void Update()
    {
       

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
        }
    }
}
