using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainTextManager : MonoSingleton<MainTextManager>
{
    [SerializeField]
    private Text hp = null;
    [SerializeField]
    private Text score = null;


    public void SetHpText(int h)
    {
        hp.text = string.Format("{0}", h);
    }

    public void SetScoreText(int s)
    {
        score.text = string.Format("{0}", s);
    }
}
