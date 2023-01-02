using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseMachineGunTurret()
    {
        buildManager.SetTurretBuild(buildManager.turretPrefab);
    }

    public void PurchaseAnotherTurret()
    {
        buildManager.SetTurretBuild(buildManager.anotherTurretPrefab);
    }
}
