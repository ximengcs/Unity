using UnityEngine;

public class MoveLeft : MonoBehaviour {
    public float speed;

    PlayerController playerControllerScript;

    private float leftBounds = -15;

    private void Start() {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update() {
        if(!playerControllerScript.isGameOver)
            transform.Translate(Vector3.left * Time.deltaTime * speed);

        if(transform.position.x < leftBounds && gameObject.CompareTag("Obstacle"))
            Destroy(gameObject);
    }
}
