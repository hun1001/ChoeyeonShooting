using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleTextManager : MonoSingleton<TitleTextManager>
{
    [SerializeField]
    protected Text[] text = null;
    [SerializeField]
    private Text isBoss = null;

    private void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        text[0].text = string.Format("{0}", TitleItemManager.Instance.scrapt);
        text[1].text = string.Format("{0}", TitleItemManager.Instance.gunPower);
        text[2].text = string.Format("{0}", TitleItemManager.Instance.engine);
        isBoss.text = string.Format("{0}", CheckBoss.isBoss);
    }
}
