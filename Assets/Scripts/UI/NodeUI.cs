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
        target.UpgradeTurretRange();
        range.rangeAreaObj.transform.localScale = new Vector3(
            target.selectTurret.turretPrefab.GetComponent<Turret>().range * 2,
            range.rangeAreaObj.transform.localScale.y,
            target.selectTurret.turretPrefab.GetComponent<Turret>().range * 2
           );
    }

    public void UpgradeDamageTurret()
    {
        target.UpgradeTurretDamage();
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
