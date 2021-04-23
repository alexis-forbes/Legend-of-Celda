using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class SFXManager : MonoBehaviour
{

    //SINGLETON (only one instance of type per project --> create a variable private and static same type as the class
    //then, create public instance to obtain the sharedInstance
    private static SFXManager sharedInstance = null; 
    public static SFXManager SharedInstance
    {
        get
        {
            return sharedInstance; 
        }
    }

    private void Awake()
    {
        //if the SINGLETON (if someone is trying to create the unique and only instance shared with everyone (SINGLETON)) and its not me
        if(sharedInstance != null && sharedInstance != this) 
        {
            Destroy(gameObject); //Destroy it
        }
        sharedInstance = this; //if i get here is because instance not designated (never another instance)
        DontDestroyOnLoad(gameObject);

        audios = new List<GameObject>(); //so audios !=null
        GameObject sounds = GameObject.Find("Sounds"); 
        foreach (Transform t in sounds.transform)
        {
            audios.Add(t.gameObject);
        }


    }


    private List<GameObject> audios; 


    public AudioSource FindAudioSource(SFXType.SoundType type)
    {
        foreach(GameObject g in audios)
        {
            if(g.GetComponent<SFXType>().type == type)
            {
                return g.GetComponent<AudioSource>(); 
            }
        }
        return null; //never executed
    }


    public void PlaySFK(SFXType.SoundType type)
    {

        FindAudioSource(type).Play(); 
        
    }
    





}
