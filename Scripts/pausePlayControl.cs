using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pausePlayControl : MonoBehaviour
{
    Image pausePlayImage;
    public Sprite pauseButton;
    public Sprite playButton;
    public GameObject PauseWindow;
    private bool isPause = false;
    void Start()
    {
        pausePlayImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void PauseGame()
    {
        isPause = !isPause;

        if (isPause == true)
        {;
            pausePlayImage.sprite = playButton;
            PauseWindow.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pausePlayImage.sprite = pauseButton;
            PauseWindow.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
    
}
