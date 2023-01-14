using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI textMachineGun;
    public TextMeshProUGUI textMissileLauncher;
    public TextMeshProUGUI textLaserBeamer;
    public Shop shop;

    // Start is called before the first frame update
    void Start()
    {
        textMachineGun.text = shop.standartTurret.textNameTurret;
        textMissileLauncher.text = shop.missileLauncher.textNameTurret;
        textLaserBeamer.text = shop.laserBeamer.textNameTurret;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
