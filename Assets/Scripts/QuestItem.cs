using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(CircleCollider2D))]
public class QuestItem : MonoBehaviour
{

    public int questID;
    private QuestManager questManager; //notify manager item of X quest has been picked up
    private ItemsManager itemManager; 
    public string itemName; 



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            questManager = FindObjectOfType<QuestManager>(); //call QM
            itemManager = FindObjectOfType<ItemsManager>(); //call IM

            Quest q = questManager.QuestWithID(questID); //safe programming
            if(q == null) //if mission id doesnt exist
            {
                Debug.LogErrorFormat("Mission with {0} ID does not exist", questID); //we know our mistake
            }
            if (q.gameObject.activeInHierarchy&&!q.questCompleted) //if q is active and not completed
            {
                questManager.itemCollected = this; //questManager will know which item has been collected
                itemManager.AddQuestItem(this.gameObject); //IM will know which item has been collected
                gameObject.SetActive(false); 
            }
        }
    }














}
