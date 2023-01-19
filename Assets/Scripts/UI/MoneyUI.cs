using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    public TextMeshProUGUI textValueMoney;

    // Update is called once per frame
    void Update()
    {
        textValueMoney.text = ": " + PlayerStats.Money.ToString();
    }
}
