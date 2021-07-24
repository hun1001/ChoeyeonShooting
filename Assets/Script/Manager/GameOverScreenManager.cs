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
        gameOverUI.SetActive(true);
        overText.text = string.Format("Best Score\n{0}\nScore\n{0}", GameManager.Instance.GetBestScore(), GameManager.Instance.GetScore());
    }

    public void LoadTitle()
    {
        SceneManager.LoadScene("Title");
    }

}
