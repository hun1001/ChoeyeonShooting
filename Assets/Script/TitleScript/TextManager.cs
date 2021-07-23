using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoSingleton<TextManager>
{
    [SerializeField]
    private Text scraptText = null;
    [SerializeField]
    private Text gunPowerText = null;
    [SerializeField]
    private Text engineText = null;

    private int scrap = 0;
    private int gunPower = 0;
    private int engine = 0;

    private void Start()
    {
        SetValue();
    }

    public void UpdateUI(int sc, int gp, int eg)
    {
        scraptText.text = string.Format("{0}", sc);
        gunPowerText.text = string.Format("{0}", gp);
        engineText.text = string.Format("{0}", eg);
    }

    private void SetValue()
    {
        PlayerPrefs.GetInt("SC", scrap);
        PlayerPrefs.GetInt("GP", gunPower);
        PlayerPrefs.GetInt("EG", engine);
        UpdateUI(scrap, gunPower, engine);
    }

}
