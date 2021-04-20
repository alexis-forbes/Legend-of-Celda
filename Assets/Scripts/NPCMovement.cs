using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{

    public float speed = 1.5f;
    private Rigidbody2D _rigidbody;
    private Animator _animator; 

    public bool isWalking = false;
    public bool isTalking; 

    public float walkTime = 1.5f;
    private float walkCounter;

    public float waitTime = 4.0f; //time between steps
    private float waitCounter; //counter time between steps


    private Vector2[] walkingDirections = {
        Vector2.up, Vector2.down, Vector2.left, Vector2.right
    };
    private int currentDirection;


    public BoxCollider2D villagerZone;

    private DialogueManager dialogueManager; //reference to npcDialogue

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        waitCounter = waitTime;
        walkCounter = walkTime;

        _animator = GetComponent <Animator>();

        isTalking = false;

        dialogueManager = FindObjectOfType<DialogueManager>(); 
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        if (isTalking && !dialogueManager.dialogueActive) //if dialogue is no longer active
        {
            isTalking = false; 
        }
        */
        if (isTalking)
        {
            isTalking = dialogueManager.dialogueActive; //isTalking has the power to know if the dialogue is active or not (CLEAN UP FROM ABOVE)
            StopWalking();
            return; //wont continue reading code
        }

        if (isWalking)
        {
            if(this.transform.position.x < villagerZone.bounds.min.x || this.transform.position.x > villagerZone.bounds.max.x || this.transform.position.y < villagerZone.bounds.min.y || this.transform.position.y > villagerZone.bounds.max.y)
            {
                StopWalking(); //If i surpass these bounds, stop. 
            }
            //if I am walking, rigidbody has a velocity in the array of currentDirection
            _rigidbody.velocity = walkingDirections[currentDirection] * speed; //the higher the speed, character will walk faster
            //subtract walkCounter the fixedDeltaTime (position)
            walkCounter -= Time.fixedDeltaTime;
            if (walkCounter < 0)
            {
                StopWalking(); 
            }
        }
        else
        {
            _rigidbody.velocity = Vector2.zero; 
            waitCounter -= Time.fixedDeltaTime; //if the wait counter of stopwalking has value <0
            if (waitCounter < 0)
            {
                StartWalking(); //StartWalking!
            }
        }

    }

    private void LateUpdate() //notify Animator: Horizontal, Vertical and Walking (parameters)
    {
        _animator.SetBool("Walking", isWalking); //give Walking the state I created here
        _animator.SetFloat("Horizontal", walkingDirections[currentDirection].x); //give Horizontal the state current direction in x
        _animator.SetFloat("Vertical", walkingDirections[currentDirection].y); //give Vertical the state current direction in y
    }


    public void StartWalking()
    {
        //startWalking is: 
        currentDirection = Random.Range(0, walkingDirections.Length);
        isWalking = true;
        walkCounter = walkTime; 
    }

    public void StopWalking()
    {
        //stopWalking is the contrary:
        isWalking = false;
        waitCounter = waitTime;
        _rigidbody.velocity = Vector2.zero; 

    }







}
