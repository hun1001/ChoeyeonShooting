using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public Vector2 maxPosition { get; private set; }
    public Vector2 minPosition { get; private set; }

    [SerializeField]
    private GameObject[] enemy = null;

    [SerializeField]
    private int score = 0;

    private int bestScore = 0;

    private bool isGameOver = false;

    void Start()
    {
        isGameOver = false;
        score = 0;
        //MainTextManager.Instance.SetValue(1, score);
        maxPosition = new Vector2(5f, 9f);
        minPosition = new Vector2(-5f, -9f);
        StartCoroutine(SpawnEnemyTypeA());
        StartCoroutine(SpawnEnemyTypeB());
        StartCoroutine(SpawnEnemyTypeC());
        StartCoroutine(SpawnEnemyTypeD());
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
            yield return new WaitForSeconds(Random.Range(2f, 0.5f));
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
            yield return new WaitForSeconds(Random.Range(3.5f, 1f));
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
            yield return new WaitForSeconds(Random.Range(4f, 0.9f));
        }
    }

    private IEnumerator SpawnEnemyTypeD()
    {
        float rand;
        while (true)
        {
            rand = Random.Range(5, -5);
            GameObject a = null;
            a = Instantiate(enemy[3], new Vector2(rand, 11), Quaternion.identity);
            a = Instantiate(enemy[3], new Vector2(rand+1.4f, 11), Quaternion.identity);
            a = Instantiate(enemy[3], new Vector2(rand-1.4f, 11), Quaternion.identity);
            a.transform.SetParent(null);
            yield return new WaitForSeconds(Random.Range(4.4f, 1.4f));
        }
    }

    public void AddScore(int add)
    {
        if (isGameOver) return;
        score += add;
        if (score > bestScore)
        {
            bestScore = score;
        }
    }

    public int GetScore()
    {
        //return score + MainTextManager.Instance.GetValue(2);
        return 157;
    }

    public bool GetisGameOver()
    {
        return isGameOver;
    }

    public void SetisGameOver(bool b)
    {
        isGameOver = b;
    }
}
