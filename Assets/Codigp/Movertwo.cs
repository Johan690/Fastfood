using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movertwo : MonoBehaviour
{

    public float moveSpeed;
    public Vector3 moveDirection;

    public bool grounded = true;
    public float jumpForce;

    public Animator animator;

    public AudioSource Jup;

    public bool estaJUgando = true;

    void Update()
    {
        if (estaJUgando)
        {
            Movimiento();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "piso")
        {
            grounded = true;
            animator.SetBool("ove", false);
            Jup.Stop();
        }
    }

    void Movimiento()
    {
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed, 0, 0);
        transform.Translate(moveDirection * Time.deltaTime);

        if (Input.GetAxisRaw("Vertical") == 1 || Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded == true)
            {
                grounded = false;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                animator.SetBool("ove", true);
                Jup.Play();
            }
        }


        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            animator.SetBool("move", true);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            animator.SetBool("move", true);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            animator.SetBool("move", false);
        }
    }
}
