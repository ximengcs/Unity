using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class EndScript : MonoBehaviour
{
    public GameObject UIComponent;

    private void OnCollisionEnter(Collision collision)
    {
        UIComponent.SetActive(true);
        FindObjectOfType<GameManager>().CompleteLevel();
    }

}
