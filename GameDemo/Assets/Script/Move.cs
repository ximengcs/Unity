using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    public Rigidbody rg;

    public float moveSpeed = 2000f;

    public float xSpeed = 20f;

    public void Update()
    {
        rg.AddForce(0, 0, moveSpeed * Time.deltaTime);

        if(Input.GetKey("a"))
        {
            rg.AddForce(-xSpeed, 0, 0);
        }

        if (Input.GetKey("d"))
        {
            rg.AddForce(xSpeed, 0, 0);
        }
    }
}
