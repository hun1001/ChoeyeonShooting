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
    private GameObject bossPref = null;

    public int score = 0;


    private bool isGameOver = false;

    void Start()
    {

        isGameOver = false;
        score = 0;
        MainTextManager.Instance.SetScoreText(score);
        maxPosition = new Vector2(5f, 9f);
        minPosition = new Vector2(-5f, -9f);
        if (CheckBoss.isBoss==true)
        {
            SpawnBoss();
        }
        else if (CheckBoss.isBoss == false)
        {
            StartCoroutine(SpawnEnemyTypeA());
            StartCoroutine(SpawnEnemyTypeB());
            StartCoroutine(SpawnEnemyTypeC());
        }
    }

    private void SpawnBoss()
    {
        GameObject boss = null;
        boss = Instantiate(bossPref, new Vector2(0, 7), Quaternion.identity);
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

    public void AddScore(int add)
    {
        if (isGameOver) return;
        score += add;
        MainTextManager.Instance.SetScoreText(score);
    }

    public int GetScore()
    {
        return score;
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
