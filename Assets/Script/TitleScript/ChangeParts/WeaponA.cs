using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponA : ChangeImage
{
    public static int wpAType;
    void Awake()
    {
        base.Awake();
    }
    protected override void ChangeImg()
    {
        base.ChangeImg();
        wpAType = type;
    }

}
