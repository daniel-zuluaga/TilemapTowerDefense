using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Color notCanBuildTurret;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret;
    public TurretBlueprint selectTurret;
    public bool isUpgraded = false;

    [HideInInspector]
    public Renderer rend;
    public Color defaultColor;

    public BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
        buildManager.nodeUI.gameObjectShop.SetActive(true);
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        BuildTurret(buildManager.GetTurretBlueprint());
    }

    void BuildTurret(TurretBlueprint turretBlueprint)
    {
        if (PlayerStats.Money < turretBlueprint.cost)
            return;
        PlayerStats.Money -= turretBlueprint.cost;
        GameObject buildEffectObj = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(buildEffectObj, 1f);
        GameObject turretPrefab = Instantiate(turretBlueprint.turretPrefab, GetBuildPosition(), Quaternion.identity);
        turret = turretPrefab;
        selectTurret = turretBlueprint;
    }

    public void UpgradeTurretRange()
    {
        if (PlayerStats.Money < selectTurret.upgradeRange)
            return;
        PlayerStats.Money -= selectTurret.upgradeRange;
        GameObject buildEffectObj = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(buildEffectObj, 1f);
        Destroy(turret);
        GameObject turretPrefab = Instantiate(selectTurret.turretPrefabRange, GetBuildPosition(), Quaternion.identity);
        turret = turretPrefab;
        isUpgraded = true;
    }

    public void UpgradeTurretDamage()
    {
        if (PlayerStats.Money < selectTurret.upgradeDamage)
            return;
        PlayerStats.Money -= selectTurret.upgradeDamage;
        GameObject buildEffectObj = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(buildEffectObj, 1f);
        Destroy(turret);
        GameObject turretPrefab = Instantiate(selectTurret.turretPrefabDamage, GetBuildPosition(), Quaternion.identity);
        turret = turretPrefab;
        isUpgraded = true;
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (turret != null)
        {
            rend.material.color = notCanBuildTurret;
            return;
        }

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = defaultColor;
    }
}
