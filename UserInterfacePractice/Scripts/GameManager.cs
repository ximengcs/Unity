using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    private float spawnRate = 1.0f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public GameObject restart;
    public List<GameObject> targets;
    public GameObject startScreen;
    float score = 0;
    [HideInInspector]
    public bool isGameActive;

    private void Start() {
    }

    private IEnumerator SpawnTarget() {
        while(isGameActive) {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(float score) {
        this.score += score;
        scoreText.text = "Score:" + this.score;
    }

    public void GameOver() {
        isGameActive = false;
        restart.SetActive(true);
        gameOverText.gameObject.SetActive(true);
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty) {
        startScreen.SetActive(false);
        spawnRate /= difficulty;
        isGameActive = true;
        gameOverText.gameObject.SetActive(false);
        restart.SetActive(false);
        score = 0;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }
}
