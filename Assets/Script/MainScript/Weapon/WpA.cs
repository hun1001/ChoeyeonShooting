using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WpA : Weapon
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        ChangeImg(WeaponA.wpAType);
    }

}
