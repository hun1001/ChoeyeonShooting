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
        bestScore = 10000;
        overText.text = string.Format("BestScore\n{0}\nScore\n{1}\n\nScr {2} Eng {3} Gp {4}", bestScore, GameManager.Instance.GetScore(), 10, 10, 10);
        gameOverUI.SetActive(true);
    }

    public void LoadTitle()
    {
        SceneManager.LoadScene("Title");
    }

}
