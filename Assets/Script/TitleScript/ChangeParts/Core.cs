using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : ChangeImage
{

    public static int bodyType;
    new void Awake()
    {
        base.Awake();
    }
    protected override void ChangeImg()
    {
        base.ChangeImg();
        bodyType = type;
    }
}
