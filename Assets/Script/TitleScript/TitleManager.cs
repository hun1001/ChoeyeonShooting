using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("Main");
    }

    public void RepairShop()
    {
        
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("ExitGame");
    }
}
