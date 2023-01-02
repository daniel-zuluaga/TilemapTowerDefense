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

    public GameObject turretPrefab;
    public GameObject anotherTurretPrefab;

    private GameObject turretToBuild;

    public GameObject GetTurretBuild()
    {
        return turretToBuild;
    }

    public void SetTurretBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
}
