using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    [SerializeField]
    private Material material = null;

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
        InvokeRepeating("SaveToJson", 1f, 60f);
    }

    private void LoadFromJson()
    {
        if (File.Exists(SAVE_PATH + SAVE_FILENAME))
        {
            string json = File.ReadAllText(SAVE_PATH + SAVE_FILENAME);
            material = JsonUtility.FromJson<Material>(json);
        }
    }

    private void SaveToJson()
    {
        string json = JsonUtility.ToJson(material);
        File.WriteAllText(SAVE_PATH + SAVE_FILENAME, json, System.Text.Encoding.UTF8);
    }

    private void OnApplicationQuit()
    {
        SaveToJson();
    }
}
