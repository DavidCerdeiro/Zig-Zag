using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptSuelo : MonoBehaviour
{

    private SphereCollider jugador;
    private float i;

    // Start is called before the first frame update
    void Start()
    {
        //jugador = GameObject.FindWithTag("Player").GetComponent<GameObject>();
        jugador = GameObject.FindAnyObjectByType<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        i = this.transform.position.x - jugador.transform.position.x;
        if (i < -10)
        {
            Destroy(this.gameObject);
            Debug.Log("Se ha eliminado una plataforma");
        }
    }
}
