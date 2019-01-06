using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeVoice : MonoBehaviour {
    public AudioClip clip;
    private AudioSource s;

    private void Start()
    {
        s = this.GetComponent<AudioSource>();
        s.clip = clip;
    }

    public void Play()
    {
        s.Play();
    }

    // Update is called once per frame
    public void Stop()
    {
        s.Pause();
    }


}
