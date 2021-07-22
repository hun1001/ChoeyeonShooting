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
    }



    private IEnumerator SpawnEnemyTypeA()
    {
        yield return new WaitForSeconds(1.57f);
    }

    private IEnumerator SpawnEnemyTypeB()
    {
        yield return new WaitForSeconds(1.57f);
    }

    private IEnumerator SpawnEnemyTypeC()
    {
        yield return new WaitForSeconds(1.57f);
    }

    private void SpawnEnemyA()
    {

    }

    private void SpawnEnemyB()
    {

    }

    private void SpawnEnemyC()
    {

    }
}
