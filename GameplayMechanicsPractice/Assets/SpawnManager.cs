using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public static int enemyCount = 3;
    public int maxEnemy = 3;
    float randnum = 9;

    private void Start() {
        SpawnEnemyWave(3);
    }

    private Vector3 GenerateSpawnPoint() {
        float randomX = Random.Range(-randnum, randnum);
        float randomZ = Random.Range(-randnum, randnum);
        return new Vector3(randomX, 0, randomZ);
    }

    private void SpawnEnemyWave(int amount) {
        for(int i = 0; i < amount; i++)
            Instantiate(enemyPrefab, GenerateSpawnPoint(), enemyPrefab.transform.rotation);
    }

    private void Update() {
        if(enemyCount < maxEnemy) {
            SpawnEnemyWave(maxEnemy - enemyCount);
            enemyCount += maxEnemy - enemyCount;
        }
    }
}
