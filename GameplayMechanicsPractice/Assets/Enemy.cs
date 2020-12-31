using UnityEngine;

public class Enemy : MonoBehaviour {
    Rigidbody enemyRb;
    GameObject player;
    public float speed;

    private void Start() {
        player = GameObject.FindWithTag("Player");
        enemyRb = GetComponent<Rigidbody>();
    }

    private void Update() {

        if(transform.position.y < -10) {
            Destroy(gameObject);
            SpawnManager.enemyCount--;
        }

        if(player != null) {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            enemyRb.AddForce(lookDirection * speed);
        }

    }
}
