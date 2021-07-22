using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    protected float speed = 4.5f;


    protected void Start()
    {
        
    }

    protected void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        CheckLimit();
    }

    protected void CheckLimit()
    {
        if (transform.position.y > GameManager.Instance.maxPosition.y)
        {
            Destroy(gameObject);
        }
    }
}
