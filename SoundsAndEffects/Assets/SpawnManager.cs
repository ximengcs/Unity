using UnityEngine;

public class SpawnManager : MonoBehaviour {
    public GameObject obstaclePrefab;
    public Vector3 spawnPos = new Vector3(25, 0, 0);
    PlayerController playerControllerScript;

    private float startDelay = 2;
    private float intervalRate = 2;

    private void Start() {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, intervalRate);
    }

    private void SpawnObstacle() {
        if(!playerControllerScript.isGameOver)
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }
}
