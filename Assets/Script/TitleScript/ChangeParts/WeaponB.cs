using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponB : ChangeImage
{
    public static int wpBType;
    new void Awake()
    {
        base.Awake();
    }
    protected override void ChangeImg()
    {
        base.ChangeImg();
        wpBType = type;
    }
}
