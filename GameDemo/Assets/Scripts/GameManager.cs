using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 
/// </summary>
public class GameManager : MonoBehaviour
{
    public GameObject UIPlane;

    public bool gameoverFlag = false;

    public float restartDelayTime = 2f;

    public void GameOver()
    {
        if (!gameoverFlag)
        {
            gameoverFlag = true;
            Invoke("Restart", restartDelayTime);
        }
    }

    public void CompleteLevel()
    {
        UIPlane.SetActive(true);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
