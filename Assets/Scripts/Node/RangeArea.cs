//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class RangeArea : MonoBehaviour
//{
//    public GameObject rangeArea;

//    private void Start()
//    {
//        rangeArea.SetActive(false);
//    }

//    public void ActiveAreaRange(Node node)
//    {
//        rangeArea.SetActive(true);
//        rangeArea.transform.position = new Vector3(node.transform.position.x, node.transform.position.y + 0.8f, node.transform.position.z);
//        rangeArea.transform.localScale =
//            new Vector3(BuildManager.instance.turretToBuild.range, transform.localScale.y, BuildManager.instance.turretToBuild.range);
//    }

//    public void DisableAreaRange()
//    {
//        rangeArea.SetActive(false);
//    }
//}
