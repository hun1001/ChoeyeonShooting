using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BossMove : MonoBehaviour
{
    [SerializeField]
    protected float speed = 5f;

    [SerializeField]
    private int hp = 3;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private float bulletDelay = 0.5f;

    [SerializeField]
    protected GameObject[] itemPref;

    [SerializeField]
    protected int addScore = 200;

    [SerializeField]
    private AudioClip clipDead;

    [SerializeField]
    private AudioClip fireClip;

    [SerializeField]
    private Sprite change;

    private bool phase2 = false;
    private bool isDead = false;
    private SpriteRenderer spriteRenderer = null;
    private GameObject bul = null;
    

    private float timer = 0f;
    private Vector3 diff = Vector3.zero;
    private float rotationZ = 0f;

    private GameObject newBullet = null;
    private Player player = null;
    private GameManager gameManager = null; 

    private int num = 1; //�̰͵� �ӽ� ���� ���߿� ���ﲨ ����ӿ��� ��⸦ ġ�� ���� ���� ��ǰ.state�� ���ġ�� ���� �ӽ� ������
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManager>();
        player = FindObjectOfType<Player>();
        StartCoroutine(Pattern());
    }

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        timer += Time.deltaTime;
        if (timer >= bulletDelay)
        {
            timer = 0f;
            //�Ѿ� ����
            MainSoundManager.Instance.SFXPlay("9 �� �Ѿ� �߽� ����", fireClip);
            newBullet = Instantiate(bulletPrefab);
            newBullet.transform.position = new Vector2(transform.position.x, transform.position.y - 1);
            newBullet.transform.localScale = new Vector3(1.5f, 1.5f, 1f);
            //�÷��̾� ��ǥ
            diff = transform.position - player.transform.position;
            diff.Normalize();
            rotationZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            newBullet.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + 90f);

            //�θ� ����
            newBullet.transform.SetParent(null);
        }
        if (hp<=50&&!phase2)
        {
            MainSoundManager.Instance.SFXPlay("8 �� ���", clipDead);
            phase2 = true;
            spriteRenderer.sprite = change;
            gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
            hp += 250;
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
            hp -= 30;
        }
    }

    protected virtual void Dead()
    {
        GameObject item = null;
        isDead = true;
        MainSoundManager.Instance.SFXPlay("8 �� ���", clipDead);
        int rand = Random.Range(0, 100);
        GameManager.Instance.AddScore(this.addScore);
        Destroy(gameObject);
        if (rand <= 30)//������ ��� Ȯ��
        {
            item = Instantiate(itemPref[0], gameObject.transform.position, Quaternion.identity);
            item.transform.position = new Vector2(transform.position.x, transform.position.y - 1); // �̰� �������� �̻��ѵ� �����Ǵµ� �װ� ���ľߵ� ���� �Ȱ�ħ
            item.transform.SetParent(null);
        }
        else if (rand <= 45)
        {
            item = Instantiate(itemPref[1], gameObject.transform.position, Quaternion.identity);
            item.transform.position = new Vector2(transform.position.x, transform.position.y - 1); // �̰� �������� �̻��ѵ� �����Ǵµ� �װ� ���ľߵ� ���� �Ȱ�ħ
            item.transform.SetParent(null);
        }
        else if (rand <= 60)
        {
            item = Instantiate(itemPref[2], gameObject.transform.position, Quaternion.identity);
            item.transform.position = new Vector2(transform.position.x, transform.position.y - 1); // �̰� �������� �̻��ѵ� �����Ǵµ� �װ� ���ľߵ� ���� �Ȱ�ħ
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

    private IEnumerator Pattern()
    {
        float rand;
        int pattern;
        while (true)
        {
            rand = Random.Range(0.7f, 2.5f);
            if (!phase2)
            {
                StartCoroutine(attack1());
            }
            else
            {
                pattern = Random.Range(1, 3);
                if (pattern==1)
                {
                    StartCoroutine(attack2());
                }
                else if(pattern==2)
                {
                    StartCoroutine(attack3());
                }
            }
            yield return new WaitForSeconds(rand);
        }
    }

    private IEnumerator attack1()
    {
        GameObject e;
        MainSoundManager.Instance.SFXPlay("9 �� �Ѿ� �߽� ����", fireClip);
        for (int j = 0; j < 20; j++)
        {
            e = Instantiate(bulletPrefab);
            e.transform.position = new Vector2(transform.position.x, transform.position.y - 1);
            e.transform.localScale = new Vector3(1f, 1f, 1f);
            e.transform.Rotate(0, 0, 90 + (j * 9));
            e.transform.SetParent(null);
        }
        yield return new WaitForSeconds(0);
    }
    private IEnumerator attack2()
    {
        GameObject e;
        MainSoundManager.Instance.SFXPlay("9 �� �Ѿ� �߽� ����", fireClip);
        for (int j = 0; j < 20; j++)
        {
            e = Instantiate(bulletPrefab);
            e.transform.position = new Vector2(transform.position.x, transform.position.y - 1);
            e.transform.localScale = new Vector3(1f, 1f, 1f);
            e.transform.Rotate(0, 0, 90 + (j * 9));
            e.transform.SetParent(null);
        }
        yield return new WaitForSeconds(0.3f);
        MainSoundManager.Instance.SFXPlay("9 �� �Ѿ� �߽� ����", fireClip);
        for (int j = 0; j < 20; j++)
        {
            e = Instantiate(bulletPrefab);
            e.transform.position = new Vector2(transform.position.x, transform.position.y - 1);
            e.transform.localScale = new Vector3(1f, 1f, 1f);
            e.transform.Rotate(0, 0, 85 + (j * 9));
            e.transform.SetParent(null);
        }
        yield return new WaitForSeconds(0.3f);
        MainSoundManager.Instance.SFXPlay("9 �� �Ѿ� �߽� ����", fireClip);
        for (int j = 0; j < 20; j++)
        {
            e = Instantiate(bulletPrefab);
            e.transform.position = new Vector2(transform.position.x, transform.position.y - 1);
            e.transform.localScale = new Vector3(1f, 1f, 1f);
            e.transform.Rotate(0, 0, 90 + (j * 9));
            e.transform.SetParent(null);
        }
        yield return new WaitForSeconds(0);
    }
    private IEnumerator attack3()
    {
        GameObject e;
        MainSoundManager.Instance.SFXPlay("9 �� �Ѿ� �߽� ����", fireClip);
        for (int j = 10; j>0; j--)
        {
            e = Instantiate(bulletPrefab);
            e.transform.position = new Vector2(transform.position.x, transform.position.y - 1);
            e.transform.localScale = new Vector3((0.5f*j), (0.5f * j), 1f);
            diff = transform.position - player.transform.position;
            diff.Normalize();
            rotationZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            e.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ+90f);
            e.transform.SetParent(null);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0);
    }
}
