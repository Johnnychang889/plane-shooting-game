using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pausePlayControl : MonoBehaviour
{
    public GameObject PauseWindow;
    private bool isPause = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void PauseGame()
    {
        isPause = !isPause;

        if (isPause == true)
        {
            PauseWindow.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            PauseWindow.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
    
}
