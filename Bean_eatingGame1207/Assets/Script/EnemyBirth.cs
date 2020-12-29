using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBirth : MonoBehaviour
{
    public Transform Obj;
    public GameObject []enemy;
    public Transform RqObj;
    private int sum = 0;//当前敌人数量
    private int maxNum = 3;//生成敌人最大数量

    // Start is called before the first frame update
    void Start()
    {
        Invoke("EnemyBirths",1f);
    }
    private void EnemyBirths()
    {
        for (int i = 0; i <maxNum; i++)
        {
            Instantiate(enemy[Random.Range(0, enemy.Length)], RqObj.TransformPoint(RandomFloat(), RandomFloat(), RandomFloat()), Quaternion.identity, Obj);
            sum += i;
        }
    }
    private float RandomFloat()
    {
        return Random.Range(-0.5f, 0.5f);
    }
}
