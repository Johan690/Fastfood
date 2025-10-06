using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Control : MonoBehaviour
{
    private Motiono motiono;

    public Vector2 direccion;

    public Rigidbody2D rb2D;

    public float velocidadMovimiento;

    private void Awake()
    {
        motiono = new();
    }

    private void OnEnable()
    {
        motiono.Enable();
    }

    private void OnDisable()
    {
        motiono.Disable();
    }

    private void Update()
    {
        direccion = motiono.Base.Mover.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + Time.fixedDeltaTime * velocidadMovimiento * direccion.normalized);
    }

}
