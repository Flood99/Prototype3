using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPosition;
    public float speed = 5;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left*speed*Time.deltaTime);
        }
       
        if(transform.position.x < startPosition.x - 50)
        {
            transform.position = startPosition;
        }
    }
}
