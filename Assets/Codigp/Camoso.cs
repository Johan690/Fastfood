
using UnityEngine;

public class Camoso : MonoBehaviour
{
    public Transform p;

    private void Update() 
    {
        GetComponent<Transform>().position = new Vector3(p.position.x, p.position.y, -10);
    }


}
