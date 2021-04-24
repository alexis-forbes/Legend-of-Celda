using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 




public class AudioVolumeManager : MonoBehaviour
{

    private AudioVolumeController[] audios;

    [Range(0, 1)]
    public float maxVolumeLevel;

    [Range(0, 1)]
    public float currentVolumeLevel; 


    // Start is called before the first frame update
    void Start()
    {

        audios = FindObjectsOfType<AudioVolumeController>(); //register everything i can change volume to
        ChangeGlobalAudioVolume(AudioVolumeController.AudioType.SFX); //the main volume stablished by us will start
        ChangeGlobalAudioVolume(AudioVolumeController.AudioType.MUSIC); //the user will later on change the volume


    }


    public void ChangeGlobalAudioVolume(AudioVolumeController.AudioType type)
    {
        if(currentVolumeLevel >= maxVolumeLevel)
        {
            currentVolumeLevel = maxVolumeLevel; //cant over-do the maxVolume
        }
        foreach(AudioVolumeController ac in audios)
        {
            if(ac.type == type)
            { 
            ac.SetAudioLevel(currentVolumeLevel); //change level of audio in every audio to the currentVolumeLevel stablished
            }
        }


    }


    public void AudioChanged(Slider audioSlide)
    {
        currentVolumeLevel = audioSlide.value; //User will change audio manually
        ChangeGlobalAudioVolume(AudioVolumeController.AudioType.MUSIC); //changing the assigned volume 
    }


    public void SFXChanged(Slider audioSlide)
    {
        currentVolumeLevel = audioSlide.value; //User will change audio manually
        ChangeGlobalAudioVolume(AudioVolumeController.AudioType.SFX); //changing the assigned volume 
    }



}
