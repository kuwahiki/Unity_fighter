using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ミニマップの移動処理 20201110
public class minmapcontroller : MonoBehaviour
{
    [SerializeField] private GameObject target;
    Vector3 trans;
    [SerializeField] private int positionY = 250;
    [SerializeField] private bool canRotation = true;
    // Start is called before the first frame update 20201110
    void Start()
    {
        trans = target.transform.position;
        trans.y = positionY;
        this.transform.position = trans;
    }

    // Update is called once per frame 20201110
    void Update()
    {
        trans = target.transform.position;
        trans.y = positionY;
        this.transform.position = trans;
        if (canRotation == true)
        {
            //ターゲットと回転を合わせる 20201110
            float rorate = target.transform.eulerAngles.y;
            this.transform.eulerAngles = new Vector3(0,rorate,0);
        }
    }
}
