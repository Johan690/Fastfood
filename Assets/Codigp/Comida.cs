using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Comida : MonoBehaviour
{
    bool isTortilla = false;
    public GameObject TortillaSlot;

    bool isCarne = false;
    public GameObject CarneSlot;

    public GameObject Canwas;

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

        if (col.gameObject.CompareTag("Comida"))
        {
            if (isTortilla && isCarne)
            {
               Canwas.SetActive(true);
            }
        }
    }

}
