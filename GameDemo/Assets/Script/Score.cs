using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>
public class Score : MonoBehaviour
{

    public Transform player;
    public Text scoreText;

    public void Update()
    {
        scoreText.text = player.position.z.ToString("0");
    }

}
