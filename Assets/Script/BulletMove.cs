using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pool;
using System;

public class BulletMove : MonoBehaviour, IResettable
{
    public EventHandler Death;
    protected float speed = 1.57f;

    public void Reset()
    {
        
    }

    void Start()
    {
        
    }

    void Update()
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
