using System.Collections;
using System.Collections.Generic;
using UnityEngine;







[RequireComponent(typeof(CircleCollider2D))]
public class NPCDialogue : MonoBehaviour
{

    public string npcName;
    public string[] npcDialogueLines; 
    public Sprite npcSprite;


    private DialogueManager dialogueManager;
    private bool playerInTheZone;


    void Start()
    {

        dialogueManager = FindObjectOfType<DialogueManager>(); //find the only manager and stantiate it

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name.Equals("Player"))
        {
            playerInTheZone = true; 
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            playerInTheZone = false;
        }


    }



    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
       
        if (playerInTheZone && Input.GetMouseButtonDown(1))
        {
            string[] finalDialogue = new string[npcDialogueLines.Length];

            int i = 0; 
            foreach(string line in npcDialogueLines) //go through all dialogue lines
            {
                finalDialogue[i] = ((npcName != null) ? npcName + "\n" : "") + line; //for each one if needed --> add npcName
                i++; 
            }
            
            if(npcSprite != null)
            {
                dialogueManager.ShowDialogue(finalDialogue, npcSprite);
            }
            else
            {
                dialogueManager.ShowDialogue(finalDialogue);
            }

            if (gameObject.GetComponentInParent<NPCMovement>() != null) //if npcmovement from parent is not null, it can move
            {
                gameObject.GetComponentInParent<NPCMovement>().isTalking = true; 
            }



            
        }
        

   








    }
}
