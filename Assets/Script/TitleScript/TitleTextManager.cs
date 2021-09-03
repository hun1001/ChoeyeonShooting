using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleTextManager : MonoSingleton<TitleManager>
{
    [SerializeField]
    protected Text[] text = null;

    private void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        text[0].text = string.Format("{0}", ItemManager.Instance.scrapt);
        text[1].text = string.Format("{0}", ItemManager.Instance.gunPower);
        text[2].text = string.Format("{0}", ItemManager.Instance.engine);
    }
}
