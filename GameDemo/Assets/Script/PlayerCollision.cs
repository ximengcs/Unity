using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public Move moveScript;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
            moveScript.enabled = false;
            FindObjectOfType<GameManager>().GameOver();
        }
    }

    private void Update()
    {
        if (transform.position.y < -1f)
            FindObjectOfType<GameManager>().GameOver();
    }
}
