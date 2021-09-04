using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponA : ChangeImage
{
    public static int wpAType;
    new void Awake()
    {
        base.Awake();
    }
    protected override void ChangeImg()
    {
        if (!UpgradeParts.Instance.GetInputUpgrade())
        {
            TitleSoundManager.Instance.PlaySoundOther();
            type++;
            if (type > 2)
            {
                type = 0;
            }
            spriteRenderer.sprite = sprite[type];
        }
        else
        {
            TitleSoundManager.Instance.PlaySoundOther();
            UpgradeParts.Instance.setWpaText(++UpgradeParts.Instance.wpaUp);
        }
        wpAType = type;
    }

}
