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
    protected GameObject[] itemPref;

    [SerializeField]
    protected int addScore = 200;

    [SerializeField]
    private AudioClip clipDead;

    private SpriteRenderer spriteRenderer = null;

    private GameObject bul = null;

    private int num = 1; //이것도 임시 변수 나중에 지울꺼 영상속에서 사기를 치기 위한 변수 부품.state도 사기치기 위한 임시 변수임
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        if (transform.position.x < GameManager.Instance.minPosition.x - 2)
        {
            Destroy(gameObject);
        }
        if (transform.position.x > GameManager.Instance.maxPosition.x + 2)
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
            bul = collision.gameObject;
            if (bullet != null)
            {
                Destroy(bullet.gameObject);
            }

            Bulletcheck();

            if (hp <= 0)
            {
                Dead();
            }
        }
        if (collision.gameObject.name.Contains("Boom"))
        {
            Dead();
        }
    }

    protected virtual void Dead()
    {
        GameObject item = null;
        isDead = true;
        MainSoundManager.Instance.SFXPlay("8 적 사망", clipDead);
        int rand = Random.Range(0, 100);
        GameManager.Instance.AddScore(this.addScore);
        Destroy(gameObject);
        if (rand <= 30)//아이템 드롭 확률
        {
            item = Instantiate(itemPref[0], gameObject.transform.position, Quaternion.identity);
            item.transform.position = new Vector2(transform.position.x, transform.position.y - 1); // 이거 아이템이 이상한데 스폰되는데 그거 고쳐야됨 버그 안고침
            item.transform.SetParent(null);
        }
        else if(rand<=45)
        {
            item = Instantiate(itemPref[1], gameObject.transform.position, Quaternion.identity);
            item.transform.position = new Vector2(transform.position.x, transform.position.y - 1); // 이거 아이템이 이상한데 스폰되는데 그거 고쳐야됨 버그 안고침
            item.transform.SetParent(null);
        }
        else if(rand<=60)
        {
            item = Instantiate(itemPref[2], gameObject.transform.position, Quaternion.identity);
            item.transform.position = new Vector2(transform.position.x, transform.position.y - 1); // 이거 아이템이 이상한데 스폰되는데 그거 고쳐야됨 버그 안고침
            item.transform.SetParent(null);
        }
    }

    protected virtual void Bulletcheck()
    {
        if ((Body.state > 1) && (WeaponA.state > 1) && (WeaponB.state > 1))
        {
            num = 10;
        }
        if (bul.name.Contains("BulletTypeA"))
        {
            hp -= 2 * num;
        }
        else if (bul.name.Contains("laser_bullet_0"))
        {
            hp -= 6 * num;
        }
        else if (bul.name.Contains("missile"))
        {
            hp -= 4 * num;
        }
    }

    //protected virtual void Damaged() // 일단 보류
    //{
    //    spriteRenderer.material.SetColor("_Color", new Color(1f, 1f, 1f, 0f));
    //    yield return new WaitForSeconds(0.1f);
    //    spriteRenderer.material.SetColor("_Color", new Color(0f, 0f, 0f, 0f));
    //}
}