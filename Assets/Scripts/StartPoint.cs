using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{

    private PlayerController player; // privadas porque aparecerán en el Start. Cada vez que creemos un punto de spawn y asociarlo es más sencillo
    private CameraFollow theCamera;

    public Vector2 facingDirection = Vector2.zero; //en la que queremos que mire el prota 

    public string uuid; //guardamos el nombre del startpoint

    // Start is called before the first frame update
    void Start()
    {

        player = FindObjectOfType<PlayerController>();
        theCamera = FindObjectOfType<CameraFollow>();

        if (!player.nextUuid.Equals(uuid)) //si el jugador tiene por nextUuid un nombre diferente al actual uuid no se hace nada
        {
            return; 
        }


        //una vez referenciados, hay que colocar el player donde este el StartPoint cambiandole el transform y la posicion asignandolo a la del propio (this) startpoint
        player.transform.position = this.transform.position;  //posicionamos al jugador donde este el startpoint y de regalo modificamos la posicion de la camara
        theCamera.transform.position = new Vector3(transform.position.x, //para la camara hay que crear el vector porque sino estaria encima del personaje y no lo veriamos,
                                                transform.position.y, // recordar que mantiene posicion z=-10 asi que creamos ese vector
                                                theCamera.transform.position.z);

        player.lastMovement = facingDirection; //que esa direccion se corrija

    }

    // Update is called once per frame 
    void Update()
    {






    }
}
