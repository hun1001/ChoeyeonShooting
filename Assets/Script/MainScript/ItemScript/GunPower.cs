using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPower : ItemMove
{
    void Start()
    {
        index = 0;
        value = 100;
        h = 30;
    }

    new void Update()
    {
        base.Update();
    }
}
