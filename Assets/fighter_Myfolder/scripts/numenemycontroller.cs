using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//残り敵数UIの表示処理 20201110
public class numenemycontroller : MonoBehaviour
{
    GameObject player,enemy;
    // Start is called before the first frame update 20201110
    void Start()
    {
        player = GameObject.Find("Fighter");
        enemy = GameObject.Find("numenemy");
    }

    // Update is called once per frame 20201110
    void Update()
    {
        enemy.GetComponent<Text>().text = "enemy:" + player.GetComponent<playermove>().enemynum.ToString();
    }
}
