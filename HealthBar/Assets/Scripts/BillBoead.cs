using UnityEngine;

public class BillBoead : MonoBehaviour
{
    public Transform cam;

    private void LateUpdate() {
        transform.LookAt(transform.position + cam.forward);
    }
}
