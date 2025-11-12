using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Perdedor : MonoBehaviour
{
    public Text cuenta;
    int seg;
    public AudioSource mex;
    
    private void Awake()
    {
        seg = 60;
        StartCoroutine(Cintador());
    }

    private void Update()
    {
        cuenta.text = "00:" + seg;
    }

    IEnumerator Cintador()
    {
        yield return new WaitForSecondsRealtime(1);
        seg--;
        if (seg != 0)
        {
            StartCoroutine(Cintador());
        }
        else
        {
            mex.Stop();
        }
    }

}
