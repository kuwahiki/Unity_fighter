using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//敵の被ダメージ処理 20201110
public class enemycontroller1 : MonoBehaviour
{
    public GameObject enemy,taget;
    GameObject player;
    [SerializeField]private int HP,score;
    private bool alive;
    // Start is called before the first frame update 20201110
    void Start()
    {
        alive = true;
        player = GameObject.Find("Fighter");
    }

    // Update is called once per frame 20201110
    void Update()
    {
        if(HP <= 0 && alive == true)
        {
            alive = false;
        }
        if (alive == false)
        {
            //死亡した際の処理 20201110
            player.GetComponent<playermove>().addscore(score);
            player.GetComponent<playermove>().enemynum -= 1;
            GetComponent<explosiongenerator>().playexplosion();
            Destroy(taget);
            Destroy(enemy);          
        }
    }
    public void getdamege(int damege)
    {
        this.HP -= damege;
    }

}
