using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI textValueRounds;

    void OnEnable()
    {
        textValueRounds.text = PlayerStats.RoundsPlayer.ToString();
    }
}
