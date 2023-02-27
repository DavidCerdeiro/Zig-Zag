using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class plataformas : MonoBehaviour
{
    private SphereCollider jugador;
    private int plat;
    public Text texto;

    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindWithTag("Player").GetComponent<SphereCollider>();

    }

    // Update is called once per frame
    void Update()
    {
        plat = (int)(jugador.transform.position.x / 6);
        texto.text = "Plataformas recorridas: " + plat;
    }
}
