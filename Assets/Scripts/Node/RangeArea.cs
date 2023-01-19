using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeArea : MonoBehaviour
{
    public GameObject rangeAreaObj;

    private void Start()
    {
        rangeAreaObj.SetActive(false);
    }

    public void ActiveAreaRange(Node _target)
    {
        rangeAreaObj.SetActive(true);
        rangeAreaObj.transform.position = new Vector3(
            _target.transform.position.x,
            _target.transform.position.y + 0.5f,
            _target.transform.position.z
            );
        rangeAreaObj.transform.localScale =
            new Vector3(
                _target.selectTurret.turretPrefab.GetComponent<Turret>().range * 2,
                0.01f,
                _target.selectTurret.turretPrefab.GetComponent<Turret>().range * 2
               );
    }
}
