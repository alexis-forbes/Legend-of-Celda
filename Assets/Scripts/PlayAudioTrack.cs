using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//specifique for each track. will call AudioManager


public class PlayAudioTrack : MonoBehaviour
{
    private AudioManager audioManager;
    public int newTrackID;

    public bool playOnStart; 


    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();

        if (playOnStart)
        {
            audioManager.PlayNewTrack(newTrackID); //tell manager im on start and want to play the track with trackid {}
        }

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            audioManager.PlayNewTrack(newTrackID);
            gameObject.SetActive(false); //this way it will be deactivated and not always running when collisioning
        }
    }
}
