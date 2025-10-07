using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class inmover : MonoBehaviour
{

    Rigidbody2D rg;

    public int speed;
    public int jumpPower;

    Vector2 veMove;

    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rg.linearVelocity = new Vector2(veMove.x * speed, rg.linearVelocity.y);
    }

    void Update()
    {
        
    }

    public void Salto(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            rg.linearVelocity = new Vector2(rg.linearVelocity.x, jumpPower);
        }
    }

    public void Movition(InputAction.CallbackContext value)
    {
        veMove = value.ReadValue<Vector2>();
        
    }

    void flip()
    {
        if (veMove.x < -0.1f) transform.localScale = new Vector3(-1, 1, 1);
        if (veMove.x > 0.1f) transform.localScale = new Vector3(1, 1, 1);
    }
}
