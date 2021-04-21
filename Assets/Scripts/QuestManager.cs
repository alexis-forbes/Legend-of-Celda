using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class QuestManager : MonoBehaviour
{

    public List<Quest> quests; //list of all quests

    private DialogueManager dialogueMananger; //reference to the DialogueManager



    // Start is called before the first frame update
    void Start()
    {

        dialogueMananger = FindObjectOfType<DialogueMananger>(); 
        foreach(Transform t in transform) //runs through all the children of the manager
        {
            quests.Add(t.gameObject.getComponent<Quest>()); //get the children (quests) of QuestManager
        }





    }

    // Update is called once per frame
    void Update()
    {






    }

    public void ShowQuestText(string questText)
    {
        dialogueMananger.ShowDialogue(new string[] { questText });  //dialogue needed array with multiple elements so this is the solving --> create an array with only one element
    }




}
