using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGameScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void BtnStart()
    {
        SceneManager.LoadScene("SampleScene");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
