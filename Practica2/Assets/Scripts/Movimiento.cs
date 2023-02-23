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
    private int limite;
    public GameObject prefabSuelo;
    // Start is called before the first frame update
    void Start()
    {
        velocidad = 2;
        offset = camara.transform.position;
        valX = 0.0f;
        valZ = 0.0f;
        limite = 10;
        SueloInicial();
        rb = GetComponent<Rigidbody>();
    }

    void SueloInicial(){
        
        for(int n = 0; n<limite; n++){
            valX += 6.0f;
            //valZ += 6.0f;
            Vector3 position = new Vector3(valX, 0.0f, Random.Range((valZ-3), (valZ+3)));
            GameObject elsuelo = Instantiate(prefabSuelo, position, Quaternion.identity) as GameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float movVertical = Input.GetAxis("Horizontal");
        Vector3 movimiento = new Vector3(1.0f, 0.0f, 4*(-movVertical));
        rb.AddForce(movimiento * velocidad);
        camara.transform.position = this.transform.position + offset;

        if (transform.position.x%6 == 0)
        {
            Debug.Log("Nueva plataforma");
            limite = limite + 1;
        }

        if (transform.position.y < -2)
        {
            Debug.Log("Jugador ha muerto");
            Destroy(this.gameObject);
        }
    }
}
