using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    [SerializeField]
    protected float speed = 15f;

    protected void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        CheckLimit();
    }

    protected void CheckLimit()
    {
        if (transform.position.y > 20)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.tag.Contains("Enemy")&&!enemy.name.Contains("Boss"))
        {
            Destroy(enemy.gameObject);
        }
    }
    
}
