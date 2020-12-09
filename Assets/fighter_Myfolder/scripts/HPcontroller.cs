using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//HPバーの減少処理 20201110
public class HPcontroller : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update 20201110
    void Start()
    {
        player = GameObject.Find("Fighter");
    }

    // Update is called once per frame 20201110
    void Update()
    {
        this.GetComponent<Image>().fillAmount = player.GetComponent<playermove>().percentHP();
    }
}
