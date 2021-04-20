using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{

    public GameObject dialogueBox;

    public Text dialogueText;

    public Image avatarImage;

    public bool dialogueActive;


    public string[] dialogueLines; //manager has to track more than one line 
    public int currentDialogueline; //so npcDialogue has to send back more than one line 

    private PlayerController playerController; 

    // Start is called before the first frame update
    void Start()
    {
        dialogueActive = false; 
        dialogueBox.SetActive(false);

        playerController = FindObjectOfType<PlayerController>(); //make the first frame find him

    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueActive && Input.GetKeyDown(KeyCode.Space)) //if there is a dialogue active and you press Space bar
        {
            currentDialogueline++; 
        
        if(currentDialogueline >= dialogueLines.Length) //if the current dialogue line surpasses the length. I am done with the dialogue
        {
            playerController.isTalking = false; 
            currentDialogueline = 0; 
            //inactive form small to big (small  container to big container)
            dialogueActive = false;
            avatarImage.enabled = false; 
            dialogueBox.SetActive(false);
        }
        else
        {
            dialogueText.text = dialogueLines[currentDialogueline]; 
        }

        } //from first if so that the code does not repeat itself 60times/s

    }

    public void ShowDialogue(string[] lines)
    {
        currentDialogueline = 0;
        dialogueLines = lines; 
        // activation from big to small(big container to small container)
        dialogueActive = true;
        dialogueBox.SetActive(true);
        dialogueText.text = dialogueLines[currentDialogueline]; //needed so that code does not repeat itself 60times/s
        playerController.isTalking = true; 
    }


    public void ShowDialogue(string[] lines, Sprite sprite) //overriding method with another parameter (AVATAR)
    {
        ShowDialogue(lines); //overriding the other parameter with the first method
        avatarImage.enabled = true; 
        avatarImage.sprite = sprite; 
    }








}
