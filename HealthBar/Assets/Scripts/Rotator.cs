using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed;

    private void Update() {
        transform.Rotate(Vector3.up, speed);
    }
}
