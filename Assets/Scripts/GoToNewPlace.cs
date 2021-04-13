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


    //we need to change scene when character triggers an INVISIBLE object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the collider is the gameObject Player
        if (collision.gameObject.name == "Player")
        {
            if (!needsClick)
            { //si no necesito click, cargo escena o se cumple lo demas (o necesito click y he pulsado el botón necesario
              //do: load the new scene
                SceneManager.LoadScene(newPlaceName);
            }
        }
    }


      private void OnTriggerStay2D(Collider2D collision)
      {
            //if the collider is the gameObject Player
        if (collision.gameObject.name == "Player")
        {
            if (needsClick && Input.GetMouseButtonDown(0))
            { //si no necesito click, cargo escena o se cumple lo demas (o necesito click y he pulsado el botón necesario
              //do: load the new scene
                SceneManager.LoadScene(newPlaceName);
            }
         }

      }




   
}