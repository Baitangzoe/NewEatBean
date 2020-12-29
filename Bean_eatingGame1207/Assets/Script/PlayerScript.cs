using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerScript : MonoBehaviour
{
    GameObject player;
    private int lifeTimes = 2;
    public GameObject objStart;
    private bool isBool = true;
    public GameObject luob1;
    public GameObject luob2;
    public Text counts;
    private int gold;
    public GameObject GameOver;
    public GameObject GameSb;
    public Transform dousum;
    public static int fenshu;
    // Start is called before the first frame update
    void Start()
    {
        GameOver.SetActive(false);
        GameSb.SetActive(false);
        player = Instantiate(Resources.Load("Player", typeof(GameObject)) as GameObject);
        player.transform.SetParent(this.transform);
        player.transform.localPosition = Vector3.zero;
    }
    public void BtnBirth()
    {
        if (objStart.transform.childCount == 0&&isBool ==true)
        {
            player = Instantiate(Resources.Load("Player", typeof(GameObject)) as GameObject);
            player.transform.SetParent(this.transform);
            player.transform.localPosition = Vector3.zero;
            lifeTimes--;
            Debug.Log(lifeTimes);
            if (lifeTimes == 2)
            {
                luob1.SetActive(true);
                luob2.SetActive(false);
            }
            else if (lifeTimes == 1)
            {
                luob1.SetActive(false);
                luob2.SetActive(true);
            }
            else if (lifeTimes == 0)
            {
                isBool = false;
                luob1.SetActive(false);
                luob2.SetActive(false);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (lifeTimes ==0&&transform.childCount == 0)
        {
            Time.timeScale = 0;
            GameSb.SetActive(true);
        }
        gold = DestoryScript.num;
        counts.text = "" + gold;
        //if(dousum .childCount < 200)
        //{
        //    Time.timeScale = 0;
        //    GameOver.SetActive(true);
        //}
        if (DestoryScript.win==true)
        {
            fenshu = gold;
            Time.timeScale = 0;
            GameOver.SetActive(true);
            DestoryScript.win = false;
        }
    }
}
