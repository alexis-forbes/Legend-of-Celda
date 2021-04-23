using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    private QuestManager questManager;
    public int questID;

    public bool startPoint, endPoint;
    private bool playerInZone;
    public bool automaticCatch; 


    // Start is called before the first frame update
    void Start()
    {
        questManager = FindObjectOfType<QuestManager>(); 






    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            playerInZone = true;
            
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            playerInZone = false; 



        }
    }











    // Update is called once per frame
    void Update()
    {
        /*programming two ways of entering a quest
        General explanation:
        if player is in the zone, either by manual activation with click or automatic
        ask what quest we are talking about
        if quest is null it is an error
        if quest exists:
        look if quest has been completed. in that case, nothing to do
        if it has not been completed we have to look if
        we are in a start point or end point
        if in start point --> make sure the mission is not active
        not active? ACTIVATE IT AND RUN IT!
        if in end point
        we can only complete mission if it was active
        in which case we complete it
        */

        if (playerInZone)
        {
            if (automaticCatch || !automaticCatch && Input.GetMouseButtonDown(1)) //automatic catch of player being in the zone or pressing action button
            {
                Quest q = questManager.QuestWithID(questID);
                if(q == null)
                {
                    //good coding practice --> documenting errors
                    Debug.LogErrorFormat("The mission with {0} ID doest not exist", questID);
                    return; 
                }
                if (!q.questCompleted) //if i get here, the mission exists
                {
                    //if i have not completed it I am in a zone of activation
                    if (startPoint)
                    {
                        //i am in the on mission zone
                        if (!q.gameObject.activeInHierarchy) //if this line disappears the mission will be to be completed several times
                        {
                            //it is a latent mission. i was there but nobody has activated it
                            q.gameObject.SetActive(true);
                            q.StartQuest(); //mission starts
                        }
                    }
                    if (endPoint)
                    {
                        //I am in the finishing point of the mission
                        if (q.gameObject.activeInHierarchy)
                        {
                            q.CompleteQuest(); 
                        }
                    }
                }
            }
        }







    }
}
