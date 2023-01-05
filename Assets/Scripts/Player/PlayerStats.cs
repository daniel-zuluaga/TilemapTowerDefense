using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 550;
    public TextMeshProUGUI textCostStandardTurret;
    public TextMeshProUGUI textCostMissileLauncher;

    // Start is called before the first frame update
    void Start()
    {
        Money = startMoney;
        textCostStandardTurret.text = "$ " + Shop.instance.standartTurret.cost.ToString();
        textCostMissileLauncher.text = "$ " + Shop.instance.missileLauncher.cost.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
