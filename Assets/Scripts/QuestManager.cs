using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class QuestManager : MonoBehaviour
{

    public List<Quest> quests; //list of all quests

    private DialogueManager dialogueMananger; //reference to the DialogueManager

    public QuestItem itemCollected;

    public QuestEnemy enemyKilled; 

    // Start is called before the first frame update
    void Start()
    {

        dialogueMananger = FindObjectOfType<DialogueManager>(); 
        foreach(Transform t in transform) //runs through all the children of the manager
        {
            quests.Add(t.gameObject.GetComponent<Quest>()); //get the children (quests) of QuestManager
        }





    }


    public void ShowQuestText(string questText)
    {
        dialogueMananger.ShowDialogue(new string[] { questText });  //dialogue needed array with multiple elements so this is the solving --> create an array with only one element
    }


    public Quest QuestWithID(int questID) //loop of all missions and foreach one we check if the temporary quest == questID in parameter. 
    {
        Quest q = null;
        foreach(Quest temp in quests)
        {
            if(temp.questID == questID)
            {
                q = temp; //q is assinged to the temp quest
            }
        }
        return q; //we found the quest or it is null
    }
    


    
          

}
