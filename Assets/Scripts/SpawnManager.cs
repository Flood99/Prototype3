using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private Vector3 spawnPos = new Vector3(25,0,0);
    private float startDelay = 2;
    private float repeatDelay = 2;
    public GameObject[] obstaclePrefabs;
    private PlayerController playerControllerScript;
   
    // Start is called before the first frame update
    void Start()
    {
       InvokeRepeating("SpawnObstacle",startDelay,repeatDelay);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObstacle()
    {
        int random = Random.Range(0,obstaclePrefabs.Length);
        if(playerControllerScript.gameOver == false)
        {
          Instantiate(obstaclePrefabs[random],spawnPos,obstaclePrefabs[random].transform.rotation);
        }
    }
}
