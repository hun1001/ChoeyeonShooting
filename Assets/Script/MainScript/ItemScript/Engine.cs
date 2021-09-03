using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : Scrapt
{
    protected override void Update()
    {
        base.Update();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MainSoundManager.Instance.PlaySoundOther();
            SaveManager.Instance.CurrentUser.material.engine++;
            Destroy(gameObject);
        }
    }
}
