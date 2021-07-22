using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 targetPosition = Vector2.zero;
    [SerializeField]
    private float speed = 15.7f;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButton(0) == true)
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.x = Mathf.Clamp(targetPosition.x, GameManager.Instance.minPosition.x, GameManager.Instance.maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, GameManager.Instance.minPosition.y, GameManager.Instance.maxPosition.y);
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, targetPosition, speed * Time.deltaTime);
        }
    }
}