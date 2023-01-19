using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NodeUI : MonoBehaviour
{
    public static NodeUI instance;

    private void Awake()
    {
        instance = this;
    }

    public Node target;

    public GameObject canvasInfoUpgrade;
    public GameObject gameObjectShop;
    public TextMeshProUGUI textUpgradeRange;
    public TextMeshProUGUI textUpgradeDamage;
    public TextMeshProUGUI textsSellTurretValue;


    public RangeArea range;

    void Start()
    {
        canvasInfoUpgrade.SetActive(false);
        gameObjectShop.SetActive(true);
    }

    public void ChangeValueUpgrade(Node _target)
    {
        int sellTurretPrefab = _target.selectTurret.sellTurret;
        textUpgradeRange.text = "Upgrade\n" + _target.selectTurret.upgradeRange.ToString();
        textUpgradeDamage.text = "Upgrade\n" + _target.selectTurret.upgradeDamage.ToString();
        textsSellTurretValue.text = "Sell\n" + sellTurretPrefab.ToString();
    }

    public void SetTarget(Node _target)
    {
        target = _target;
    }

    public void DisableInfoUpgrade()
    {
        range.rangeAreaObj.SetActive(false);
        canvasInfoUpgrade.SetActive(false);
        gameObjectShop.SetActive(true);
    }

    public void UpgradeRangeTurret()
    {
        int upgradeRangeCost = target.selectTurret.upgradeRange;
        if (PlayerStats.Money < upgradeRangeCost)
            return;
        PlayerStats.Money -= upgradeRangeCost;
        Turret.instance.range += 3;
        GameObject buildEffectUpdate = Instantiate(target.buildManager.buildEffect, target.transform.position, target.transform.rotation);
        range.rangeAreaObj.transform.localScale = new Vector3(
            target.selectTurret.turretPrefab.GetComponent<Turret>().range * 2,
            range.rangeAreaObj.transform.localScale.y,
            target.selectTurret.turretPrefab.GetComponent<Turret>().range * 2
           );
        Destroy(buildEffectUpdate, 0.8f);
    }

    public void UpgradeDamageTurret()
    {
        int upgradeDamageCost = target.selectTurret.upgradeDamage;
        if (PlayerStats.Money < upgradeDamageCost)
            return;
        if (Turret.instance.useLaser == true)
        {
            PlayerStats.Money -= upgradeDamageCost;
            Turret.instance.damageOverTime += 8;
        }
        else
        {
            PlayerStats.Money -= upgradeDamageCost;
            Turret.instance.bulletPrefab.GetComponent<Bullet>().damageEnemy += 6;
        }
        GameObject buildEffectUpdate = Instantiate(target.buildManager.buildEffect, target.transform.position, target.transform.rotation);
        Destroy(buildEffectUpdate, 0.8f);
    }

    public void sellTurret()
    {
        int sellTurretPrefab = target.selectTurret.sellTurret;

        PlayerStats.Money += sellTurretPrefab;

        target.selectTurret = null;
        Destroy(target.turret);
        DisableInfoUpgrade();
    }
}
