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
        bestScore = PlayerPrefs.GetInt("Best");
        overText.text = string.Format("Best Score\n{0}\nScore\n{0}", bestScore, GameManager.Instance.GetScore());
    }

    public void LoadTitle()
    {
        SceneManager.LoadScene("Title");
    }

}
