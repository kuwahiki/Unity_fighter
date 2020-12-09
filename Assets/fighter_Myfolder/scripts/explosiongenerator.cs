using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ミサイルの生成処理 20201110
public class missilegenerator : MonoBehaviour
{
    public GameObject Missile;
    private bool canshot;
    // Start is called before the first frame update 20201110
    void Start()
    {
        canshot = true;
    }

    // Update is called once per frame 20201110
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(canshot == true)
        {
            GameObject go = Instantiate(Missile) as GameObject;
            go.transform.position = this.transform.position + new Vector3 (0,0,10);
            canshot = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        canshot = true;
    }
}
