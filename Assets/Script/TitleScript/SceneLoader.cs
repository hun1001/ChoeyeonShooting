using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]

    static void FirstLoad()
    {

        if (SceneManager.GetActiveScene().name.CompareTo("Title") != 0)
        {
            SceneManager.LoadScene("Title");
        }

    }

}