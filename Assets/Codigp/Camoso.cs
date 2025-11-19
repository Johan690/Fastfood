using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
public class Camoso : MonoBehaviour
{
    public Transform target;
    public float velocidadCam;
    public Vector3 positionOffset;

    private void LateUpdate()
    {
        Vector3 posicionDeseada = target.position + positionOffset;

        Vector3 posicionSuave = Vector3.Lerp(transform.position, posicionDeseada, velocidadCam);

        transform.position = posicionSuave;

    }


}
