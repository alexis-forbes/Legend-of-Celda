using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class ItemsManager : MonoBehaviour
{
    private List<GameObject> questItems = new List<GameObject>();
    public List<GameObject> GetQuestItems()
    {
        return questItems;
    }

    public QuestItem GetItemAt(int idx)
    {
        return questItems[idx].GetComponent<QuestItem>(); 
    }



    public bool HasTheQuestItem(QuestItem item)
    {
        foreach(GameObject qi in questItems)
        {
            if(qi.GetComponent<QuestItem>().itemName == item.itemName)
            {
                return true; 
            }
        }
        return false; 
    }


    public void AddQuestItem(GameObject newItem) //add item when collected
    {
        questItems.Add(newItem);
    }

    // Start is called before the first frame update
    void Start()
    {





    }

    // Update is called once per frame
    void Update()
    {





    }









}
