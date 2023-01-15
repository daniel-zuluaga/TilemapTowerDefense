using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUI : MonoBehaviour
{
    private Node target;

    public GameObject canvasInfoUpgrade;
    public GameObject gameObjectShop;
    //public RangeArea rangeArea;

    private void Start()
    {
        canvasInfoUpgrade.SetActive(false);
        gameObjectShop.SetActive(true);
    }

    public void SetTarget(Node _target)
    {
        target = _target;
        //rangeArea.ActiveAreaRange(_target);
    }

    public void DisableInfoUpgrade()
    {
        canvasInfoUpgrade.SetActive(false);
        gameObjectShop.SetActive(true);
        //rangeArea.DisableAreaRange();
    }
}
