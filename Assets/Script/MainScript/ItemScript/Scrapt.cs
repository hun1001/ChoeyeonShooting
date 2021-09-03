using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrapt : MonoBehaviour
{
    [SerializeField]
    protected float speed = 3f;

    protected virtual void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MainSoundManager.Instance.PlaySoundOther();
            //SaveManager.Instance.CurrentUser.material.scrapt++;
            ItemManager.Instance.scrapt++;
            Destroy(gameObject);
        }
    }
}
