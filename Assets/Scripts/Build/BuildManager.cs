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

    void Start()
    {
        turretToBuild = turretPrefab;
    }

    private GameObject turretToBuild;

    public GameObject GetTurretBuild()
    {
        return turretToBuild;
    }
}