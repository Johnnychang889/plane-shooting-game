using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyC_AI : MonoBehaviour
{
    private Animator anim;
    [SerializeField] float speed = 3f;
    bool right;
    [SerializeField] float hp = 100f;
    [SerializeField] GameObject enemyBullet = null;
    [SerializeField] GameObject bomb = null;

    void Start()
    {
        right = true;
        anim = GetComponent<Animator>();
		//一秒後反覆2秒執行Attack
        InvokeRepeating("Attack", 1f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
     void Move()
    {
        
        if (!right)
        { 
            transform.Translate(speed * -1 * Time.deltaTime, 0, 0);
            if (gameObject.transform.position.x <= 1)
            right = true;
        }
        if (right)
        { 
            transform.Translate(speed * 1 * Time.deltaTime, 0, 0);
            if (gameObject.transform.position.x >=4)
            right = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet"||collision.tag == "BoomBullet")
        {
            hp -= 5.0f + PlayerPrefs.GetFloat("playerAttackPower");
            anim.SetTrigger("hit");
            if (hp <= 0)
            {
                Instantiate(bomb, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        else if(collision.tag == "FollowerBullet")
        {
            hp --;
            anim.SetTrigger("hit");
            if (hp <= 0)
            {
                Instantiate(bomb, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
    void Attack()
    {
		//創造一個(物件(enemyBullet),在自身位置,自身角度)
        Instantiate(enemyBullet, transform.position, Quaternion.identity);
    }

}