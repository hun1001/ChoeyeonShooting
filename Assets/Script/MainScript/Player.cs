using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoSingleton<Player>
{

    private Vector2 targetPosition = Vector2.zero;
    [SerializeField]
    private float speed = 15.7f;

    [SerializeField]
    private GameObject[] bulletPrefab = null;

    [SerializeField]
    private Transform bulletPosition = null;

    private SpriteRenderer spriteRenderer = null;

    [SerializeField]
    private Sprite[] sprite = null;

    [SerializeField]
    private int hp = 100;

    private bool isDamaged = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        StartCoroutine(Fire());
        ChangeBody(Body.bodyType);
    }

    void Update()
    {
        if (Input.GetMouseButton(0) == true)
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.x = Mathf.Clamp(targetPosition.x, GameManager.Instance.minPosition.x, GameManager.Instance.maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, GameManager.Instance.minPosition.y, GameManager.Instance.maxPosition.y);
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, targetPosition, speed * Time.deltaTime);
        }
    }

    private IEnumerator Fire()
    {
        while (true)
        {
            GameObject bullet = null;
            bullet = Instantiate(bulletPrefab[0], bulletPosition);
            bullet.transform.localScale = new Vector3(1.4f, 1.4f, 1);
            bullet.transform.SetParent(null);
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void ChangeBody(int type)
    {
        spriteRenderer.sprite = sprite[type];
    }

    public IEnumerator Damaged(int damage)
    {
        if (!isDamaged)
        {
            isDamaged = true;
            hp -= damage;
            if (hp < 1)
            {
                Destroy(gameObject);
            }
            for (int i = 0; i < 3; i++)
            {
                spriteRenderer.enabled = false;
                yield return new WaitForSeconds(0.157f);
                spriteRenderer.enabled = true;
                yield return new WaitForSeconds(0.157f);
            }
            isDamaged = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            StartCoroutine(Damaged(3)); // 여기부분 수정해야됨
        }
    }
}