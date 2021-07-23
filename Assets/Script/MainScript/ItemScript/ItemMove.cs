using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;

    private int[] res = new int[3]; // �̤ä� ���߿� ���� ����ߵɵ�

    protected bool isDead = false;

    protected int index = -1;
    protected int value = 100;

    protected virtual void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (isDead == true)
        {
            Addres(index, value);
            MainTextManager.Instance.AddValue(2, value);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MainSoundManager.Instance.PlaySoundOther();
            Destroy(gameObject);
        }
    }

    protected void Addres(int i,int n)
    {
        res[i] += n;
    }
}
