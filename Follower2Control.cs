using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower2Control : MonoBehaviour
{
    [SerializeField] PlayerControl player=null;
    private float speed = 5.0f;
    [SerializeField] GameObject bullet = null;
    [SerializeField] int disappearTime = 5;
    private Vector3 followerPosition;
    void Awake()
    {
        player = GameObject.Find("/Main Camera/Player").GetComponent<PlayerControl>();
    }
    void Start()
    {
        InvokeRepeating("Attack", 1f, 1f);
        Destroy(gameObject,disappearTime);
    }

    void Update()
    {
        followerPosition = new Vector3(player.getPosition().x+1,player.getPosition().y,player.getPosition().z);
        transform.position = Vector3.MoveTowards(transform.position, followerPosition, speed * Time.deltaTime);
    }

    void Attack()
    {
        Instantiate(bullet,transform.position,Quaternion.identity);
    }
}
