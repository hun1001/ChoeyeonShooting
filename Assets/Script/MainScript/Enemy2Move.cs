using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Move : EnemyMove
{
    Player player = null;
    [SerializeField]
    GameObject bullet = null;
    void Start()
    {
        player = FindObjectOfType<Player>();
        StartCoroutine(attack());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        base.CheckLimit();
    }

    private IEnumerator attack()
    {
        Vector3 pos;
        yield return new WaitForSeconds(1.2f);
        while(true)
        {
            pos = player.transform.position;
            Instantiate(bullet, gameObject.transform.position, Quaternion.LookRotation(pos));
            bullet.transform.SetParent(null);

        }

    }
}
