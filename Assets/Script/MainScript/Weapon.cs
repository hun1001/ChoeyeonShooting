using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected int weaponType = 0;

    [SerializeField]
    protected GameObject[] bulletPrefab = null;

    [SerializeField]
    protected Transform bulletPosition = null;

    protected SpriteRenderer spriteRenderer = null;

    [SerializeField]
    protected Sprite[] weaponImg = null;

    protected virtual void Start()
    {
        StartCoroutine(Fire());
    }

    private IEnumerator Fire()
    {
        while (true)
        {
            GameObject bullet = null;
            bullet = Instantiate(bulletPrefab[weaponType], bulletPosition);
            bullet.transform.SetParent(null);
            yield return new WaitForSeconds(0.5f);
        }
    }

    
}
