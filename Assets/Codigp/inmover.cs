using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class inmover : MonoBehaviour
{

    public Rigidbody2D rg;

    public float speed;
    public float jumpPower;

    Vector3 veMove;

    bool grounded;

    private void Awake()
    {
        grounded = true;
    }


    void Update()
    {
        veMove = new Vector3(Input.GetAxis("Horizontal")*speed,0,0);
        GetComponent<Transform>().position += veMove*Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            grounded = false;
            rg.AddForce(new Vector2(0,jumpPower),ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "piso")
        {
            grounded = true;
        }
    }

}
