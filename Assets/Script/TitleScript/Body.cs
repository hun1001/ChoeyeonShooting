using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    int type = 0;
    private SpriteRenderer spriteRenderer = null;

    [SerializeField]
    private Sprite[] sprite = null;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeBody()
    {
        type++;
        if (type > 2)
        {
            type = 0;
        }
        spriteRenderer.sprite = sprite[type];
    }

}
