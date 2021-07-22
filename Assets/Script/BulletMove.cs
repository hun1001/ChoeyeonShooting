using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pool;

public class BulletMove : MonoBehaviour
{
    
    protected float speed = 1.57f;

    void Start()
    {
        
    }

    // Update is called once per frame
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
