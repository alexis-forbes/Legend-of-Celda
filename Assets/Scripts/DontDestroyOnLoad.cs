using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{




    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerController.playerCreated)
        {
           DontDestroyOnLoad(this.transform.gameObject); //hace que dicho objeto no sea destruible
        }
        else
        {
            Destroy(gameObject); 
        }
        //este bucle lo que hace es decir que no se cree más de un objeto a la hora de duplicar. Solo se duplica una vez.


    }

    
}
