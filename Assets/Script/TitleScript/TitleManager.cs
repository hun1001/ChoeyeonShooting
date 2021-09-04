using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoSingleton<TitleManager>
{
    public GameObject title;
    public GameObject repair;

    [SerializeField]
    private AudioClip clip;



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
        PlayUIAudio();
        SceneManager.LoadScene("Main");
    }

    public void RepairShop()
    {
        PlayUIAudio();
        title.SetActive(false);
        repair.SetActive(true);
    }

    public void ExitGame()
    {
        PlayUIAudio();
        Application.Quit();
        Debug.Log("ExitGame");
    }

    public void PlayUIAudio()
    {
        TitleSoundManager.Instance.PlaySoundOther();
    }
}
