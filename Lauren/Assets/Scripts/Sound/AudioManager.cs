using UnityEngine.Audio;
using System;
using System.Collections;
using System.Collections.Generic;
using Sound;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] sounds3D;
    private bool isSpeaking = false;
    
    public static AudioManager instance;


    private string lastZone = null;

    /**
     * Describe dialogue lines that should be played right after the current one is over
     */
    private readonly Dictionary<string, string> shouldPlayAfter = new Dictionary<string,string>();
    
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
        // Init
        shouldPlayAfter.Add("C4", "C5");
        shouldPlayAfter.Add("F3_2", "F4");
        
        AkSoundEngine.PostEvent("Init_all_states", gameObject);
        AkSoundEngine.PostEvent("Switch_Music_Palais_mental", gameObject);
        AkLogger.Message("Init Palais mental theme");
    }


    public void ItemValidation(string soundItem, EventCbCookie cookie, bool isSpeaking = true)
    {
        if (isSpeaking) this.isSpeaking = true;
        
        AkSoundEngine.PostEvent("Play_" + soundItem, gameObject,
            (uint)AkCallbackType.AK_EndOfEvent, OnSpeechEnd, cookie);
        AkLogger.Message("Play_" + soundItem);
    }

    private void OnSpeechEnd(object cookie, AkCallbackType in_type, AkCallbackInfo in_info)
    {
        EventCbCookie callbackCookie = (EventCbCookie) cookie;
        string nextDialogue;
        
        AkLogger.Message("OnSpeechEnd: " + callbackCookie.soundItem);
        
        if (callbackCookie.isIntro)
        {
            AkSoundEngine.PostEvent("Play_" + LevelManager.instance.currentZone, gameObject);
            AkLogger.Message("Play_" + LevelManager.instance.currentZone);
        }
        else
        {
            // Don't reset the exploring state if we are going to speak in the few seconds
            if (!shouldPlayAfter.TryGetValue(callbackCookie.soundItem, out nextDialogue))
            {
                AkSoundEngine.PostEvent("Set_State_Exploring", gameObject);
                AkLogger.Message("Set_State_Exploring");
            }
            
            // If the last zone is different from where the player stands, switch the music accordingly
            if (this.lastZone != LevelManager.instance.currentZone)
            {
                AkSoundEngine.PostEvent("Play_" + LevelManager.instance.currentZone, gameObject);
                AkLogger.Message("Play_" + LevelManager.instance.currentZone);
            }
        }
        
        if (shouldPlayAfter.TryGetValue(callbackCookie.soundItem, out nextDialogue))
        {
           ItemValidation(nextDialogue, new EventCbCookie(nextDialogue, null, false, LevelManager.instance.currentZone));
        }

        this.isSpeaking = false;
        this.lastZone = LevelManager.instance.currentZone;
        
        if (callbackCookie.nextStep != null)
            LevelManager.instance.OnSpeechEnd(callbackCookie.soundItem, callbackCookie.nextStep);
    }

    public void PlayMusicTrack(string clipName)
    {
        if (isSpeaking) return;
        
        AkSoundEngine.PostEvent("Switch_Music_" + clipName, gameObject);
        AkLogger.Message("Switch_Music " + clipName);
    }
    
    public void PlaySoundEffect(string soundName, GameObject theGameobject)
    {
        AkSoundEngine.PostEvent("Play_" + soundName, theGameobject);
        AkLogger.Message("Play_" + soundName);
    }
}