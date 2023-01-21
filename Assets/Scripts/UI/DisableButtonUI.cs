using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableButtonUI : MonoBehaviour
{
    public GameObject buttonUpgradeRange;
    public GameObject buttonUpgradeDamage;
    public GameObject buttonBGRangeDisable;
    public GameObject buttonBGDamageDisable;

    private void Start()
    {
        ActiveAllButtonUpgraded();
    }

    public void ActiveAllButtonUpgraded()
    {
        buttonUpgradeDamage.SetActive(true);
        buttonUpgradeRange.SetActive(true);
        buttonBGRangeDisable.SetActive(false);
        buttonBGDamageDisable.SetActive(false);
    }


    public void ActiveButtonUpgradeGeneral()
    {
        buttonUpgradeRange.SetActive(false);
        buttonBGRangeDisable.SetActive(true);
        buttonUpgradeDamage.SetActive(false);
        buttonBGDamageDisable.SetActive(true);
    }

}
