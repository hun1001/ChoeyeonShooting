using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBoss : MonoBehaviour
{//���߿� ������ ��ũ��Ʈ

    public static bool isBoss = false;

    public void TurnBoss()
    {
        isBoss = !isBoss;
        TitleTextManager.Instance.UpdateUI();
    }
    
}
