using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ミサイルの移動制御 20201110
//ミサイルの与ダメージ処理 20201110
public class missilecontroller : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private GameObject explosion,Missile;
    [SerializeField] private int uptime,Horizontaltime,chasetime,atk;
    int i = 0;
    private bool chase = true;
    // Start is called before the first frame update 20201110
    void Start()
    {
        player = GameObject.Find("Fighter");
    }

    // Update is called once per frame 20201110
    void Update()
    {
        if (i >= 0 && i < uptime)
        {
            //垂直方向への移動 20201110
            this.transform.Translate(0, 0, 1.05f);
        } else if (this.i >= uptime && this.i < Horizontaltime + uptime)
        {
            if (i == uptime)
            {
                // 補完スピードを決める 20201110
                float speed = 20.0f;
                // ターゲット方向のベクトルを取得 20201110
                Vector3 relativePos = player.transform.position - this.transform.position;
                // 方向を、回転情報に変換 20201110
                Quaternion rotation = Quaternion.LookRotation(relativePos);
                rotation.x = 0;
                rotation.z = 0;
                // 現在の回転情報と、ターゲット方向の回転情報を補完する 20201110
                this.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed);
            }
            this.transform.Translate(0, 0, 1.05f);

        } else if (this.i >= Horizontaltime + uptime && this.i < chasetime+Horizontaltime + uptime)
        {
            if (chase == true)
            {
                //追尾 20201110
                // 補完スピードを決める 20201110
                float speed = 50.0f;
                // ターゲット方向のベクトルを取得 20201110
                Vector3 relativePos = player.transform.position - this.transform.position;
                // 方向を、回転情報に変換 20201110
                Quaternion rotation = Quaternion.LookRotation(relativePos);
                // 現在の回転情報と、ターゲット方向の回転情報を補完する 20201110
                this.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed);
            }
            this.transform.Translate(0, 0, 2.4f);
        }
        else
        {
            explosion.GetComponent<ParticleSystem>().Play();
            Destroy(Missile);
        }
        i++;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "player")
        {
            player.GetComponent<playermove>().getdamege(atk);
        }
        explosion.GetComponent<ParticleSystem>().Play();
        Destroy(Missile);
    }
    private void OnTriggerEnter(Collider other)
    {
        this.chase = false;
    }
}
