using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeImage : MonoBehaviour
{
    protected int type = 0;
    protected SpriteRenderer spriteRenderer = null;

    [SerializeField]
    protected Sprite[] sprite = null;

    protected void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected virtual void ChangeImg()
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
            UpgradeParts.Instance.setbodyText(++UpgradeParts.Instance.bodyUp);
        }
    }


}
