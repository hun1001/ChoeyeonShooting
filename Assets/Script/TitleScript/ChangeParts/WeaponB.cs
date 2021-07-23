using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponB : ChangeImage
{
    public static int wpBType;
    void Awake()
    {
        base.Awake();
    }
    protected override void ChangeImg()
    {
        base.ChangeImg();
        wpBType = type;
    }


}
