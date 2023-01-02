using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject turret;

    public Renderer rend;
    public Color defaultColor;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {
        if (buildManager.GetTurretBuild() == null)
            return;

        if(turret != null)
        {
            Debug.Log("can't build there!!");
            return;
        }

        GameObject turretToBuild = buildManager.GetTurretBuild();
        turret = Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    void OnMouseEnter()
    {
        if (buildManager.GetTurretBuild() == null)
            return;

        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = defaultColor;
    }
}
