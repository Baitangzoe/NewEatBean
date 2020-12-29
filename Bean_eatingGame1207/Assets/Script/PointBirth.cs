using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBirth : MonoBehaviour
{
    public GameObject Obj;
    GameObject[] ObjPoint = new GameObject[4];
    // Start is called before the first frame update
    void Start()
    {
        int count = Obj.transform.childCount;
        for (int i = 0; i < count; i++)
        {
            ObjPoint[i] = Obj.transform.GetChild(i).gameObject;
        }
        InvokeRepeating("pointCHange", 1, 3);
    }
    public void pointCHange()
    {
        int point = Random.Range(0, 4);
        GameObject cols = Resources.Load("na", typeof(GameObject)) as GameObject;
        if (ObjPoint[point].transform.childCount == 0)
        {
            GameObject pointObj;
            pointObj = Instantiate(cols);
            pointObj.transform.parent = Obj.transform.GetChild(point).transform;
            pointObj.transform.localPosition = Vector3.zero;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
