using UnityEngine.Audio;
using System;
using System.Collections;
using Sound;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private bool isSpeaking = false;
    
    public static AudioManager instance;


    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }


    private void Start()
    {
        AkSoundEngine.PostEvent("Set_Music_Palais_mental", gameObject);
        AkLogger.Message("Init Palais mental theme");
    }


    public void ItemValidation(string name, EventCbCookie cookie, bool isSpeaking = true)
    {
        if (isSpeaking) this.isSpeaking = true;
        
        AkSoundEngine.PostEvent("Set_" + name, gameObject,
            (uint)AkCallbackType.AK_EndOfEvent, OnSpeechEnd, cookie);
        AkLogger.Message(name);
    }

    private void OnSpeechEnd(object cookie, AkCallbackType in_type, AkCallbackInfo in_info)
    {
        
        EventCbCookie callbackCookie = (EventCbCookie) cookie;
        if (callbackCookie.isIntro)
        {
            AkSoundEngine.PostEvent("Play_" + LevelManager.instance.currentZone, gameObject);
            AkLogger.Message("Return to exploring state with music");
        }
        else
        {
            AkSoundEngine.PostEvent("Set_State_Exploring", gameObject);
            AkSoundEngine.PostEvent("Set_Music_" + LevelManager.instance.currentZone, gameObject);
            AkLogger.Message("Return to exploring state");
        }

        this.isSpeaking = false;
    }

    public void PlayMusicTrack(string clipName)
    {
        if (isSpeaking) return;
        
        AkSoundEngine.PostEvent("Set_Music_" + clipName, gameObject);
        AkLogger.Message("Init " + clipName + " theme");
    }
}