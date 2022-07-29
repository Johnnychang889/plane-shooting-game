using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerBulletControl : MonoBehaviour
{
    private float speed = 5f;
    void Start()
    {
		//銷毀(物件(沒特別指定預設為自己),五秒後將執行)
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
		//位置的轉換(三圍向量的UP(0,1,0)*速度*時間.差量時間,世界座標為主)
		// deltaTime每台電腦的Time時脈,速度都不同deltaTime可以讓每台電腦同一時脈,速度用
        transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
    }
}
