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
        shouldPlayAfter.Add("F3_3", "F4");
        shouldPlayAfter.Add("R2_1", "R2_2");
        shouldPlayAfter.Add("R3_1", "R3_2");
        shouldPlayAfter.Add("R3_2", "R3_3");
        shouldPlayAfter.Add("R3_3", "R3_4");
        shouldPlayAfter.Add("Crash", "R4");
        
        AkSoundEngine.PostEvent("Init_all_states", gameObject);
        AkSoundEngine.PostEvent("Switch_Music_Palais_mental", gameObject);
        AkLogger.Message("Switch_Music_Palais_mental");
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
        
        // Intro
        if (callbackCookie.isIntro)
        {
            AkSoundEngine.PostEvent("Set_State_Other", gameObject);
            AkLogger.Message("Set_State_Other");
        }
       
        // Don't reset the exploring state if we are going to speak in the few seconds
        if (!shouldPlayAfter.TryGetValue(callbackCookie.soundItem, out nextDialogue))
        {
            AkSoundEngine.PostEvent("Set_State_Exploring", gameObject);
            AkLogger.Message("Set_State_Exploring : " + callbackCookie.soundItem);
        }
            
//            // If the last zone is different from where the player stands, switch the music accordingly
//            if (this.lastZone != LevelManager.instance.currentZone)
//            {
//                AkSoundEngine.PostEvent("Play_" + LevelManager.instance.currentZone, gameObject);
//                AkLogger.Message("Play_" + LevelManager.instance.currentZone);
//            }
        
        
        if (shouldPlayAfter.TryGetValue(callbackCookie.soundItem, out nextDialogue))
        {
           ItemValidation(nextDialogue, new EventCbCookie(nextDialogue, null, false, LevelManager.instance.currentZone));
        }

        this.isSpeaking = false;
        SwitchMusicTrack(LevelManager.instance.currentZone, false);
        this.lastZone = LevelManager.instance.currentZone;
        
        if (callbackCookie.nextStep != null)
            LevelManager.instance.OnSpeechEnd(callbackCookie.soundItem, callbackCookie.nextStep);
    }

    public void SwitchMusicTrack(string clipName, bool lpf = true)
    {
        if (isSpeaking) return;

        string action = lpf ? "Switch_Music" : "Play";
        
        AkSoundEngine.PostEvent(action + "_" + clipName, gameObject);
        AkLogger.Message(action + "_ " + clipName);
    }
    
    public void PlaySoundEffect(string soundName, GameObject theGameobject = null)
    {
        GameObject gameObjectToUse;
        if (theGameobject) gameObjectToUse = theGameobject;
        else
        {
            switch (soundName)
            {
                case "fire":
                    gameObjectToUse = this.sounds3D[1];
                    break;
                default: throw new ArgumentException("Wrong soundName");
            }
        }
        AkSoundEngine.PostEvent("Play_" + soundName, gameObjectToUse);
        AkLogger.Message("Play_" + soundName);
    }
}