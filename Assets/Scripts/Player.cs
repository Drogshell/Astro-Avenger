using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private float paddingLeft;
    [SerializeField] private float paddingTop;
    [SerializeField] private float paddingRight;
    [SerializeField] private float paddingBottom;
    
    private Vector2 rawInput;
    private Vector2 minBounds;
    private Vector2 maxBounds;

    private void Start()
    {
        InitializedBounds();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 delta = rawInput * (moveSpeed * Time.deltaTime);
        Vector2 newPosition = new Vector2();
        newPosition.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPosition.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        transform.position = newPosition;
    }

    private void InitializedBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    private void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
        Debug.Log(rawInput);
    }
}
