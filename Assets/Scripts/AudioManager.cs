using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] audioTracks;
    public int currentTrack;
    public bool audioCanBePlayed; 







    // Start is called before the first frame update
    void Start()
    {





        
    }

    // Update is called once per frame
    void Update()
    {
        if (audioCanBePlayed)
        {
            if (!audioTracks[currentTrack].isPlaying) //if currenttrack from audiotracks is not playing
            {
                audioTracks[currentTrack].Play(); //play it!
            }
        }
        else //if it cant be played
        {
            audioTracks[currentTrack].Stop(); 
        }
        
    }


    public void PlayNewTrack(int newTrack)
    {
        audioTracks[currentTrack].Stop(); //stop current audio
        currentTrack = newTrack; //change track
        audioTracks[currentTrack].Play(); //and play it
    }


}
