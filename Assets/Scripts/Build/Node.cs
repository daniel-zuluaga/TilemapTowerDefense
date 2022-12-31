using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;

    [SerializeField]
    private GameObject turret;

    public Renderer rend;
    public Color defaultColor;

    void OnMouseDown()
    {
        if(turret != null)
        {
            Debug.Log("can't build there!!");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretBuild();
        turret = Instantiate(turretToBuild, transform.position, transform.rotation);
    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = defaultColor;
    }
}
