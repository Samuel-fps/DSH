using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recompensa : MonoBehaviour
{
    public float velocidad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, Time.deltaTime + velocidad);
    }
}
