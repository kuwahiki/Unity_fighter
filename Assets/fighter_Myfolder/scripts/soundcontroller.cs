using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SEの終了時間設定処理 20201110
public class soundcontroller : MonoBehaviour
{
    [SerializeField] private double endtime = 0.0;
    private double time = 0,end;
    GameObject player;
    // Start is called before the first frame update 20201110
    void Start()
    {
        player = GameObject.Find("Fighter");

    }

    // Update is called once per frame 20201110
    void Update()
    {
        
        time = AudioSettings.dspTime;
        if (player.GetComponent<playermove>().damege == true)
        {
            end = time + endtime;
        }
        this.GetComponent<AudioSource>().SetScheduledEndTime(end);
    }
}
