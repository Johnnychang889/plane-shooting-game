using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        //往上前進(4)看你炸彈速度要多快
        transform.Translate(Vector3.up * 4 * Time.deltaTime, Space.World);
    }
}
