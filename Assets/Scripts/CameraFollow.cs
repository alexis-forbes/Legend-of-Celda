using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject target; //el objeto que vamos a seguir es un GameObject (player) llamado target
    private Vector3 targetPosition; //con la posición que toque
    public float cameraSpeed; //gobernar la velocidad de la camara

   

    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = new Vector3(target.transform.position.x,
                                     target.transform.position.y,
                                     this.transform.position.z); 
        //recalculamos la posición del target/personaje
        //siemppe lleva el tracking en los 3 ejes de dónde está el personaje




    }
    private void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position,
                                               targetPosition,
                                               Time.deltaTime * cameraSpeed); 
        //corrige la posicion de la camara
        //interpolacion lineal entre dos posiciones
        //velocidad * tiempo = espacio total de movimiento al que debo
    }
}
