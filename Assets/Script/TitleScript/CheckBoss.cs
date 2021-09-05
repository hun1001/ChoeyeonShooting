using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBoss : MonoBehaviour
{//나중에 지워질 스크립트

    public static bool isBoss = false;

    public void TurnBoss()
    {
        isBoss = !isBoss;
        TitleTextManager.Instance.UpdateUI();
    }
    
}
