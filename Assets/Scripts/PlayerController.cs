using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5.0f; //Ahora que tenemos el speed, le preguntamos en el update al axis a ver si se ha movido en H o en V. 
    private const string AXIS_H = "Horizontal" , AXIS_V = "Vertical", WALK = "Walking", LAST_H = "LastH", LAST_V = "LastV";

    private bool walking = false; 
    public Vector2 lastMovement = Vector2.zero;

    

    private Animator _animator; //componente privada del propio objeto así que va con una underscore "_"





    // Start is called before the first frame update
    void Start()
    {

        _animator = GetComponent<Animator>();








    }

    // Update is called once per frame
    void Update()
    {
        this.walking = false; //this para enfatizar que es una variable de esta propia clase

        //Espacio = velocidad * tiempo
        if (Mathf.Abs(Input.GetAxisRaw(AXIS_H)) > 0.2f)
        {
            Vector3 translation = new Vector3(Input.GetAxisRaw(AXIS_H) * speed * Time.deltaTime, 0, 0);
            this.transform.Translate(translation);
            this.walking = true;
            lastMovement = new Vector2(Input.GetAxisRaw(AXIS_H), 0); //inicializamos el vector 2 donde en el ejece de las X llamamos al lasth y ponemos el Y a 0. Save Lastmovement knonw.
        }


        if (Mathf.Abs(Input.GetAxisRaw(AXIS_V)) > 0.2f)
        {
            Vector3 translation = new Vector3(0, Input.GetAxisRaw(AXIS_V) * speed * Time.deltaTime, 0);
            this.transform.Translate(translation);
            this.walking = true;
            lastMovement = new Vector2(0, Input.GetAxisRaw(AXIS_V)); 
        }

    }

    private void LateUpdate()  // responsable último después de haber movido las teclas
    {

        _animator.SetFloat("Horizontal", Input.GetAxisRaw(AXIS_H)); //lo que mueve horizontalmente en el hardware (joystick or keys) se lo traduzco al idioma que habla la animación "horizontal". 
        _animator.SetFloat("Vertical", Input.GetAxisRaw(AXIS_V));
        _animator.SetBool(WALK, walking);
        _animator.SetFloat(LAST_H, lastMovement.x);
        _animator.SetFloat(LAST_V, lastMovement.y);
        
    }
}
