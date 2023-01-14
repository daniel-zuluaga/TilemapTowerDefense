using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    public void SelectNode(Node node)
    {
        selectedNode = node;
        turretToBuild = null;
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        selectedNode = null;
    }
}
