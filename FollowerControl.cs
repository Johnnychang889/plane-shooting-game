using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerControl : MonoBehaviour
{
    public PlayerControl player=null;
    private float speed = 5.0f;
    private Vector3 followerPosition;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.position = player.getPosition();
        //Debug.Log(" "+player.getPosition().x );
        followerPosition = new Vector3(player.getPosition().x-1,player.getPosition().y,player.getPosition().z);
        transform.position = Vector3.MoveTowards(transform.position, followerPosition, speed * Time.deltaTime);
    }
}
