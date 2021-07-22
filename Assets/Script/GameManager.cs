using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public Vector2 maxPosition { get; private set; }
    public Vector2 minPosition { get; private set; }
    void Start()
    {
        maxPosition = new Vector2(2.5f, 4.5f);
        minPosition = new Vector2(-2.5f, -4.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
