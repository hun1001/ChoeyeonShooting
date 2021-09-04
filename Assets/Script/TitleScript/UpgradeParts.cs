using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeParts : MonoSingleton<UpgradeParts>
{
    private bool inputUpgrade = false;

    [SerializeField]
    private Text wpaText = null;

    [SerializeField]
    private Text bodyText = null;

    [SerializeField]
    private Text wpbText = null;

    public int wpaUp = 1;
    public int wpbUp = 1;
    public int bodyUp = 1;

    public void InputButton()
    {
        TitleSoundManager.Instance.PlaySoundOther();
        inputUpgrade = (!inputUpgrade);
    }

    public bool GetInputUpgrade()
    {
        return inputUpgrade;
    }

    public void setWpaText(int i)
    {
        TitleItemManager.Instance.gunPower -= 10 + (wpaUp / 2);
        TitleTextManager.Instance.UpdateUI();
        wpaText.text = string.Format("{0}",i);
    }

    public void setbodyText(int i)
    {
        TitleItemManager.Instance.scrapt -= 10+(wpaUp/2);
        TitleTextManager.Instance.UpdateUI();
        bodyText.text = string.Format("{0}", i);
    }

    public void setWpbText(int i)
    {
        TitleItemManager.Instance.gunPower -= 10 + (wpaUp / 2);
        TitleTextManager.Instance.UpdateUI();
        wpbText.text = string.Format("{0}", i);
    }
}
