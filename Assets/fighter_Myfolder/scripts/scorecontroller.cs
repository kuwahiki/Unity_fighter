using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//スコアUIの表示処理 20201110
public class scorecontroller : MonoBehaviour
{
    GameObject player,scoretext;
    private int score = 0;

    // Start is called before the first frame update 20201110
    void Start()
    {
        player = GameObject.Find("Fighter");
        scoretext = GameObject.Find("score");
    }

    // Update is called once per frame 20201110
    void Update()
    {
        score = player.GetComponent<playermove>().getscore();
        scoretext.GetComponent<Text>().text = "score:" + score;
    }
}
