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
    public TextMeshProUGUI textCostLaserBeamer;

    public static int lives;
    public int startLives = 100;

    // Start is called before the first frame update
    void Start()
    {
        Money = startMoney;
        lives = startLives;
        textCostStandardTurret.text = "$ " + Shop.instance.standartTurret.cost.ToString();
        textCostMissileLauncher.text = "$ " + Shop.instance.missileLauncher.cost.ToString();
        textCostLaserBeamer.text = "$ " + Shop.instance.laserBeamer.cost.ToString();
    }
}
