using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class yoaation : MonoBehaviour
{

    /*public static yoaation instance;


   private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }*/


    // Para cambiar escenas
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Selecvel()
    {
        SceneManager.LoadScene(1);
    }

    public void Tutorial()
    {
        SceneManager.LoadScene(2);
    }

    public void Nivone()
    {
        SceneManager.LoadScene(3);
    }

    public void Pausenu()
    {
        SceneManager.LoadScene(4);
    }

    public void Creditos()
    {
        SceneManager.LoadScene(5);
    }


    public void Salir()
    {
        Application.Quit();
    }
}