using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSound : MonoBehaviour
{
    [SerializeField] private string soundName;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlaySoundEffect(soundName, this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
