using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//制限時間UIの減少処理 20201110
//ゲームプレイ画面のシーン変更処理 2020110
public class timercontroller : MonoBehaviour
{
    GameObject texttimer;
    [SerializeField] double gametime; 
    // Start is called before the first frame update 20201110
    void Start()
    {
        texttimer = GameObject.Find("time");
    }

    // Update is called once per frame 20201110
    void Update()
    {
        this.gametime -= Time.deltaTime;
        this.texttimer.GetComponent<Text>().text = "time : " + this.gametime.ToString("F3");
        if(gametime <= 0)
        {
            SceneManager.LoadScene("GAME OVER");
        }
    }

}
