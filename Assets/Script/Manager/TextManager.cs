using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoSingleton<TextManager>
{
    [SerializeField]
    private Text[] text = null;

    private int[] figure = new int[3];

    protected void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            SetValue(i, PlayerPrefs.GetInt("CYS" + i, figure[i]));
        }
    }

    public void UpdateUI(int i, int v)
    {
        text[i].text = string.Format("{0}", v);
    }

    public void SetValue(int i,int v)
    {
        figure[i] = v;
        PlayerPrefs.SetInt("CYS" + i, figure[i]);
        UpdateUI(i, figure[i]);
    }

}
