using UnityEngine;

public class PlayerController : MonoBehaviour {
    Rigidbody playerRb;
    public float force;
    public float gravityModifier;
    bool isGround;
    public bool isGameOver;
    Animator playerAnim;
    public ParticleSystem boomParticle;
    public ParticleSystem trickParticle;

    private void Start() {
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        isGround = true;
        isGameOver = false;
        boomParticle.Stop();
        trickParticle.Stop();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space) && isGround && !isGameOver) {
            playerRb.AddForce(Vector3.up * force, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            isGround = false;
            trickParticle.Stop();
        }

        if(trickParticle.isStopped && !isGameOver)
            trickParticle.Play();
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.collider.CompareTag("Ground"))
            isGround = true;
        else if(collision.collider.CompareTag("Obstacle")) {
            isGameOver = true;
            Debug.Log("Game Over");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            boomParticle.Play();
            trickParticle.Stop();
        }
    }
}
