using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//敵（ヘリコプター）の旋回処理 20201110
//敵（ヘリコプター）の追跡制御 20201110
public class enemycontroller2 : MonoBehaviour
{
    [SerializeField]private GameObject player,enemy;
    private bool aiming;
    //　初期位置 20201110
    private Vector3 distans;
    //　目的地 20201110
    private Vector3 destination;
    //　巡回する位置 20201110
    [SerializeField]
    private GameObject[] patrolPositions;
    //　次に巡回する位置 20201110
    private int nowPatrolPosition = 0;


    // Start is called before the first frame update 20201110
    void Start()
    {
        player = GameObject.Find("Fighter");
    }

    // Update is called once per frame 20201110
    void Update()
    {
        if (aiming == true)
        {
            lookposition(player,0.0f + Time.deltaTime);
            if (aiming == true && player.GetComponent<playermove>().alive == true)
            {
                transform.Translate(0, 0, 0.4f);
            }
        }
        else if(distans.magnitude <= 3.0f)
        {
            lookposition(patrolPositions[nowPatrolPosition],0.01f);
            transform.Translate(0,0,0.7f);
            //次の目的地の設定 20201110
                if (nowPatrolPosition == patrolPositions.Length-1)
                {
                    nowPatrolPosition = 0;
                    Debug.Log("change");
                }
                else
                {
                    nowPatrolPosition++;
                    Debug.Log("change");
                }           
        }
        else {
            lookposition(patrolPositions[nowPatrolPosition], 0.1f);
            transform.Translate(0, 0, 0.7f);
        }

        distans = this.transform.position - patrolPositions[nowPatrolPosition].transform.position;
        
    }

    private void lookposition(GameObject target,float speed)
        {
            // ターゲット方向のベクトルを取得 20201110
            Vector3 relativePos = target.transform.position - transform.position;
            // 方向を、回転情報に変換 20201110
            Quaternion rotation = Quaternion.LookRotation(relativePos);
        if (aiming == true)
        {
            rotation.x = 0;
            rotation.z = 0;
        }
            // 現在の回転情報と、ターゲット方向の回転情報を補完する 20201110
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed);
        }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            aiming = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            aiming = false;
        }
    }
}
