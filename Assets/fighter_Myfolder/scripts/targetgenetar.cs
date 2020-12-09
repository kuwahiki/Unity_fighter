using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//マーカーUIの生成処理 20201110
public class targetgenetar : MonoBehaviour
{
    [SerializeField] private GameObject targetObject,targetimage,canvas;
    private bool visiable;
    private GameObject ui;
    private Transform enemy;
    // Start is called before the first frame update 20201110
    void Start()
    {
        visiable = true;
        enemy = targetObject.transform;
    }

    // Update is called once per frame 20201110
    void Update()
    {
        
    }

    private void OnBecameVisible()
    {
        if (visiable == true)
        {
            ui = Instantiate(targetimage) as GameObject;
            ui.transform.SetParent(canvas.transform, false);
            ui.GetComponent<tagetcontroller>().targetObject = this.enemy;
            visiable = false;
            Debug.Log("in");
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(ui);
        visiable = true;
        Debug.Log("out");
        
    }
}
