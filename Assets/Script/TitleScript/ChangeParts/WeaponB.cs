using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponB : ChangeImage
{
    public static int wpBType;
    public static int state;
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
            UpgradeParts.Instance.setWpbText(++UpgradeParts.Instance.wpbUp);
        }

        wpBType = type;
    }
}
