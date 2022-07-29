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
        //商店物品加入遊戲
        PlayerPrefs.SetFloat("playerMaxHp",0.0f);
        PlayerPrefs.SetFloat("playerFireSpeed",1.0f);
        PlayerPrefs.SetFloat("playerAttackPower",0.0f);
        //商店貨物是否售完(0代表還沒,1代表售完)
        PlayerPrefs.SetInt("isPlayerMaxHpUp",0);
        PlayerPrefs.SetInt("isPlayerFireSpeedUp",0);
        PlayerPrefs.SetInt("isPlayerAttackPowerUp",0);
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
            PlayerPrefs.SetInt("isPlayerMaxHpUp",1);

            PlayerPrefs.SetFloat("playerMaxHp",50.0f);
            PlayerPrefs.SetInt("money",PlayerPrefs.GetInt("money")-10);
        }
        else
        {
            TMP_Text slodout = GameObject.Find("CommodityButton1/DetailButton/BuyButton/price").GetComponent<TMP_Text>();
            slodout.text = "已購買";
        }
    }
    public void playerFireSpeedUp()
    {
        if(PlayerPrefs.GetInt("money")<20)
        {
            Debug.Log("你沒有足夠的錢");
        }
        else if(PlayerPrefs.GetInt("isPlayerFireSpeedUp") == 0)
        {
            PlayerPrefs.SetInt("isPlayerFireSpeedUp",1);

            PlayerPrefs.SetFloat("playerFireSpeed",2.0f);
            PlayerPrefs.SetInt("money",PlayerPrefs.GetInt("money")-20);
        }
        else
        {
            TMP_Text slodout = GameObject.Find("CommodityButton2/DetailButton/BuyButton/price").GetComponent<TMP_Text>();
            slodout.text = "已購買";
        }
    }
    public void playerAttackPowerUp()
    {
        if(PlayerPrefs.GetInt("money")<30)
        {
            Debug.Log("你沒有足夠的錢");
        }
        else if(PlayerPrefs.GetInt("isPlayerAttackPowerUp") == 0)
        {
            PlayerPrefs.SetInt("isPlayerAttackPowerUp",1);

            PlayerPrefs.SetFloat("playerAttackPower",3.0f);
            PlayerPrefs.SetInt("money",PlayerPrefs.GetInt("money")-30);
        }
        else
        {
            TMP_Text slodout = GameObject.Find("CommodityButton3/DetailButton/BuyButton/price").GetComponent<TMP_Text>();
            slodout.text = "已購買";
        }
    }
}
