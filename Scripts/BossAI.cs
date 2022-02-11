using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossAI : MonoBehaviour
{
    private Animator anim;
    [SerializeField] float speed = 1f;
    bool right;
    public float hp = 10f;
    [SerializeField] GameObject enemyBullet = null;
    [SerializeField] GameObject enemy = null;
    public bool isdie=false;

    void Start()
    {
        if(PlayerPrefs.GetFloat("BossHp") == 10f)
        {
            hp = 10f;
            PlayerPrefs.SetFloat("BossHp",PlayerPrefs.GetFloat("BossHp")*2f);
        }
        else{
            hp = PlayerPrefs.GetFloat("BossHp");
            PlayerPrefs.SetFloat("BossHp",PlayerPrefs.GetFloat("BossHp")*2f);
        }

        right = true;
        isdie = false;
        anim = GetComponent<Animator>();
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
            if (gameObject.transform.position.x <= 0.8)
                right = true;
        }
        if (right)
        {
            transform.Translate(speed * 1 * Time.deltaTime, 0, 0);
            if (gameObject.transform.position.x >= 5.2)
                right = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "PlayerBullet"||collision.tag == "FollowerBullet"||collision.tag == "BoomBullet")
        {
            hp -= 5f;
            anim.SetTrigger("hit");
            if (hp <= 0){
                isdie = true;
                Destroy(gameObject,0.2f);
            }
        }
    }
    void Attack()
    {

        if(GetRandom(40)){

        Instantiate(enemyBullet, transform.position, Quaternion.identity);}

        else if(GetRandom(70))
        {
            for (int i = 0; i < 5; i++)
            {	
                Vector3 temp = new Vector3(transform.position.x + i, transform.position.y, transform.position.z);  
                Instantiate(enemyBullet, temp, Quaternion.identity);
            }
        }
        else if(GetRandom(100)){
            Instantiate(enemy, transform.position, Quaternion.identity, transform);
            Destroy(transform.GetChild(0).gameObject, 5f);
        }

    }

    bool GetRandom(int p)
    {
        int o = Random.Range(0, 100);

        if (o < p)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
}