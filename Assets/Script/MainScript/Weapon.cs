using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private int weaponType = 0;

    [SerializeField]
    private GameObject[] bulletPrefab = null;

    [SerializeField]
    private Transform bulletPosition = null;

    void Start()
    {
        StartCoroutine(Fire());
    }

    void Update()
    {
        
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
