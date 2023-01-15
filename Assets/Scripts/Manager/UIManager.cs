using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI textMachineGun;
    public TextMeshProUGUI textMissileLauncher;
    public TextMeshProUGUI textLaserBeamer;

    // Start is called before the first frame update
    void Start()
    {
        textMachineGun.text = Shop.instance.standartTurret.textNameTurret;
        textMissileLauncher.text = Shop.instance.missileLauncher.textNameTurret;
        textLaserBeamer.text = Shop.instance.laserBeamer.textNameTurret;
    }
}
