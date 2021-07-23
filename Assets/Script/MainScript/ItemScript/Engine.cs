using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : ItemMove
{
    void Start()
    {
        index = 2;
        value = 10;
    }

    new void Update()
    {
        base.Update();
    }
}
