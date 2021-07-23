using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : ChangeImage
{
    public static int bodyType;
    private Player player = null;
    new void Awake()
    {
        base.Awake();
        player = FindObjectOfType<Player>();
    }
    protected override void ChangeImg()
    {
        base.ChangeImg();
        bodyType = type;
    }

}
