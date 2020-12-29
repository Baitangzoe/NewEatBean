using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RankingList : MonoBehaviour
{
    public GameObject Rankingl;
    int Score;
    public Text scores;
    public Text Highscores;
    // Start is called before the first frame update
    void Start()
    {
        Rankingl.SetActive(false);
        Highscores.text = PlayerPrefs.GetInt("Score", Score).ToString();
    }
    public void BtnWrite()
    {
        Score = PlayerScript.fenshu;
        scores.text = Score.ToString();
        if (Score >PlayerPrefs .GetInt("Score"))
        {
            PlayerPrefs.SetInt("Score", Score);
            Highscores.text = Score.ToString();
            Debug.Log(Highscores.text);
        }
        else
        {
            Highscores .text = PlayerPrefs.GetInt("Score", Score).ToString();
        }
    }
    public void BtnRead()
    {
        PlayerPrefs.DeleteAll();
        Highscores.text = "0";
    }
    public void BtnScore()
    {
        Time.timeScale = 0;
        Rankingl.SetActive(true);
    }
    public void BtnClose()
    {
        Time.timeScale = 1;
        Rankingl.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
