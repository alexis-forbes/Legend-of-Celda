using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //cambiar de escena

public class GoToNewPlace : MonoBehaviour
{
    //variables
    //Vamos a decirle qué escena ha de cargar
    public string newPlaceName = "New Scene Name Here!!";
    public bool needsClick = false;

    public string uuid; 

    //we need to change scene when character triggers an INVISIBLE object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the collider is the gameObject Player
        Teleport(collision.gameObject.name); 
    }


      private void OnTriggerStay2D(Collider2D collision)
    {
        //if the collider is the gameObject Player
        Teleport(collision.gameObject.name);
    }



    private void Teleport(string objName)
    {
        if(objName == "Player")
        {
            if(!needsClick || (needsClick && Input.GetMouseButtonDown(0)))
            {
                FindObjectOfType<PlayerController>().nextUuid = uuid;
                //si no necesito click, cargo escena o se cumple lo demas (o necesito click y he pulsado el botón necesario
                //do: load the new scene
                SceneManager.LoadScene(newPlaceName);
            }
        }


        
    }

    //Resumen: si el jugador colisiona y hace click o no le hace falta click,
    // el siguiente lugar al que tiene que ir el player es el uuid que he marcado en el GoToNewPlace
    //en el startpoint si el jugador tiene que ir a un uuid diferente al mio no podemos ir al teleport



   
}