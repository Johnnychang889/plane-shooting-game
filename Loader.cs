using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject game;
    private void Awake()
    {
        if(GameManager.instance == null){
            Debug.Log("1");
            Instantiate(game);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
