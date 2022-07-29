using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject callGameManager;
    private void Awake()
    {
        if(GameManager.instance == null){
            Instantiate(callGameManager);
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
