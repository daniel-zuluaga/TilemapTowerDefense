using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public GameObject buildEffect;

    public TurretBlueprint turretToBuild;
    private Node selectedNode;
    public TextMeshProUGUI textNameTurretInfo;
    public RangeArea rangeArea;

    public NodeUI nodeUI;

    public bool CanBuild
    {
        get
        {
            return turretToBuild != null;
        }
    }

    public bool HasMoney
    {
        get
        {
            return PlayerStats.Money >= turretToBuild.cost;
        }
    }

    public void TurretBuildOn(Node node)
    {
        if(PlayerStats.Money < turretToBuild.cost)
           return;

        PlayerStats.Money -= turretToBuild.cost;

        GameObject buildEffectObj = Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(buildEffectObj, 1f);
        GameObject turretPrefab = Instantiate(turretToBuild.turretPrefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turretPrefab;
        node.selectTurret = turretToBuild;
    }

    public void SelectNode(Node node)
    {
        textNameTurretInfo.text = node.selectTurret.textNameTurret;
        selectedNode = node;
        turretToBuild = null;
        node.rend.material.color = node.hoverColor;
        rangeArea.ActiveAreaRange(node);

        nodeUI.SetTarget(node);
        nodeUI.canvasInfoUpgrade.SetActive(true);
        nodeUI.gameObjectShop.SetActive(false);
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        selectedNode = null;
    }
}
