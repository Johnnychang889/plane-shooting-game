using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

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
        PlayerPrefs.SetFloat("playerMaxHp",0.0f);
        //StoreWindow
        PlayerPrefs.SetInt("isPlayerMaxHpUp",0);
    }
    void Update()
    {
        //Debug.Log(isPlayerMaxHpUp);
    }
    public void NextLevel()//進下一關
    {
        SceneManager.LoadSceneAsync("GameScence");
    }
    public void dieMenu()//輸,回主頁
    {
        SceneManager.LoadSceneAsync("Menu");
        PlayerPrefs.SetFloat("BossHp",10f);
    }
    public void winMenu()//贏,回主頁
    {
        SceneManager.LoadSceneAsync("Menu");
    }
    
    public void playerMaxHpUp()
    {
        if(PlayerPrefs.GetInt("money")<10)
        {
            Debug.Log("你沒有足夠的錢");
        }
        else if(PlayerPrefs.GetInt("isPlayerMaxHpUp") == 0)
        {
            PlayerPrefs.SetFloat("playerMaxHp",50.0f);
            PlayerPrefs.SetInt("isPlayerMaxHpUp",1);
            PlayerPrefs.SetInt("money",PlayerPrefs.GetInt("money")-10);
        }
        else
        {
            TMP_Text slodout = GameObject.Find("CommodityButton1/DetailButton/BuyButton/price").GetComponent<TMP_Text>();
            slodout.text = "已購買";
        }
    }
}
