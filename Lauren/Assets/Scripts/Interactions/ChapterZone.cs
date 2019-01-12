﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterZone : MonoBehaviour
{
    [SerializeField]
    private string step;
    [SerializeField]
    private string chapterClip;
    private bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" )
        {
            AudioManager.instance.Play(chapterClip);
            //TODO lancer tous les instru en silencieux
            AudioManager.instance.SetVolume("Theme", 0);
            if(!activated)
            {
                activated = true;
                StartCoroutine(LevelManager.instance.StartStep(step));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            AudioManager.instance.Stop(chapterClip);
            //TODO stopper tous les instru
            AudioManager.instance.SetVolume("Theme", 0.06f);
        }
    }
}
