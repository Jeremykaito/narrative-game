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
    [SerializeField] private GameObject menu;

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

    private void Start()
    {
       
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
        menu.SetActive(false);
        UIManager.instance.SetReticule(false);
        GameObject.Find("Player").GetComponent<RigidbodyFirstPersonController>().enabled = true;
        GameObject.Find("Player").GetComponent<RigidbodyFirstPersonController>().mouseLook.lockCursor = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
