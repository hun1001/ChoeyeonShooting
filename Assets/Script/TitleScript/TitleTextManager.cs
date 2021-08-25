using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleTextManager : MonoSingleton<TitleManager>
{
    [SerializeField]
    protected Text[] text = null;

    protected int[] figure = new int[3];

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

    public void SetValue(int i, int v)
    {
        figure[i] = v;
        PlayerPrefs.SetInt("CYS" + i, figure[i]);
        UpdateUI(i, figure[i]);
    }
    
    public void AddValue(int i, int a)
    {
        figure[i] += a;
        UpdateUI(i, figure[2]);
    }

    public int GetValue(int i)
    {
        return figure[i];
    }
}
