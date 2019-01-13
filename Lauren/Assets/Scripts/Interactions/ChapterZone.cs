using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterZone : MonoBehaviour
{
    private const string defaultChapterClip = "Palais_mental";
    
    [SerializeField]
    private string step;
    [SerializeField]
    private string chapterClip;
    private bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {

            AudioManager.instance.PlayMusicTrack(chapterClip);
            
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
            AudioManager.instance.PlayMusicTrack(defaultChapterClip);
        }
    }
}
