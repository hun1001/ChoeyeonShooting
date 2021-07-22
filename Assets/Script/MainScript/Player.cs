using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int playerType = 0; // 일단 임시 나중에 지울거 같은 변수

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

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ChangeBody(1);
    }

    void Start()
    {
        StartCoroutine(Fire());
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
            bullet.transform.SetParent(null);
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void ChangeBody(int type)
    {
        spriteRenderer.sprite = sprite[type];
    }
}