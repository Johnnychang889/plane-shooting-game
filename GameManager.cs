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
            Debug.Log("2");
            instance = this;
        }else if(instance != this){
            Debug.Log("3");
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    public void Again()
    {
		//讀取場景名"GameScence"這個名稱要一模一樣別打錯字囉
        SceneManager.LoadSceneAsync("GameScence");
        
    }
	//公開一個Menu()等等按鈕會用到
    public void Menu()
    {
		//讀取場景名"Menu"這個名稱要一模一樣別打錯字囉
        SceneManager.LoadScene("Menu");
    }
}
