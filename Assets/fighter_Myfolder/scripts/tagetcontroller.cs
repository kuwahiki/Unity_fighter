using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//マーカーUIの移動制御 20201110
public class tagetcontroller : MonoBehaviour
{
    [SerializeField]public Transform targetObject;
    [SerializeField]private  GameObject target;
    private RectTransform uiImage;

    void Start()
    {
        uiImage = GetComponent<RectTransform>();
    }

    void Update()
    {
        if(targetObject == null)
        {
            Destroy(target);
        }
            uiImage.position
                = RectTransformUtility.WorldToScreenPoint(Camera.main, targetObject.position);
     
    }
    private void OnBecameInvisible()
    {
        Destroy(target);
    }

}
