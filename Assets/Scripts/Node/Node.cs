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

    [HideInInspector]
    public Renderer rend;
    public Color defaultColor;

    public BuildManager buildManager;
    public RangeArea range;

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
            return;

        buildManager.TurretBuildOn(this);
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
