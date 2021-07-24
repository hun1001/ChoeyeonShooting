using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreenManager : MonoBehaviour
{


    [SerializeField]
    private Text overText = null;

    public void GameOver()
    {
        overText.text = string.Format("Best Score\n{0}\nScore\n{0}", PlayerPrefs.GetInt("Best"),GameManager.Instance.GetScore());
    }

    public void LoadTitle()
    {
        SceneManager.LoadScene("Title");
    }

}
