using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pulsar : MonoBehaviour
{
    private Button boton;
    public Image img;
    private bool contar;
    private int numero;
    public Sprite[] spNumeros;
    public Text texto;

    // Start is called before the first frame update
    void Start()
    {
        //boton = GameObject.FindAnyObjectByType<Button>();
        boton = GameObject.FindWithTag("BtnPulsar").GetComponent<Button>();
        boton.onClick.AddListener(Pulsado);
        contar = false;
        numero = 3;
    }

    void Pulsado(){
        texto.gameObject.SetActive(true);
        boton.gameObject.SetActive(false);
        contar = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(contar){
            switch(numero){
                case 0:
                    Debug.Log("Aqui se cambia de escena");
                    break;
                case 1:
                    //img.sprite = spNumeros[0];
                    texto.text = "1";
                    break;
                case 2:
                    //img.sprite = spNumeros[1];
                    texto.text = "2";
                    break;
                case 3:
                    //img.sprite = spNumeros[2];
                    texto.text = "3";
                    break;
            }
            StartCoroutine(Esperar());
            contar = false;
            numero--;
        }
    }

    IEnumerator Esperar(){
        yield return new WaitForSeconds(1);
        contar = true;
    }
}
