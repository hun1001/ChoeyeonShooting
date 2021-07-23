using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Move : EnemyMove
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float bulletDelay = 0.5f;

    private float timer = 0f;
    private Vector3 diff = Vector3.zero;
    private float rotationZ = 0f;

    private GameObject newBullet = null;
    private Player player = null;
    private GameManager gameManager = null;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        timer += Time.deltaTime;
        if (timer >= bulletDelay)
        {
            timer = 0f;
            //�Ѿ� ����
            newBullet = Instantiate(bulletPrefab);
            newBullet.transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            //�÷��̾� ��ǥ
            diff = transform.position - player.transform.position;
            diff.Normalize();
            rotationZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            newBullet.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + 90f);

            //�θ� ����
            newBullet.transform.SetParent(null);
        }

        if (gameObject.transform.position.x <= gameManager.minPosition.x - 2f)
        {
            Destroy(gameObject);
        }
    }
}
