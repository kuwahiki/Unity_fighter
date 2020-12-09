using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//プレイヤーの移動、ダメージ処理 20201110
public class playermove : MonoBehaviour
{
    GameObject bullet,rifle,spark;
    GameObject exprosion;
    public GameObject fighter,maker;
    int waittime,score = 0;
    float percent = 1.0f;
    public int HP,enemynum;
    public bool alive = true;
    public bool damege = false;
    [SerializeField]private float setspeed;
    private float speed;

    // Start is called before the first frame update 20201110
    void Start()
    {
        bullet = GameObject.Find("PlayerBullet");
        rifle = GameObject.Find("RIFLE");
        exprosion = GameObject.Find("PlayerExplosion");
        spark = GameObject.Find("spark");
        waittime = 300;
        HP = 100;
        enemynum = 6;
        alive = true;
        speed = this.setspeed * Time.deltaTime;
        Application.targetFrameRate = 60;

    }

    // Update is called once per frame 20201110
    void Update()
    {
        if (alive == true)
        {
            this.transform.Translate(0,0,speed);
            if(this.transform.position.y == 200)
            {
            }
            rotation();
            attack();
            if(enemynum == 0)
            {
                waittime--;
                if(waittime <= 0)
                {
                    SceneManager.LoadScene("GameClear");
                }
            }
        }
        else
        {
            waittime--;
            if(waittime <= 0)
            {
                SceneManager.LoadScene("GAME OVER");
            }
        }
    }

    private void LateUpdate()
    {
        damege = false;
    }

    private void attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bullet.GetComponent<AudioSource>().Play();
            bullet.GetComponent<ParticleSystem>().Play();
            rifle.GetComponent<ParticleSystem>().Play();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            bullet.GetComponent<AudioSource>().Stop();
            bullet.GetComponent<ParticleSystem>().Stop();
            rifle.GetComponent<ParticleSystem>().Stop();
        }
    }

    private void rotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(new Vector3(0, -50 * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(new Vector3(0, 50 * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Rotate(new Vector3(-50 * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Rotate(new Vector3(50 * Time.deltaTime, 0, 0));
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "missile" && collision.gameObject.tag != "ground")
        {
               die();   
        }
    }

    //死亡した際に呼び出す関数 20201110
    private void die()
    {
        if (alive == true)
        {
            this.HP = 0;
            this.percent = 0.0f;
            this.GetComponent<Rigidbody>().isKinematic = true;
            alive = false;
            Destroy(fighter.gameObject);
            Destroy(bullet.gameObject);
            Destroy(rifle.gameObject);
            Destroy(maker);
            exprosion.GetComponent<ParticleSystem>().Play();
            exprosion.GetComponent<AudioSource>().Play();
        }
    }

    //被ダメージ 20201110
    public void getdamege(int damege)
    {
            this.HP = this.HP - damege;
        this.percent = (float)this.HP / 100;
        if (this.alive == true)
        {
            
            this.damege = true;
            this.GetComponent<AudioSource>().SetScheduledEndTime(0.3);
            this.GetComponent<AudioSource>().Play();
            spark.GetComponent<ParticleSystem>().Play();
        }
        Debug.Log(this.HP);
            if (HP <= 0)
            {
                die();
            }
    }
        
    public bool getalive()
    {
        return alive;
    }
    public void addscore(int score)
    {
        this.score += score;
    }
    public int getscore()
    {
        return this.score;
    }
    public float percentHP()
    {
        return (float)percent;
    }

}
