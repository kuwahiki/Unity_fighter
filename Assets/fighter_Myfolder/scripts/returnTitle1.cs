using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//操作方法画面のシーン変更処理 20201110
public class returnTitle1 : MonoBehaviour
{
    // Start is called before the first frame update 20201110
    void Start()
    {
        
    }

    // Update is called once per frame 20201110
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("GameTitle");
        }
    }
}
