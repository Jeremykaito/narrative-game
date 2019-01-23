using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class StartGame : MonoBehaviour
{
    public bool start;
    public Transform[] patrolPoints;
    public float moveSpeed = 1;
    private int currentPoint;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Player").transform.position = patrolPoints[0].position;
        currentPoint = 0;
        GameObject.Find("Player").GetComponent<Rigidbody>().isKinematic = true;
        GameObject.Find("Player").GetComponent<RigidbodyFirstPersonController>().enabled = false;
        UIManager.instance.HideReticule();
    }

    // Update is called once per frame
    void Update()
    {
        if(!start)
        {
            // A chaque fois que l'ennemi atteint le point il passe au suivant
            if (GameObject.Find("Player").transform.position == patrolPoints[currentPoint].position)
            {
                currentPoint = (currentPoint + 1) % patrolPoints.Length;
            }
            // Deplacement de l'ennemi
            GameObject.Find("Player").transform.position = Vector3.MoveTowards(GameObject.Find("Player").transform.position, patrolPoints[currentPoint].position, moveSpeed * Time.deltaTime);
        }
    }
}
