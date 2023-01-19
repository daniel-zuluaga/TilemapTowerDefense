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
    public TurretBlueprint defaultTurret;
    public TurretBlueprint turretToBuild;
    public Node selectedNode;
    public TextMeshProUGUI textNameTurretInfo;
    public TextMeshProUGUI textDescriptionUpgradeDamage;
    public RangeArea range;

    public NodeUI nodeUI;

    private void Start()
    {
        turretToBuild = defaultTurret;
    }

    void Update()
    {
        if (turretToBuild == null)
        {
            turretToBuild = defaultTurret;
        }
    }

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

    public void SelectNode(Node node)
    {
        textNameTurretInfo.text = node.selectTurret.textNameTurret;
        textDescriptionUpgradeDamage.text = node.selectTurret.descriptionUpgradeDamage;
        selectedNode = node;
        turretToBuild = null;
        node.rend.material.color = node.hoverColor;
        node.buildManager.GetComponent<RangeArea>().ActiveAreaRange(node);
        nodeUI.ChangeValueUpgrade(node);

        nodeUI.SetTarget(node);
        nodeUI.canvasInfoUpgrade.SetActive(true);
        nodeUI.gameObjectShop.SetActive(false);
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        selectedNode = null;
    }

    public TurretBlueprint GetTurretBlueprint()
    {
        return turretToBuild;
    }
}
