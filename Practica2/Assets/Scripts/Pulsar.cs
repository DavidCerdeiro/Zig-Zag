using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pulsar : MonoBehaviour
{
    //public Button bnt;
    private Button btn;
    public Image img;
    private bool contar;
    private int numero;
    public Sprite[] spNumeros;
    public Text texto;
    
    // Start is called before the first frame update
    void Start()
    {
        //btn = GameObject.FindAnyObjectByType<Button>();
        btn = GameObject.FindWithTag("boton").GetComponent<Button>();
        btn.onClick.AddListener(Pulsado);
        contar = false;
        numero = 3;
    }

    void Pulsado()
    {
        img.gameObject.SetActive(true);
        //texto.gameObject.SetActive(true);
        btn.gameObject.SetActive(false);
        contar = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (contar) 
        {
            switch (numero)
            {
                case 0: Debug.Log("Terminado - Salto a otra escena"); break;
                case 1: img.sprite = spNumeros[0]; /*texto.text = "1"*/; break;
                case 2: img.sprite = spNumeros[1]; /*texto.text = "2"*/; break;
                case 3: img.sprite = spNumeros[2]; /*texto.text = "3"*/; break;
            }
            StartCoroutine(Esperar());  //proceso paralelo
            contar = false;
            numero--;
        }
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(1);
        contar = true;

    }
}
