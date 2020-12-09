using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤー銃弾の与ダメージ処理 20201110
public class pbulletcontroller : MonoBehaviour
{
    [SerializeField] private int atk;
    public GameObject[] enemy = new GameObject[6];
    // Start is called before the first frame update 20201110
    void Start()
    {
        enemy[0] = GameObject.Find("Corvette");
        enemy[1] = GameObject.Find("Corvette (1)");
        enemy[2] = GameObject.Find("Cruiser");
        enemy[3] = GameObject.Find("Gunship");
        enemy[4] = GameObject.Find("Gunship (1)");
        enemy[5] = GameObject.Find("Gunship (2)");
        
    }

    // Update is called once per frame 20201110
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        //どの敵に当たったか判断 20201110
        Debug.Log("hit");
        switch (other.gameObject.tag)
        {
            case "enemy1":
                enemy[0].GetComponent<enemycontroller1>().getdamege(atk);
                break;
            case "enemy2":
                enemy[1].GetComponent<enemycontroller1>().getdamege(atk);
                break;
            case "enemy3":
                enemy[2].GetComponent<enemycontroller1>().getdamege(atk);
                break;
            case "enemy4":
                enemy[3].GetComponent<enemycontroller1>().getdamege(atk);
                break;
            case "enemy5":
                enemy[4].GetComponent<enemycontroller1>().getdamege(atk);
                break;
            case "enemy6":
                enemy[5].GetComponent<enemycontroller1>().getdamege(atk);
                break;
        }
    }
}
