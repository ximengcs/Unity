using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotateSpeed;

    private void Update() {
        float input = Input.GetAxisRaw("Horizontal");
        if(input != 0) {
            transform.Rotate(Vector3.up, rotateSpeed * input * Time.deltaTime);
        }
    }
}
