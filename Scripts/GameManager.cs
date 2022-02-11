using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if(instance != this){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        PlayerPrefs.SetInt("money",0);
        PlayerPrefs.SetFloat("BossHp",10f);
    }
    void Update()
    {
        
    }
    public void NextLevel()//進下一關
    {
        SceneManager.LoadSceneAsync("GameScence");
    }
    public void Menu()//回主頁
    {
        SceneManager.LoadSceneAsync("Menu");
        PlayerPrefs.SetFloat("BossHp",10f);
    }
  
}
