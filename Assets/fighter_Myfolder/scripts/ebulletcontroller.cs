using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//敵銃弾の方向制御 20201110
//敵銃弾の与ダメージ処理 20201110
public class ebulletcontroller : MonoBehaviour
{
    private GameObject player;
    [SerializeField]private int damege;
    // Start is called before the first frame update 20201110
    void Start()
    {
        player = GameObject.Find("Fighter");
        this.GetComponent<ParticleSystem>().Stop();
    }

    // Update is called once per frame 20201110
    void Update()
    {
        // 補完スピードを決める 20201110
        float speed = 0.1f;
        // ターゲット方向のベクトルを取得 20201110
        Vector3 relativePos = player.transform.position - transform.position;
        // 方向を、回転情報に変換 20201110
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        // 現在の回転情報と、ターゲット方向の回転情報を補完する 20201110
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed);
    }
    private void OnParticleCollision(GameObject other)
    {
        if(other.gameObject.tag == "player")
        {
            player.GetComponent<playermove>().getdamege(damege);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            this.GetComponent<ParticleSystem>().Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            this.GetComponent<ParticleSystem>().Stop();
        }
    }
}
