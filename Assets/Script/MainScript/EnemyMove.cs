using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    protected float speed = 5f;
    [SerializeField]
    private int hp = 3;
    private bool isDead = false;

    void Start()
    {
    }


    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        CheckLimit();
    }

    protected void CheckLimit()
    {
        if (transform.position.y < GameManager.Instance.minPosition.y)
        {
            Destroy(gameObject);
        }
        if (transform.position.x < GameManager.Instance.minPosition.x-2)
        {
            Destroy(gameObject);
        }
        if (transform.position.x > GameManager.Instance.maxPosition.x+2)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead) return;
        if (collision.gameObject.CompareTag("Bullet"))
        {
            BulletA bullet = collision.GetComponent<BulletA>();
            if (bullet != null)
            {
                Destroy(bullet.gameObject);
            }
            hp--;
            if (hp <= 0)
            {
                isDead = true;
                Destroy(gameObject);
            }
        }
    }
}