using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : BulletMove
{
    protected void Start()
    {
        speed =10f; 
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }
}
