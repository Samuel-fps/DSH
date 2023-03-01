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

    private bool contar;
    private int numero;

    // Start is called before the first frame update
    void Start()
    {   
        //btn = gameObject.FindAnyObjectByType<Button>();
        //btn =GameOject.FindByTag("btnStart").GetCmponent<Button>();
        btn.onClick.AddListener(Pulsado);
        var tempColor = img.color;
        tempColor.a = 1f;
        img.color = tempColor;
        contar = false;
        numero = 3;
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
                case 1: img.sprite = spNumeros[0]; break;
                case 2: img.sprite = spNumeros[1]; break;
                case 3: img.sprite = spNumeros[2]; break;
                case 4: img.sprite = spNumeros[3]; break;
            }
            StartCoroutine(Esperar(1));
            contar = false;
            numero--;
        }
        else if(numero < 0){
            StartCoroutine(Esperar(2));
            SceneManager.LoadScene("Escena2", LoadSceneMode.Single);
        }
    }

    IEnumerator Esperar(int sec){
        yield return new WaitForSeconds(sec);
        contar = true;
    }
}
