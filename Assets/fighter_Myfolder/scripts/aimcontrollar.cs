using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//照準UIの座標制御 20201110
public class aimcontrollar : MonoBehaviour
{
    [SerializeField]private Transform targetTfm;
    [SerializeField]private GameObject reticle;
    private GameObject player;

    private RectTransform myRectTfm;
    private Vector3 offset = new Vector3(0, 1.5f, 0);

    void Start()
    {
        myRectTfm = GetComponent<RectTransform>();
        player = GameObject.Find("Fighter");
    }

    void LateUpdate()
    {
        myRectTfm.position
            = RectTransformUtility.WorldToScreenPoint(Camera.main, targetTfm.position + offset);
        if(player.GetComponent<playermove>().getalive() == false)
        {
            Destroy(reticle);
        }
    }
}
