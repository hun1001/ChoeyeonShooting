using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;

    private int[] res = new int[3]; // 이ㅓㄴ 나중에 따로 빼노야될듯


    protected int index = -1;
    protected int value = 100;

    protected int h = 25;

    protected virtual void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MainSoundManager.Instance.PlaySoundOther();
            Addres(index, value);
            MainTextManager.Instance.AddValue(2, h);
            Destroy(gameObject);
        }
    }

    protected void Addres(int i,int n)
    {
        res[i] += n;
    }
}
