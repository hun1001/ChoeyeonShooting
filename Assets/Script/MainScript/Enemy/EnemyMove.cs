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

    [SerializeField]
    protected GameObject itemPref = null;

    [SerializeField]
    protected int addScore = 200;

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
                Dead();
            }
        }
    }

    protected virtual void Dead()
    {
        GameObject item = null;
        isDead = true;
        GameManager.Instance.AddScore(this.addScore);
        Destroy(gameObject);
        item = Instantiate(itemPref, gameObject.transform.position, Quaternion.identity);
        item.transform.position = new Vector2(transform.position.x, transform.position.y - 1); // 이거 아이템이 이상한데 스폰되는데 그거 고쳐야됨 버그 안고침
        item.transform.SetParent(null);
    }
}