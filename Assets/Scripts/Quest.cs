using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{

    public int questID;
    public bool questCompleted;

    private QuestManager questManager; //private reference to QuestManager to initialize in Start

    
    public string title; 
    public string startText; //quest text when starts
    public string completeText; //quest text when finishes

    // Start is called before the first frame update
    void Start()
    {
        questManager = FindObjectOfType<QuestManager>(); 




    }

    public void StartQuest() //start quest
    {
        questManager.ShowQuestText(title + "\n" + startText); //notify quest manager of the needs of the quest


    }

    public void CompleteQuest() //end quest
    {
        questManager.ShowQuestText(title + "\n" + completeText); 
        questCompleted = true;
        gameObject.SetActive(false); //so that mission is not accesible again
    }








    // Update is called once per frame
    void Update()
    {






    }
}
