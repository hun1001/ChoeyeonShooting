using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public Vector2 maxPosition { get; private set; }
    public Vector2 minPosition { get; private set; }

    [SerializeField]
    private GameObject[] enemy = null;

    void Start()
    {
        maxPosition = new Vector2(5f, 9f);
        minPosition = new Vector2(-5f, -9f);
        StartCoroutine(SpawnEnemyTypeA());
        StartCoroutine(SpawnEnemyTypeB());
        StartCoroutine(SpawnEnemyTypeC());
    }



    private IEnumerator SpawnEnemyTypeA()
    {
        float rand;
        while(true)
        {
            rand = Random.Range(5, -5);
            GameObject a = null;
            a = Instantiate(enemy[0], new Vector2(rand, 11), Quaternion.identity);
            a.transform.SetParent(null);
            yield return new WaitForSeconds(1.57f);
        }      
    }

    private IEnumerator SpawnEnemyTypeB()
    {
        float rand;
        while (true)
        {
            rand = Random.Range(9, 2);
            GameObject a = null;
            a = Instantiate(enemy[1], new Vector2(6, rand), Quaternion.identity);
            a.transform.SetParent(null);
            yield return new WaitForSeconds(1.57f);
        }
    }

    private IEnumerator SpawnEnemyTypeC()
    {
        float rand;
        while (true)
        {
            rand = Random.Range(5, -5);
            GameObject a = null;
            a = Instantiate(enemy[2], new Vector2(rand, 11), Quaternion.identity);
            a.transform.SetParent(null);
            yield return new WaitForSeconds(1.57f);
        }
    }
}
