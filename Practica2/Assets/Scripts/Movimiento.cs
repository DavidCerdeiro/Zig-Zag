using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public Camera camara;
    private int velocidad;
    private Vector3 offset;
    private float valZ;
    private float valX;
    private Rigidbody rb;
    private float limite;
    public GameObject prefabSuelo;
    // Start is called before the first frame update
    void Start()
    {
        velocidad = 2;
        offset = camara.transform.position;
        valX = 0.0f;
        valZ = 0.0f;
        SueloInicial();
        limite = this.transform.position.x;
        rb = GetComponent<Rigidbody>();
    }

    void SueloInicial(){
        
        for(int n = 0; n<10; n++){
            valX += 6.0f;
            //valZ += 6.0f;
            Vector3 position = new Vector3(valX, 0.0f, Random.Range((valZ-6), (valZ+4)));
            GameObject elsuelo = Instantiate(prefabSuelo, position, Quaternion.identity) as GameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float movVertical = Input.GetAxis("Horizontal");
        Vector3 movimiento = new Vector3(1.6f, 0.0f, 4*(-movVertical));
        rb.AddForce(movimiento * velocidad);
        camara.transform.position = this.transform.position + offset;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (this.transform.position.y > 0.59 && this.transform.position.y < 0.61)
            {
                Vector3 salto = new Vector3(0.0f, 50.0f, 0.0f);
                rb.AddForce(salto * 8);
            }
            
        }

        limite = valX - this.transform.position.x;          //diferencia entre ultima plataforma generada y posicion del jugador
        if (limite < 40)
        {
            Debug.Log("Nueva generacion de plataforma");    //temporal para saber que se generan nuevas plataformas
            SueloInicial();
        }

        if (transform.position.y < -2)
        {
            Debug.Log("Jugador ha muerto");
            Destroy(this.gameObject);
        }
    }
}
