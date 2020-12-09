using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//警告SEの再生処理　20201110
public class warning : MonoBehaviour
{
    // Start is called before the first frame update 20201110
    void Start()
    {
        
    }

    // Update is called once per frame 20201110
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "missile")
        this.GetComponent<AudioSource>().Play();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "missile")
        {
        this.GetComponent<AudioSource>().Stop();
        }
    }
}
