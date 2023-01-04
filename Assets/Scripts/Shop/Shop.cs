using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standartTurret;
    public TurretBlueprint missileLauncher;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectMachineGunTurret()
    {
        buildManager.SelectTurretToBuild(standartTurret);
    }

    public void SelectMisileLauncher()
    {
        buildManager.SelectTurretToBuild(missileLauncher);
    }
}
