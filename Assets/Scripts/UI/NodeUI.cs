using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUI : MonoBehaviour
{
    public static NodeUI instance;

    private void Awake()
    {
        instance = this;
    }

    private Node target;

    public GameObject canvasInfoUpgrade;
    public GameObject gameObjectShop;
    public RangeArea range;

    private void Start()
    {
        canvasInfoUpgrade.SetActive(false);
        gameObjectShop.SetActive(true);
    }

    public void SetTarget(Node _target)
    {
        target = _target;
    }

    public void DisableInfoUpgrade()
    {
        range.rangeArea.SetActive(false);
        canvasInfoUpgrade.SetActive(false);
        gameObjectShop.SetActive(true);
    }

    public void UpgradeRangeTurret()
    {
        Turret.instance.range += 2;
        range.rangeArea.transform.localScale = new Vector3(
            Turret.instance.range * 2,
            range.rangeArea.transform.localScale.y,
            Turret.instance.range * 2
           );
    }

    public void UpgradeDamageTurret()
    {
        if(Turret.instance.useLaser == true)
        {
            Turret.instance.damageOverTime += 5;
        }
        else
        {
            Turret.instance.bulletPrefab.GetComponent<Bullet>().damageEnemy += 5;
        }
    }
}
