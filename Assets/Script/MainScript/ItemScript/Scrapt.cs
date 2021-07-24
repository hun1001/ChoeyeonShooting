using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrapt : ItemMove
{
    void Start()
    {
        index = 0;
        value = 100;
        h = 25;
    }

    new void Update()
    {
        base.Update();
    }
}
