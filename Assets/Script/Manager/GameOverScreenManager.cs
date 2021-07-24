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
        gameOverUI.SetActive(true);
        PlayerPrefs.GetInt("Best", bestScore);
        Debug.Log(bestScore + " " + GameManager.Instance.GetScore());
        overText.text = string.Format("BestScore\n{0}\nScore\n{0}", bestScore, GameManager.Instance.GetScore());
    }

    public void LoadTitle()
    {
        SceneManager.LoadScene("Title");
    }

}
