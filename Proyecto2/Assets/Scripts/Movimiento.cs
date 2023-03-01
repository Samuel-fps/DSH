using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movimiento : MonoBehaviour
{
    public Camera camara;
    public int velocidad;
    public GameObject prefabSuelo;
    public GameObject prefabMoneda;
    public Text txtPuntos;

    public AudioSource asFuente;
    public AudioClip acSonido;
    public float fVolumen = 1f;

    // PRIVADAS
    private Vector3 offset;
    private float valX, valZ;
    private Vector3 dirActual;
    private Rigidbody rb;
    private int iPuntos = 0;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        offset = camara.transform.position; // Obtener posicion inicial
        valX = 0.0f;
        valZ = 0.0f;
        SueloInicial();
    }

    void SueloInicial(){
        for(int n = 0 ; n < 3 ; n++){
            valZ += 6.0f;
            GameObject elSuelo = Instantiate(prefabSuelo, new Vector3(valX, 0.0f, valZ), Quaternion.identity) as GameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        camara.transform.position = this.transform.position + offset;

        if(Input.GetKeyUp(KeyCode.Space)){
            if(dirActual == Vector3.forward)
                dirActual = Vector3.right;
            else
                dirActual = Vector3.forward;
        }
        float tiempo = velocidad * Time.deltaTime;
        rb.transform.Translate(dirActual * tiempo);
    }

    void OnCollisionExit(Collision other){
        if(other.transform.tag == "Suelo"){
            StartCoroutine(CrearSuelo(other));
        }
    }

    IEnumerator CrearSuelo(Collision col){
        yield return new WaitForSeconds(0.5f);
        col.rigidbody.isKinematic = false;
        col.rigidbody.useGravity = true;
        yield return new WaitForSeconds(0.5f);
        Destroy(col.gameObject);
        float ran = Random.Range(0f, 1f);
        if(ran < 0.5f)
            valX += 6.0f;
        else
            valZ += 6.0f;
        GameObject suelo = Instantiate(prefabSuelo, new Vector3(valX, 0.0f, valZ), Quaternion.identity) as GameObject;
        ran = Random.Range(0f, 1f);
        if(ran < 0.5f)
            Debug.Log("diamante");
            //GameObject moneda = Instantiate(prefabMoneda, new Vector3(valX, 1f, valZ), Quaternion.identity) as GameObject;
    }

    private void OnTriggerEnter(Collider other){
        Debug.Log("He chocado con un diamante");
        asFuente.PlayOneShot(acSonido, fVolumen);
        Destroy(other.gameObject);
        iPuntos++;
        txtPuntos.text = "Puntos " + iPuntos;
    }
}
