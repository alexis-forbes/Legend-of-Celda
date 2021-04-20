using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
[RequireComponent(typeof(HealthManager))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    public bool canMove = true;

    public bool isTalking; 

    public static bool playerCreated; //para el dontdestroyonload

    public float speed = 5.0f; //Ahora que tenemos el speed, le preguntamos en el update al axis a ver si se ha movido en H o en V.
  
    private const string AXIS_H = "Horizontal" , AXIS_V = "Vertical", WALK = "Walking", ATT = "Attacking", LAST_H = "LastH", LAST_V = "LastV";

    private bool walking = false;
    private bool attacking = false; 
    public Vector2 lastMovement = Vector2.zero;

  

    private Animator _animator; //componente privada del propio objeto así que va con una underscore "_"
    private Rigidbody2D _rigidbody;

    public string nextUuid;

    public float attackTime;
    private float attackTimeCounter;




    // Start is called before the first frame update
    void Start()
    {

        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();

        playerCreated = true;

        isTalking = false; 

    }





    // Update is called once per frame
    void Update()
    {
        if (isTalking)
        {
            _rigidbody.velocity = Vector2.zero;
            return; 
        }




        this.walking = false; //this para enfatizar que es una variable de esta propia clase
        //walking is false so character will stop walking
        if (!canMove) //how it doesnt move it stops
        {
            return;
        }


        if (attacking) //si ya estamos atacando no hay que comprobar si el boton esta pulsado
        {
            attackTimeCounter -= Time.deltaTime; //le descuento el tiempo de frame
            if(attackTimeCounter < 0) //cuando llegue a 0
            {
                attacking = false; //paro el ataque
                _animator.SetBool(ATT, false); //paro el animador y pongo atacar en false
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            attacking = true;
            attackTimeCounter = attackTime;
            _rigidbody.velocity = Vector2.zero;
            _animator.SetBool(ATT, true);
        }
        //Atacar tiene que prevalecer sobre el movimiento








        //Espacio = velocidad * tiempo
        if (Mathf.Abs(Input.GetAxisRaw(AXIS_H)) > 0.2f)
        {
            // Vector3 translation = new Vector3(Input.GetAxisRaw(AXIS_H) * speed * Time.deltaTime, 0, 0);
            // this.transform.Translate(translation);
            _rigidbody.velocity = new Vector2(Input.GetAxisRaw(AXIS_H), _rigidbody.velocity.y).normalized * speed;
            //que siga el rigid el movimiento de las H, la y no cambia.
            this.walking = true;
            lastMovement = new Vector2(Input.GetAxisRaw(AXIS_H), 0); //inicializamos el vector 2 donde en el ejece de las X llamamos al lasth y ponemos el Y a 0. Save Lastmovement knonw.
        }


        if (Mathf.Abs(Input.GetAxisRaw(AXIS_V)) > 0.2f)
        {
            // Vector3 translation = new Vector3(0, Input.GetAxisRaw(AXIS_V) * speed * Time.deltaTime, 0);
            // this.transform.Translate(translation);
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, Input.GetAxisRaw(AXIS_V)).normalized * speed; //right now the player is skying through the playground
            this.walking = true;
            lastMovement = new Vector2(0, Input.GetAxisRaw(AXIS_V)); 
        }

        

    }

    private void LateUpdate()  // responsable último después de haber movido las teclas
    {
        //stopping player from skying

        if (!walking)
        {
            _rigidbody.velocity = Vector2.zero; 
        }




        _animator.SetFloat("Horizontal", Input.GetAxisRaw(AXIS_H)); //lo que mueve horizontalmente en el hardware (joystick or keys) se lo traduzco al idioma que habla la animación "horizontal". 
        _animator.SetFloat("Vertical", Input.GetAxisRaw(AXIS_V));
        _animator.SetBool(WALK, walking);
        _animator.SetFloat(LAST_H, lastMovement.x);
        _animator.SetFloat(LAST_V, lastMovement.y);
        
    }
}
