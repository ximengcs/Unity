using UnityEngine;

public class Target : MonoBehaviour {
    private GameManager gameManager;
    public ParticleSystem explosionParticle;
    private Rigidbody targetRB;
    private float minForce = 12, maxForce = 16;
    private float maxTorque = 10;
    private float maxPosx = 4, posy = -6;
    public float pointValue;

    private void Start() {
        targetRB = GetComponent<Rigidbody>();
        targetRB.AddForce(RandomForce(), ForceMode.Impulse);
        targetRB.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomPos();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private Vector3 RandomForce() {
        return Vector3.up * Random.Range(minForce, maxForce);
    }

    private float RandomTorque() {
        return Random.Range(-maxTorque, maxTorque);
    }

    private Vector3 RandomPos() {
        return new Vector3(Random.Range(-maxPosx, maxPosx), posy);
    }

    // 当触发到Sensor时Destroy
    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
        if(gameObject.CompareTag("Good"))
            gameManager.GameOver();
    }

    private void OnMouseDown() {
        if(gameManager.isGameActive) {
            Destroy(gameObject);
            if(gameObject.CompareTag("Bad")) {
                gameManager.GameOver();
            }
            Instantiate(explosionParticle, transform.position, transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }
}
