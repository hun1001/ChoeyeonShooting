using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WpB : Weapon
{

    protected override void Start()
    {
        base.Start();
        ChangeImg(WeaponB.wpBType);
    }
}
