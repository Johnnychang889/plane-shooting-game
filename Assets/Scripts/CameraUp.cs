using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUp : MonoBehaviour
{
    bool moveStop = false;
    void Start()
    {
        moveStop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!moveStop){
            transform.Translate(Vector3.up *1 * Time.deltaTime, Space.World);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Boss"){
            moveStop = true;
        }
    }
}
