using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quest : MonoBehaviour
{

    public int questID;
    public bool questCompleted;

    private QuestManager questManager; //private reference to QuestManager to initialize in Start

    
    public string title; 
    public string startText; //quest text when starts
    public string completeText; //quest text when finishes

    public bool needsItem;
    public List<QuestItem> itemsNeeded;

    public bool killsEnemy;
    public List<QuestEnemy> enemies;
    public List<int> numberOfEnemies;


    public Quest nextQuest; //each quest will display the next quest in layer


    //everytime a scene is loaded, class Quest will be responsible of looking out for new items/enemies/nextQuest

    private void OnEnable() //when scene is loaded we encomend the delegate the OnSceneLoaded method (below)
    {
        SceneManager.sceneLoaded += OnSceneLoaded; //using delegates because OnLevelWasLoaded is being deprecated 
    }

    private void OnDisable() //when scene is disabled, remove delegate
    {
        
        SceneManager.sceneLoaded -= OnSceneLoaded; 
        
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (needsItem)
        {
            ActivateItems();
        }
        if (killsEnemy)
        {
            ActivateEnemies();
        }

    }

    public void StartQuest() //start quest
    {
        SFXManager.SharedInstance.PlaySFK(SFXType.SoundType.M_START); 

        questManager = FindObjectOfType<QuestManager>(); //necessary to activate and initialize the quest
        questManager.ShowQuestText(title + "\n" + startText); //notify quest manager of the needs of the quest

        
        if (needsItem)
        {
            ActivateItems(); 
        }
        if (killsEnemy)
        {
            ActivateEnemies(); 
        }

    }

    //find all the items/enemies of the quest and activate them depending on the quest with methods: ActivateItems & Activate Enemies initialized in the StartQuest

    void ActivateItems()
    {
        Object[] items = Resources.FindObjectsOfTypeAll<QuestItem>(); //FindObjectsOfTypeAll because it is initially inactive
        foreach (QuestItem item in items)
        {
            if (item.questID == questID)
            {
                item.gameObject.SetActive(true); //item and enemies deactivated for this to work
            }
        }
    }



    void ActivateEnemies()
    {
        Object[] qenemies = Resources.FindObjectsOfTypeAll<QuestEnemy>(); //FindObjectsOfTypeAll because it is initially inactive
        foreach (QuestEnemy enemy in qenemies)
        {
            if (enemy.questID == questID)
            {
                enemy.gameObject.SetActive(true);
            }
        }
    }




    public void CompleteQuest() //end quest
    {
        SFXManager.SharedInstance.PlaySFK(SFXType.SoundType.M_END); 


        questManager = FindObjectOfType<QuestManager>(); //necessary to activate and initialize the quest
        questManager.ShowQuestText(title + "\n" + completeText); 
        questCompleted = true;
        if (nextQuest != null)
        {
            Invoke("ActivateNextQuest", 5.0f); //invoking ActivateNextQuest in 5 min so that next quest is available
        }
        gameObject.SetActive(false); //so that mission is not accesible again
    }


    void ActivateNextQuest()
    {
        nextQuest.gameObject.SetActive(true);
        nextQuest.StartQuest(); 
    }





    // Update is called once per frame
    void Update()
    {
        if (needsItem && questManager.itemCollected!=null) //if quest needs item and QM has an item to collect
        {
           for(int i =0; i< itemsNeeded.Count; i++) //look in items list if the one i need is available
            {
                if(itemsNeeded[i].itemName == questManager.itemCollected.itemName) //if items needed in I position coincides with the item name the QM has collected
                {
                    itemsNeeded.RemoveAt(i); //eliminate the item in that position
                    questManager.itemCollected.name = null; //telling QM there are no more items to collect
                    break; //erase element
                }
            }
           if(itemsNeeded.Count == 0)
            {
                
                CompleteQuest(); //if there is no more items to pick up, complete quest
            }
                
                
        }

        if(killsEnemy && questManager.enemyKilled != null) //if the quest is about killing enemies and QM notifies my I have killed an enemy
        {
            Debug.Log("Enemy recently killed");
            for (int i = 0; i < enemies.Count; i++) //for every enemy we kill
            {
                if(enemies[i].enemyName == questManager.enemyKilled.enemyName) //if enemy in [i] position == the enemykilled name in QM
                {
                    numberOfEnemies[i]--; //subtract 1 to the total of enemies left
                    questManager.enemyKilled = null;
                    if (numberOfEnemies[i] <= 0) //if no enemies left
                    {
                        enemies.RemoveAt(i); //remove enemy
                        numberOfEnemies.RemoveAt(i); //remove the count of enemies
                    }
                    break; 
                }
            }
            if(enemies.Count == 0) //quest completed!
            {
                CompleteQuest(); 
            }
        }



    }
}
