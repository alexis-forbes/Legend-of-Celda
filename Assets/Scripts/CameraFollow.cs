using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{

    public GameObject target; //el objeto que vamos a seguir es un GameObject (player) llamado target
    private Vector3 targetPosition; //con la posición que toque
    public float cameraSpeed; //gobernar la velocidad de la camara


    private Camera theCamera;
    private Vector3 minLimits, maxLimits;
    private float halfHeight, halfWidth; 


    // Start is called before the first frame update
    void Start()
    {
       
    }


    public void ChangeLimits(BoxCollider2D cameraLimits)
    {
        minLimits = cameraLimits.bounds.min;
        maxLimits = cameraLimits.bounds.max;

        theCamera = GetComponent<Camera>();
        halfHeight = theCamera.orthographicSize; //camera size is /2 the smallest measure. our game is larger horizontally, so that would be the height
        halfWidth = (halfHeight / Screen.height) * Screen.width;

    }

    // Update is called once per frame
    void Update()
    {
        float posX = Mathf.Clamp(this.target.transform.position.x, minLimits.x + halfWidth, maxLimits.x - halfWidth); //final camera zone available
        float posY = Mathf.Clamp(this.target.transform.position.y, minLimits.y + halfHeight, maxLimits.y - halfHeight); 

        targetPosition = new Vector3(posX,
                                     posY,
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
