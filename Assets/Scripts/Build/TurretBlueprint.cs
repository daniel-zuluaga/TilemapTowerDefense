using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class TurretBlueprint
{
    public GameObject turretPrefab;
    public GameObject turretPrefabRange;
    public GameObject turretPrefabDamage;
    public int cost;
    public string textNameTurret;
    public int upgradeRange;
    public int upgradeDamage;
    public int sellTurret;
    public string descriptionUpgradeDamage;
}
