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
    public GameObject prefabSuelo;
    // Start is called before the first frame update
    void Start()
    {
        velocidad = 1;
        offset = camara.transform.position;
        valX = 0.0f;
        valZ = 0.0f;
        SueloInicial();
    }

    void SueloInicial(){
        
        for(int n = 0; n<3; n++){
            valX += 6.0f;
            //valZ += 6.0f;
            GameObject elsuelo = Instantiate(prefabSuelo, new Vector3(valX, 0.0f, valZ), Quaternion.identity) as GameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
