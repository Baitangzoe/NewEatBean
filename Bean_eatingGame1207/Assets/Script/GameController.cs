using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject BtnObj1;
    public GameObject BtnObj2;
    private bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        isOpen = true;
        Time.timeScale = 1;
    }
    public void BtnContrller()
    {
        if(!isOpen)
        {
            BtnObj1.SetActive(false);
            BtnObj2.SetActive(true);
            Time.timeScale = 1;
            isOpen = !isOpen;
        }
        else
        {
            BtnObj1.SetActive(true);
            BtnObj2.SetActive(false);
            Time.timeScale = 0;
            isOpen = !isOpen;
        }
    }
    public void BtnRestart()
    {
        SceneManager.LoadScene("SampleScene");
        DestoryScript.num = 0;
    }
    public void BtnNextlevel()
    {
        SceneManager.LoadScene("NextlevelScene");
        DestoryScript.num = 0;
    }
    public void BtnFirstScene()
    {
        SceneManager.LoadScene("FirstsScene");
        DestoryScript.num = 0;
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
