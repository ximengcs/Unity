using UnityEngine;

public class Motor : MonoBehaviour
{
    public float speed;
    public Transform cam;
    Rigidbody playerRB;

    private void Start() {
        playerRB = GetComponent<Rigidbody>();
    }

    private void Update() {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if(horizontal != 0) {
            playerRB.AddForce(cam.transform.right * horizontal * speed);
        }
        if(vertical != 0) {
            playerRB.AddForce(cam.transform.forward * vertical * speed);
        }
    }
}
