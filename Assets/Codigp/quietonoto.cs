using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class quietonoto : MonoBehaviour
{
    Rigidbody2D rg;

    [SerializeField] int speed;
    float speedMultiplier;

    [Range(1,10)]
    [SerializeField] float acceleration;

    bool btnPressed;

    private void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        UpdateSpeedMultiplier();
       
        float targetSpeed = speed * speedMultiplier;


        rg.linearVelocity = new Vector2(targetSpeed, rg.linearVelocity.y);
    }

    public void Move(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            btnPressed = true;
        }

        if (value.canceled)
        {
            btnPressed = false;
        }
    }

   
    void UpdateSpeedMultiplier()
    {
        if (btnPressed && speedMultiplier < 1)
        {
            speedMultiplier += Time.deltaTime*acceleration;
        }

        else if (!btnPressed && speedMultiplier > 0)
        {
            speedMultiplier -= Time.deltaTime*acceleration;

            if (speedMultiplier < 0) speedMultiplier = 0;
        }
    }

}
