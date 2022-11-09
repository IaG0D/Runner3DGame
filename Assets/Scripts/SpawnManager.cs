using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public GameObject obstaclePrefab;
    public GameObject obstaclePrefab1;
    public GameObject obstaclePrefab2;
    public GameObject obstaclePrefab3;
    private List<GameObject> obstacles = new List<GameObject>();
    private Vector3 spawnPosition = new Vector3(25, 0, 0);
    // Start is called before the first frame update
    void Start() {
        obstacles.Add(obstaclePrefab);
        obstacles.Add(obstaclePrefab1);
        obstacles.Add(obstaclePrefab2);
        obstacles.Add(obstaclePrefab3);
        InvokeRepeating("SpawnObstacle", GameController.TimeToSpawn, GameController.TimeToSpawn);
    }

    // Update is called once per frame
    void Update() {

    }
    void SpawnObstacle() {
        int random = Random.Range(0, 3);
        if (!GameController.gameOver) {
            Instantiate(obstacles[random], spawnPosition, obstaclePrefab.transform.rotation);
            Debug.Log(GameController.speed);
            Debug.Log(GameController.TimeToSpawn);
        }

    }
    
}
