using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pulsar : MonoBehaviour
{

    public Button btn;
    public Image img;
    public Sprite[] spNumeros;
    public Text txtNumeros;

    private bool contar;
    private int numero = 3;

    // Start is called before the first frame update
    void Start()
    {   
        //btn = gameObject.FindAnyObjectByType<Button>();
        //btn =GameOject.FindByTag("btnStart").GetCmponent<Button>();
        btn.onClick.AddListener(Pulsado);
        contar = false;
        numero = 2;
        txtNumeros.text = "" + numero;
    }

    void Pulsado(){
        Debug.Log("pulsado");
        img.gameObject.SetActive(true);
        contar = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(contar && numero >= 0){
            switch (numero)
            {
                case 0: Debug.Log("Terminado"); break;
                case 1: img.sprite = spNumeros[0]; txtNumeros.text = "1"; break;
                case 2: img.sprite = spNumeros[1]; txtNumeros.text = "2"; break;
                case 3: img.sprite = spNumeros[2]; txtNumeros.text = "3"; break;
            }
            StartCoroutine(Esperar());
            contar = false;
            numero--;
        }
        else if(numero <= 0){
            txtNumeros.text = "GO";
            StartCoroutine(Esperar());
            SceneManager.LoadScene("Escena2", LoadSceneMode.Single);
        }
    }

    IEnumerator Esperar(){
        yield return new WaitForSeconds(1);
        contar = true;
    }
}
