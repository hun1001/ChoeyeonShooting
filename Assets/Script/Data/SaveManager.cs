using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoSingleton<SaveManager>
{
    [SerializeField]
    private User user = null;

    public User CurrentUser
    {
        get
        {
            return user;
        }
    }

    private string SAVE_PATH = "";
    private string SAVE_FILENAME = "/SaveFile.txt";



    private void Awake()
    {
        SAVE_PATH = Application.dataPath + "/Save";
        if (!Directory.Exists(SAVE_PATH))
        {
            Directory.CreateDirectory(SAVE_PATH);
        }
    }

    private void Start()
    {
        LoadFromJson();
    }

    private void LoadFromJson()
    {
        if (File.Exists(SAVE_PATH + SAVE_FILENAME))
        {
            string json = File.ReadAllText(SAVE_PATH + SAVE_FILENAME);
            user = JsonUtility.FromJson<User>(json);
        }
    }

    public void SaveToJson()
    {
        string json = JsonUtility.ToJson(user);
        File.WriteAllText(SAVE_PATH + SAVE_FILENAME, json, System.Text.Encoding.UTF8);
    }

}
