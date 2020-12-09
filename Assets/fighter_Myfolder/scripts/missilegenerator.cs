using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ミサイルの生成処理 20201110
public class explosiongenerator : MonoBehaviour
{
    public GameObject explosion;
    public int number;
    public void playexplosion()
    {
        for(int i = 0;i< number;i++)
        {
            GameObject go = Instantiate(explosion) as GameObject;
            go.transform.position = this.transform.position + new Vector3 (Random.Range(0.0f, 8.0f), Random.Range(0.0f, 8.0f), Random.Range(0.0f,8.0f));
        }
    }
}
