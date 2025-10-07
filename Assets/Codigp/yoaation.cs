using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class yoaation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    // Para cambiar escenas
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Tutorial()
    {
        SceneManager.LoadScene(1);
    }

    public void Nivone()
    {
        SceneManager.LoadScene(2);
    }

    public void Creditos()
    {
        SceneManager.LoadScene(3);
    }


    public void Salir()
    {
        Application.Quit();
    }
}