using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//タイトル画面のシーン変更処理 20201110
public class changeScene : MonoBehaviour
{
    // Start is called before the first frame update 20201110
    void Start()
    {
        
    }

    // Update is called once per frame 20201110
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("GamePlay");
        }
        
    }
    public void ButtonDown()
    {
        SceneManager.LoadScene("GameHowPlay");
    }
}
