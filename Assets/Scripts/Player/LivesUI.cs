using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesUI : MonoBehaviour
{
    public TextMeshProUGUI textLives;

    // Update is called once per frame
    void Update()
    {
        textLives.text = "Lives: " + PlayerStats.lives.ToString();
    }
}
