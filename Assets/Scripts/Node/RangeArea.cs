using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeArea : MonoBehaviour
{
    public GameObject rangeArea;

    private void Start()
    {
        rangeArea.SetActive(false);
    }

    public void ActiveAreaRange(Node _target)
    {
        rangeArea.SetActive(true);
        rangeArea.transform.position = new Vector3(
            _target.transform.position.x,
            _target.transform.position.y + 0.5f,
            _target.transform.position.z
            );
        rangeArea.transform.localScale =
            new Vector3(
                Turret.instance.range * 2,
                transform.localScale.y,
                Turret.instance.range * 2
               );
    }
}
