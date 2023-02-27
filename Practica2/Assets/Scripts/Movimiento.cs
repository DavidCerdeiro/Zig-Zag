using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movimiento : MonoBehaviour
{
    public Image img;
    public Camera camara;
    private float velocidad;
    private Vector3 offset;
    private float valZ;
    private float valX;
    private Rigidbody rb;
    private float limite;
    public GameObject prefabSuelo;
    public GameObject prefabPincho;
    public GameObject patronMoneda;
    public GameObject patronMoneda2;
    public Sprite muerte;
    public AudioSource morir;
    private float avance;
    private float valX_suelo;
    private float valZ_suelo;
    // Start is called before the first frame update
    void Start()
    {
        velocidad = 0.5f;
        offset = camara.transform.position;
        valX = 0.0f;
        valZ = 0.0f;
        //SueloInicial();
        limite = this.transform.position.x;
        rb = GetComponent<Rigidbody>();
        avance = 1.4f;
    }

    void SueloInicial(){
        
        for(int n = 0; n<20; n++){
            if (n != 0) //para q no salga en el primer bloque aunq estaria mejor con la variable q lleva los bloques por los que has pasado
            {
                switch (Random.Range(0,2))
                {
                    case 0: Monedas(); break;
                    case 1: Pincho(); break;
                }
            } 
            valX += 6.0f;
            Vector3 position = new Vector3(valX, 0.0f, Random.Range((valZ-3.9f), (valZ+3.9f)));
            GameObject elsuelo = Instantiate(prefabSuelo, position, Quaternion.identity) as GameObject;
            valX_suelo = elsuelo.transform.position.x;
            valZ_suelo = elsuelo.transform.position.z;
            avance = avance + 0.05f;
            Debug.Log("Se ha aumentado la velocidad");
        }
    }
    void Pincho(){
        Vector3 position = new Vector3(valX_suelo, 0.09f, Random.Range((valZ_suelo-3f), (valZ_suelo+3f)));
        GameObject elPincho = Instantiate(prefabPincho, position, Quaternion.identity) as GameObject;
    }

    void Monedas(){
        Vector3 position = new Vector3(valX_suelo, 0.0f, valZ_suelo);
        switch (Random.Range(0,2))
        {
            case 0: GameObject laMoneda = Instantiate(patronMoneda, position, Quaternion.identity) as GameObject;
                    break;
            case 1: GameObject laMoneda2 = Instantiate(patronMoneda2, position, Quaternion.identity) as GameObject;
                    break;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("pincho")){
            Debug.Log("Jugador ha muerto por pincho");
            this.gameObject.SetActive(false);
            img.gameObject.SetActive(true);
            img.sprite = muerte;
            morir.Play();
        }

    }
    // Update is called once per frame
    void Update()
    {
        float movVertical = Input.GetAxis("Horizontal");
        Vector3 movimiento = new Vector3(avance, 0.0f, 4*(-movVertical));
        rb.AddForce(movimiento * velocidad);
        camara.transform.position = this.transform.position + offset;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (this.transform.position.y > 0.59 && this.transform.position.y < 0.61)
            {
                Vector3 salto = new Vector3(-19.2f, 50.0f, 0.0f);
                rb.AddForce(salto * 8);
            }
            
        }

        limite = valX - this.transform.position.x;          //diferencia entre ultima plataforma generada y posicion del jugador
        if (limite < 80)
        {
            SueloInicial();
        }

        if (transform.position.y < -2)
        {
            Debug.Log("Jugador ha muerto por caida");
            //Destroy(gameObject); en vez de destruirlo lo quitamos de la vista
            this.gameObject.SetActive(false);
            img.gameObject.SetActive(true);
            img.sprite = muerte;
            morir.Play();

        }
    }
}