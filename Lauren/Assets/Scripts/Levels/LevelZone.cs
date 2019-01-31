using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelZone : MonoBehaviour
{
    private const string defaultChapterClip = "Palais_mental";

    [SerializeField] private int itemNumber;
    [SerializeField] private string firstStep;
    [SerializeField] private string chapterClip;

    private bool isActivatedItem = true;

    // When the player enter the level
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Player") return;

        // Start the Level theme clip
        AudioManager.instance.SwitchMusicTrack(chapterClip);
        
        // Play the first step only once
        if (isActivatedItem)
        {
            // Start the firstStep of the zone
            GameManager.instance.ActivateObject(itemNumber);
            isActivatedItem = false;
        }

        GameManager.instance.currentZone = chapterClip;
    }

    // When the player exit the level
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name != "Player") return;

        GameManager.instance.currentZone = defaultChapterClip;
        AudioManager.instance.SwitchMusicTrack(defaultChapterClip);
    }
}