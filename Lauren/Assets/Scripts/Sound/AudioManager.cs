using UnityEngine.Audio;
using System;
using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    [SerializeField]
    public Sound[] sounds;

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
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }




    private void Start()
    {
        AkSoundEngine.PostEvent("Set_Music_Palais_mental", gameObject);
        AkLogger.Message("Init Palais mental theme");
    }


   /* public IEnumerator ItemValidation(string name)
    {
        AkSoundEngine.PostEvent(name, gameObject,
            (uint)AkCallbackType.AK_EndOfEvent, OnSpeechEnd, null);
        AkLogger.Message(name);
        yield return new WaitForSeconds(2);
    }*/

    private IEnumerator TestItemPicking()
    {
        yield return new WaitForSeconds(2);
        AkSoundEngine.PostEvent("Set_Coup_de_fil_Item1", gameObject,
            (uint) AkCallbackType.AK_EndOfEvent, OnSpeechEnd, null);
        AkLogger.Message("Item1 taken");
        
        
//        yield return new WaitForSeconds(5);
//        AkSoundEngine.PostEvent("Set_Coup_de_fil_Item2", gameObject);
//        AkLogger.Message("Item2 taken");

        
//        yield return new WaitForSeconds(5);
//        AkSoundEngine.PostEvent("Set_Coup_de_fil_Item3", gameObject);
//        AkLogger.Message("Item3 taken");
    }

    private void OnSpeechEnd(object in_cookie, AkCallbackType in_type, AkCallbackInfo in_info)
    {
        AkSoundEngine.PostEvent("Set_State_Exploring", gameObject);
        AkLogger.Message("Return to exploring state");
    }

    public void PlayMusicTrack(string clipName)
    {
        AkSoundEngine.PostEvent("Set_Music_" + clipName, gameObject);
        AkLogger.Message("Init " + clipName + " theme");
        StartCoroutine("TestItemPicking");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound :" + name + "wasn't found.");
            return;
        }
        s.source.Play();
    }


    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

    public void SetVolume(string name, float vol)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.volume = vol ;
    }
}