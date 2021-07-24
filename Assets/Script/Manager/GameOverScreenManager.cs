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

    private int bestScore = 100;


    private void Start()
    {
        gameOverUI.SetActive(false);    
    }

    public void GameOver()
    {
        bestScore = PlayerPrefs.GetInt("Best", 100);
        Debug.Log(bestScore + " " + GameManager.Instance.GetScore());
        overText.text = string.Format("BestScore\n{0}\nScore\n{1}", bestScore, GameManager.Instance.GetScore());
        gameOverUI.SetActive(true);
    }

    public void LoadTitle()
    {
        SceneManager.LoadScene("Title");
    }

}
