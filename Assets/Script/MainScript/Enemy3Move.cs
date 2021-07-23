using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Move : EnemyMove
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        transform.Rotate(0, 0, 2);
        transform.position -= new Vector3(0, 0.01f, 0);
        base.CheckLimit();
    }
}
