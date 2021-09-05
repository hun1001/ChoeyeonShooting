using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreenManager : MonoSingleton<GameOverScreenManager>
{


    [SerializeField]
    private Text overText = null;

    [SerializeField]
    private GameObject gameOverUI;



    private void Start()
    {
        gameOverUI.SetActive(false);    
    }

    public void GameOver()
    {
        //if (GameManager.Instance.score > SaveManager.Instance.CurrentUser.bestScore)
        //{
        //    SaveManager.Instance.CurrentUser.bestScore = GameManager.Instance.score;
        //}
        //SaveManager.Instance.SaveToJson();
        if (GameManager.Instance.GetScore() > PlayerPrefs.GetInt("best"))
        {
            PlayerPrefs.SetInt("best", GameManager.Instance.GetScore());
        }
        overText.text = string.Format("BestScore\n{0}\nScore\n{1}\n\nScr {2} Eng {3} Gp {4}", PlayerPrefs.GetInt("best"), GameManager.Instance.GetScore(), ItemManager.Instance.scrapt, ItemManager.Instance.engine, ItemManager.Instance.gunPower);
        gameOverUI.SetActive(true);
    }

    public void LoadTitle()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Title");
    }

}
