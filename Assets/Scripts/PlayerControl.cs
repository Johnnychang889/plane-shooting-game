using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerControl : MonoBehaviour
{
    
    private Animator anim;
    private Rigidbody2D rig;
    public BossAI boss = null;
    [SerializeField] float speed = 5f;
    [SerializeField] GameObject bullet = null;
    [SerializeField] float hp = 20f;
    [SerializeField] float hpMax = 20f;
    [SerializeField] Image hpBar = null;
    [SerializeField] GameObject dieWindow = null;
    [SerializeField] GameObject winWindow = null;
    [SerializeField] GameObject boom = null;
    [SerializeField] public int bomb=3;
    [SerializeField] public TMP_Text boomNumber = default;
    [SerializeField] public int money=0;
    [SerializeField] public TMP_Text moneyNumber = default;
    [SerializeField] GameObject follower1 = null;
    [SerializeField] GameObject follower2 = null;
    [SerializeField] Joystick joy = null;
    float horizontalMove;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        dieWindow.SetActive(false);
        winWindow.SetActive(false);
        boss = GameObject.Find("Boss").GetComponent<BossAI>();
        hpBar.fillAmount = hp / hpMax;

        if(PlayerPrefs.GetInt("money")!=0)
        {
            money = PlayerPrefs.GetInt("money");
        }

        if(PlayerPrefs.GetFloat("playerMaxHp") == 50.0f)
        {
            hpMax += 50.0f;
            hp = hpMax;
        }

        if(PlayerPrefs.GetFloat("playerFireSpeed") == 2.0f)
        {
            InvokeRepeating( "Attack", 1f, 0.5f );
        }
        else if(PlayerPrefs.GetFloat("playerFireSpeed") == 1.0f)
        {
            InvokeRepeating( "Attack", 1f, 1f );
        }
        else Debug.Log("playerFireSpeed Error!");
        
    }
    private void Update()
    {
        //horizontalMove = Input.GetAxisRaw("Horizontal");
        horizontalMove = joy.Horizontal;
        hpBar.fillAmount = hp / hpMax;

        boomNumber.text = "" + bomb;
        moneyNumber.text = "" + money;

        if(money!=0) PlayerPrefs.SetInt("money",money);
        if(winWindow.activeInHierarchy == false && dieWindow.activeInHierarchy == false)
        {
            if(Input.GetKeyDown(KeyCode.B))
            {
                Boom();
            }
        }

    }
    private void FixedUpdate()
    {
        Move();
        if (boss.isdie)
        {
            winWindow.SetActive(true);
        }
    }
    void Move()
    {
        rig.velocity = new Vector2(horizontalMove * speed, rig.velocity.y);
        if (horizontalMove > 0.2f)
        {
            anim.SetBool("left", false);
            anim.SetBool("right",true);
        }
        if (horizontalMove < -0.2f)
        {
            anim.SetBool("right",false);
            anim.SetBool("left", true);
        }
        if(horizontalMove < 0.2f && horizontalMove > -0.2f)
        {
            anim.SetBool("right", false);
            anim.SetBool("left", false);
        }
    }

    void Attack()
    {
        Instantiate(bullet,transform.position,Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyBullet")
        {
            hp -= 5f;
            hpBar.fillAmount = hp / hpMax;
            //如果(血量小於等於0)
            if (hp <= 0)
            {	
                anim.SetBool("die", true);
                dieWindow.SetActive(true);
                //Destroy(gameObject,0.5f);
                gameObject.SetActive(false);
            }
        }
        if(collision.tag =="boom")
        {
            bomb += 1;
            Destroy(collision.gameObject);
        }
        if(collision.tag =="money")
        {
            money += 1;
            Destroy(collision.gameObject);
        }
        if(collision.tag =="power")
        {
            Destroy(collision.gameObject);
            Instantiate(follower1, transform.position, Quaternion.identity);
            Instantiate(follower2, transform.position, Quaternion.identity);
        }
    }

    public void Boom()
    {
        if (bomb > 0)
        {	
            bomb -= 1;
            Instantiate(boom, transform.position, Quaternion.identity);
            
        }
    }
    public Vector3 getPosition()
    {
        return transform.position;
    }
    public void Resurrection()//復活
    {
        gameObject.SetActive(true);
        hp = hpMax;
        dieWindow.SetActive(false);
    }

    
}