using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : MonoBehaviour {
    public float moveSpeed;
    Rigidbody playerRB;
    public Transform focalPoint;
    public GameObject powerUpIndicator;
    public bool hasPowerup;
    public GameObject powerUpPrefab;

    private void Start() {
        hasPowerup = false;
        playerRB = GetComponent<Rigidbody>();
    }

    private void Update() {

        float forwardInput = Input.GetAxisRaw("Vertical");
        if(forwardInput != 0) {
            playerRB.AddForce(focalPoint.forward * moveSpeed * forwardInput * Time.deltaTime);
        }

        if(powerUpIndicator != null)
            powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("PowerUp")) {
            hasPowerup = true;
            Destroy(other.gameObject);
            powerUpIndicator.SetActive(true);
            StartCoroutine(PowerUpCountDownRoutine());
        }
    }

    public float strengthForce = 15f;
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup) {
            Rigidbody enemyRB = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 direct = (collision.gameObject.transform.position - transform.position).normalized;
            enemyRB.AddForce(direct * strengthForce, ForceMode.Impulse);
        }
    }

    IEnumerator PowerUpCountDownRoutine() {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerUpIndicator.SetActive(false);
        Instantiate(powerUpPrefab, Vector3.zero, powerUpPrefab.transform.rotation);
    }
}
