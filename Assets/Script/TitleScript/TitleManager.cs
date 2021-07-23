using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public GameObject title;
    public GameObject repair;

    private void Awake()
    {
        title = GameObject.Find("Title");
        repair = GameObject.Find("RepairCollection");
    }

    private void Start()
    {
        title.SetActive(true);
        repair.SetActive(false);
    }

    public void GameStart()
    {
        SceneManager.LoadScene("Main");
    }

    public void RepairShop()
    {
        title.SetActive(false);
        repair.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("ExitGame");
    }
}
