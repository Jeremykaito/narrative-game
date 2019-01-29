using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager instance = null;

    // Singletion initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
                Application.Quit();
        }
    }

    public void PlayGame()
    {
        GameObject.Find("Menu").gameObject.SetActive(false);
        UIManager.instance.SetReticule(false);
        GameObject.Find("Player").GetComponent<Rigidbody>().isKinematic = false;
        GameObject.Find("Player").GetComponent<RigidbodyFirstPersonController>().enabled = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
