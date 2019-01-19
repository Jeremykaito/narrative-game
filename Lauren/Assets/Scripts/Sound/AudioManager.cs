using UnityEngine.Audio;
using System;
using System.Collections;
using Sound;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private bool isSpeaking = false;
    
    public static AudioManager instance;


    private string lastZone = null;

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
        AkSoundEngine.PostEvent("Switch_Music_Palais_mental", gameObject);
        AkLogger.Message("Init Palais mental theme");
    }


    public void ItemValidation(string name, EventCbCookie cookie, bool isSpeaking = true)
    {
        if (isSpeaking) this.isSpeaking = true;
        
        AkSoundEngine.PostEvent("Play_" + name, gameObject,
            (uint)AkCallbackType.AK_EndOfEvent, OnSpeechEnd, cookie);
        AkLogger.Message(name);
    }

    private void OnSpeechEnd(object cookie, AkCallbackType in_type, AkCallbackInfo in_info)
    {
        EventCbCookie callbackCookie = (EventCbCookie) cookie;
        
        AkLogger.Message("OnSpeechEnd: " + callbackCookie.soundItem);
        
        if (callbackCookie.isIntro)
        {
            AkSoundEngine.PostEvent("Play_" + LevelManager.instance.currentZone, gameObject);
            AkLogger.Message("Play_" + LevelManager.instance.currentZone);
        }
        else
        {
            AkSoundEngine.PostEvent("Set_State_Exploring", gameObject);
            if (this.lastZone != LevelManager.instance.currentZone)
            {
                AkSoundEngine.PostEvent("Play_" + LevelManager.instance.currentZone, gameObject);
                AkLogger.Message("Play_" + LevelManager.instance.currentZone);
            }
                
            AkLogger.Message("Set_State_Exploring");
        }

        this.isSpeaking = false;
        this.lastZone = LevelManager.instance.currentZone;
        LevelManager.instance.OnSpeechEnd(callbackCookie.soundItem, callbackCookie.nextStep);
    }

    public void PlayMusicTrack(string clipName)
    {
        if (isSpeaking) return;
        
        AkSoundEngine.PostEvent("Switch_Music_" + clipName, gameObject);
        AkLogger.Message("Switch_Music " + clipName);
    }
}