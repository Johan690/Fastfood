using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Comida : MonoBehaviour
{
    bool isTortilla = false;
    public GameObject TortillaSlot;

    bool isCarne = false;
    public GameObject CarneSlot;

    bool isMasa = false;
    public GameObject MasaSlot;

    bool isQueso = false;
    public GameObject QuesoSlot;

    bool isPeperoni = false;
    public GameObject PeperoniSlot;

    public GameObject Canwas;

    public Perdedor loter;
    public AudioSource mex;
    public AudioSource w;
    public Movertwo mocve;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Tortilla"))
        {
            isTortilla = true;
            TortillaSlot.SetActive(true);
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("Carne"))
        {
            isCarne = true;
            CarneSlot.SetActive(true);
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("Masa"))
        {
            isMasa = true;
            MasaSlot.SetActive(true);
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("Queso"))
        {
            isQueso = true;
            QuesoSlot.SetActive(true);
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("Peperoni"))
        {
            isPeperoni = true;
            PeperoniSlot.SetActive(true);
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("Comida"))
        {
            if (isTortilla && isCarne)
            {
               Canwas.SetActive(true);
               loter.StopAllCoroutines();
               mex.Stop();
               mocve.estaJUgando = false;
               w.Play();
            }
            else if (isMasa && isQueso && isPeperoni)
            {
                Canwas.SetActive(true);
                loter.StopAllCoroutines();
                mex.Stop();
                mocve.estaJUgando = false;
                w.Play();
            }
        }
    }

}
