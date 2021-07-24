using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoSingleton<Weapon>
{
    protected int type = 0;
    [SerializeField]
    protected GameObject[] bulletPrefab = null;

    [SerializeField]
    protected Transform bulletPosition = null;

    protected SpriteRenderer spriteRenderer = null;

    [SerializeField]
    protected Sprite[] weaponImg = null;

    protected virtual void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Fire());
    }

    private IEnumerator Fire()
    {
        while (GameManager.Instance.GetisGameOver() == false)
        {
            GameObject bullet = null;
            bullet = Instantiate(bulletPrefab[type], bulletPosition);
            bullet.transform.SetParent(null);
            yield return new WaitForSeconds(0.5f);
        }
    }

    protected virtual void ChangeImg(int i)
    {
        spriteRenderer.sprite = weaponImg[i];
    }

    public void Dead()
    {
        gameObject.SetActive(false);
        spriteRenderer.enabled = false;
    }
}
